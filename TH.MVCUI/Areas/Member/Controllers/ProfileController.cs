using Microsoft.AspNetCore.Mvc;
using TH.BLL.Managers.Abstracts;
using TH.BLL.Services.Abstracts;
using TH.ENTITIES.Models;
using TH.MVCUI.Areas.Member.Models.PageVMs.ProfileVM;
using TH.MVCUI.Areas.Member.ViewModels.ProfileVM;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;

namespace TH.MVCUI.Areas.Member.Controllers
{
    [Area("Member")]
    [Authorize(Roles = "Member")]
    public class ProfileController : Controller
    {
        private readonly IUserManager _userManager;
        private readonly IUserContext _userContext;
        private readonly IWebHostEnvironment _environment;

        public ProfileController(
            IUserManager userManager,
            IUserContext userContext,
            IWebHostEnvironment environment)
        {
            _userManager = userManager;
            _userContext = userContext;
            _environment = environment;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userContext.GetCurrentUserAsync();

            if (user == null)
                return NotFound();

            ProfileVm vm = new()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                RoleName = user.Role?.Name,
                ImageUrl = user.AppUser?.AppUserProfile?.ImageUrl
            };

            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Edit()
        {
            var user = await _userContext.GetCurrentUserAsync();

            if (user == null)
                return NotFound();

            EditProfileVm vm = new()
            {
                //Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                ImageUrl = user.AppUser?.AppUserProfile?.ImageUrl
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditProfileVm vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            var user = await _userContext.GetCurrentUserAsync();

            if (user == null)
                return NotFound();

            user.FirstName = vm.FirstName;
            user.LastName = vm.LastName;
            user.Email = vm.Email;

            if (user.AppUser == null)
            {
                TempData["Error"] = "User profile could not be found.";
                return RedirectToAction(nameof(Index));
            }

            if (user.AppUser.AppUserProfile == null)
            {
                user.AppUser.AppUserProfile = new AppUserProfile
                {
                    AppUserId = user.AppUserId
                };
            }

            if (vm.ImageFile != null)
            {
                string extension =
                    Path.GetExtension(vm.ImageFile.FileName).ToLower();

                if (!EditProfileVm.AllowedExtensions.Contains(extension))
                {
                    ModelState.AddModelError(
                        "ImageFile",
                        "Only JPG, JPEG, PNG and WEBP files are allowed.");

                    vm.ImageUrl = user.AppUser.AppUserProfile.ImageUrl;

                    return View(vm);
                }

                if (vm.ImageFile.Length > EditProfileVm.MaxFileSize)
                {
                    ModelState.AddModelError(
                        "ImageFile",
                        "Maximum file size is 2 MB.");

                    vm.ImageUrl = user.AppUser.AppUserProfile.ImageUrl;

                    return View(vm);
                }

                string folder = Path.Combine(
                    _environment.WebRootPath,
                    "images",
                    "profiles");

                if (!Directory.Exists(folder))
                    Directory.CreateDirectory(folder);

                if (!string.IsNullOrEmpty(
                    user.AppUser.AppUserProfile.ImageUrl))
                {
                    string oldPath = Path.Combine(
                        _environment.WebRootPath,
                        user.AppUser.AppUserProfile.ImageUrl.TrimStart('/'));

                    if (System.IO.File.Exists(oldPath))
                        System.IO.File.Delete(oldPath);
                }

                string fileName =
                    Guid.NewGuid() + extension;

                string filePath =
                    Path.Combine(folder, fileName);

                await using FileStream stream =
                    new(filePath, FileMode.Create);

                await vm.ImageFile.CopyToAsync(stream);

                user.AppUser.AppUserProfile.ImageUrl =
                    "/images/profiles/" + fileName;
            }

            await _userManager.UpdateAsync(user);

            TempData["Success"] = "Profil başarıyla güncellendi.";

            return RedirectToAction(nameof(Index));
        }
    }
}