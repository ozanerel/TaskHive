using Microsoft.AspNetCore.Mvc;
using TH.BLL.Managers.Abstracts;
using TH.ENTITIES.Models;
using TH.MVCUI.Areas.Admin.Models.PageVMs;

namespace TH.MVCUI.Areas.Admin.Controllers
{
    public class RoleController : Controller
    {
        private readonly IRoleManager _roleManager;

        public RoleController(IRoleManager roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Index()
        {
            var vm = new RolePageVm
            {
                Roles = await _roleManager.GetAllAsync()
            };

            return View(vm);
        }

        public IActionResult Create()
        {
            RolePageVm vm = new RolePageVm()
            {
                Role = new Role()
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RolePageVm vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            await _roleManager.CreateAsync(vm.Role);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var role = await _roleManager.GetByIdAsync(id);

            if (role == null)
                return NotFound();

            RolePageVm vm = new()
            {
                Role = role
            };

            return View(vm);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var role = await _roleManager.GetByIdAsync(id);

            if (role == null)
                return NotFound();

            RolePageVm vm = new()
            {
                Role = role
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(RolePageVm vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            await _roleManager.UpdateAsync(vm.Role);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var role = await _roleManager.GetByIdAsync(id);

            if (role == null)
                return NotFound();

            RolePageVm vm = new()
            {
                Role = role
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(RolePageVm vm)
        {
            await _roleManager.MakePassiveAsync(vm.Role);

            return RedirectToAction(nameof(Index));
        }
    }
}