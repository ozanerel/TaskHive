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
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Role role)
        {
            if (!ModelState.IsValid)
                return View(role);

            await _roleManager.CreateAsync(role);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var role = await _roleManager.GetByIdAsync(id);

            if (role == null)
                return NotFound();

            return View(role);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var role = await _roleManager.GetByIdAsync(id);

            if (role == null)
                return NotFound();

            return View(role);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Role role)
        {
            if (!ModelState.IsValid)
                return View(role);

            await _roleManager.UpdateAsync(role);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var role = await _roleManager.GetByIdAsync(id);

            if (role == null)
                return NotFound();

            return View(role);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Role role)
        {
            await _roleManager.MakePassiveAsync(role);

            return RedirectToAction(nameof(Index));
        }
    }
}