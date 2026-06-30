using Microsoft.AspNetCore.Mvc;
using TH.BLL.Managers.Abstracts;
using TH.ENTITIES.Models;
using TH.MVCUI.Areas.Admin.Models.PageVMs;

namespace TH.MVCUI.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserManager _userManager;
        private readonly IRoleManager _roleManager;

        public UserController(IUserManager userManager,IRoleManager roleManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            UserPageVm vm = new UserPageVm()
            {
                Users = await _userManager.GetAllAsync()
            };

            return View(vm);
        }

        public async Task<IActionResult> Details(int id)
        {
            var user = await _userManager.GetByIdAsync(id);

            if (user == null)
                return NotFound();

            UserPageVm vm = new()
            {
                User = user
            };

            return View(vm);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Roles = await _roleManager.GetAllAsync();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Roles = await _roleManager.GetAllAsync();

                return View(user);
            }

            await _userManager.CreateAsync(user);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var user = await _userManager.GetByIdAsync(id);

            if (user == null)
                return NotFound();

            ViewBag.Roles = await _roleManager.GetAllAsync();

            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserPageVm vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            await _userManager.UpdateAsync(vm.User);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var user = await _userManager.GetByIdAsync(id);

            if (user == null)
                return NotFound();

            UserPageVm vm = new()
            {
                User = user
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(UserPageVm vm)
        {
            var user = await _userManager.GetByIdAsync(vm.User.Id);

            if (user == null)
                return NotFound();

            await _userManager.MakePassiveAsync(user);

            return RedirectToAction(nameof(Index));
        }
    }
}