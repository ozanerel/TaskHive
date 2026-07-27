using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TH.BLL.Managers.Abstracts;
using TH.ENTITIES.Models;
using TH.MVCUI.Areas.Admin.Models.PageVMs;
using TH.MVCUI.Areas.Admin.Models.PageVMs.RoleVM;

namespace TH.MVCUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        private readonly IRoleManager _roleManager;

        public RoleController(IRoleManager roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Index()
        {
            RoleIndexVm vm = new()
            {
                Roles = await _roleManager.GetAllAsync()
            };

            return View(vm);
        }

        public IActionResult Create()
        {

            return View(new RoleCreateVm());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RoleCreateVm vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            Role role = new()
            {
                Name = vm.RoleName,
                Description = vm.Description
            };

            await _roleManager.CreateAsync(role);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var role = await _roleManager.GetByIdAsync(id);

            if (role == null)
                return NotFound();

            RoleDetailsVm vm = new()
            {
                Id = role.Id,
                RoleName = role.Name,
                Description = role.Description,
                Users = role.Users?.ToList() ?? new(),
                Status = role.Status,
                CreatedDate = role.CreatedDate
            };

            return View(vm);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var role = await _roleManager.GetByIdAsync(id);

            if (role == null)
                return NotFound();

            RoleUpdateVm vm = new()
            {
                Id = role.Id,
                RoleName = role.Name,
                Description = role.Description
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(RoleUpdateVm vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            var role = await _roleManager.GetByIdAsync(vm.Id);

            role.Name = vm.RoleName;
            role.Description = vm.Description;


            await _roleManager.UpdateAsync(role);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var role = await _roleManager.GetByIdAsync(id);

            if (role == null)
                return NotFound();

            RoleDeleteVm vm = new()
            {
                Id = role.Id,
                RoleName = role.Name,
                Description = role.Description
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(RoleDeleteVm vm)
        {
            var role = await _roleManager.GetByIdAsync(vm.Id);

            await _roleManager.MakePassiveAsync(role);

            return RedirectToAction(nameof(Index));
        }
    }
}