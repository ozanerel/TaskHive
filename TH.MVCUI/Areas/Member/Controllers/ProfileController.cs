using Microsoft.AspNetCore.Mvc;
using TH.BLL.Managers.Abstracts;
using TH.ENTITIES.Models;
using TH.MVCUI.Areas.Member.Models.PageVMs.ProfileVM;
using TH.MVCUI.Areas.Member.ViewModels.ProfileVM;

namespace TH.MVCUI.Areas.Member.Controllers
{
    [Area("Member")]
    public class ProfileController : Controller
    {
        private readonly IUserManager _userManager;

        public ProfileController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            // Şimdilik örnek kullanıcı
            int userId = 1;

            User user = await _userManager.GetByIdAsync(userId);

            if (user == null)
                return NotFound();

            ProfileVm vm = new ProfileVm
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                RoleName = user.Role?.Name
            };

            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Edit()
        {
            int userId = 1;

            User user = await _userManager.GetByIdAsync(userId);

            if (user == null)
                return NotFound();

            EditProfileVm vm = new EditProfileVm
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
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