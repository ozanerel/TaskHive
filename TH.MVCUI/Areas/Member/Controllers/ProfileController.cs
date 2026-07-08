using Microsoft.AspNetCore.Mvc;
using TH.BLL.Managers.Abstracts;
using TH.BLL.Services.Abstracts;
using TH.ENTITIES.Models;
using TH.MVCUI.Areas.Member.Models.PageVMs.ProfileVM;
using TH.MVCUI.Areas.Member.ViewModels.ProfileVM;

namespace TH.MVCUI.Areas.Member.Controllers
{
    [Area("Member")]
    public class ProfileController : Controller
    {
        private readonly IUserManager _userManager;
        private readonly IUserContext _userContext;

        public ProfileController(IUserManager userManager,IUserContext userContext)
        {
            _userManager = userManager;
            _userContext = userContext;
        }

        public async Task<IActionResult> Index()
        {
            //// Şimdilik örnek kullanıcı
            //int userId = 1;

            //User user = await _userManager.GetByIdAsync(userId);

            var user = await _userContext.GetCurrentUserAsync();

            if (user == null)
                return NotFound();

            ProfileVm vm = new ProfileVm
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

            EditProfileVm vm = new EditProfileVm
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                ImageUrl = user.AppUser?.AppUserProfile?.ImageUrl
            };

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditProfileVm vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            User user = await _userManager.GetByIdAsync(vm.Id);

            if (user == null)
                return NotFound();

            user.FirstName = vm.FirstName;
            user.LastName = vm.LastName;
            user.Email = vm.Email;

            await _userManager.UpdateAsync(user);

            TempData["Success"] = "Profil başarıyla güncellendi.";

            return RedirectToAction(nameof(Index));
        }
    }
}