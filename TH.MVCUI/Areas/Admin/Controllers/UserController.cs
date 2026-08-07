using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TH.BLL.Managers.Abstracts;
using TH.ENTITIES.Enums;
using TH.ENTITIES.Models;
using TH.MVCUI.Areas.Admin.Models.PageVMs;
using TH.MVCUI.Areas.Admin.Models.PageVMs.UserVM;

namespace TH.MVCUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly IUserManager _userManager;
        private readonly IRoleManager _roleManager;
        private readonly UserManager<AppUser> _identityManager;
        private readonly RoleManager<IdentityRole<int>> _identityRoleManager;

        public UserController(IUserManager userManager, IRoleManager roleManager, UserManager<AppUser> identityManager, RoleManager<IdentityRole<int>> identityRoleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _identityManager = identityManager;
            _identityRoleManager = identityRoleManager;
        }

        public async Task<IActionResult> Index(string search,int? roleId,DataStatus? status)
        {
            UserIndexVm vm = new UserIndexVm()
            {
                Users = await _userManager.FilterUsersAsync(search,roleId,status),

                Roles = await _roleManager.GetAllAsync(),

                Search = search,
                RoleId = roleId,
                Status = status?.ToString()
            };

            return View(vm);
        }

        public async Task<IActionResult> Details(int id)
        {
            var user = await _userManager.GetByIdAsync(id);

            if (user == null)
                return NotFound();

            UserDetailsVm vm = new()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                RoleName = user.Role?.Name,
                Projects = user.Projects?.ToList() ?? new(),
                Tasks = user.Tasks?.ToList() ?? new(),
                Status = user.Status,
                CreatedDate = user.CreatedDate
            };

            return View(vm);
        }

        public async Task<IActionResult> Create()
        {
            //ViewBag.Roles = await _roleManager.GetAllAsync();
            UserCreateVm vm = new()
            {
                Roles = await _roleManager.GetAllAsync()
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserCreateVm vm)
        {

            //if (!ModelState.IsValid)
            //{
            //    //ViewBag.Roles = await _roleManager.GetAllAsync();
            //    vm.Roles = await _roleManager.GetAllAsync();

            //    return View(vm);
            //}

            if (!ModelState.IsValid)
            {
                foreach (var error in ModelState.Values.SelectMany(x => x.Errors))
                {
                    Console.WriteLine(error.ErrorMessage);
                }

                vm.Roles = await _roleManager.GetAllAsync();

                return View(vm);
            }

            var appUser = new AppUser
            {
                UserName = vm.Email,
                Email = vm.Email,
                CreatedDate = DateTime.Now,
                Status = DataStatus.Inserted
            };

            var result = await _identityManager.CreateAsync(appUser, vm.Password); // You can set a default password or generate one

            //if (!result.Succeeded)
            //{
            //    vm.Roles = await _roleManager.GetAllAsync();

            //    foreach (var error in result.Errors)
            //    {
            //        ModelState.AddModelError("", error.Description);
            //    }

            //    return View(vm);
            //}

            //if (!result.Succeeded)
            //{
            //    foreach (var error in result.Errors)
            //    {
            //        Console.WriteLine(error.Description);
            //    }
            //}

            //Craete kontrol
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                vm.Roles = await _roleManager.GetAllAsync();

                return View(vm);
            }

            //await _identityManager.AddToRoleAsync(appUser,"Member");

            var roleResult = await _identityManager.AddToRoleAsync(appUser, "Member");

            //roleResult kontrol
            if (!roleResult.Succeeded)
            {
                await _identityManager.DeleteAsync(appUser); //Eğer rol atanamazsa oluşturduğumuz kullanıcıyı siliyoruz. Böylece yarım kayıt kalmıyor.

                foreach (var error in roleResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                vm.Roles = await _roleManager.GetAllAsync();

                return View(vm);
            }

            User user = new()
            {
                FirstName = vm.FirstName,
                LastName = vm.LastName,
                Email = vm.Email,
                RoleId = vm.RoleId.Value,
                AppUserId = appUser.Id
            };


            await _userManager.CreateAsync(user);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var user = await _userManager.GetByIdAsync(id);

            if (user == null)
                return NotFound();

            //ViewBag.Roles = await _roleManager.GetAllAsync();

            UserUpdateVm vm = new()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                RoleId = user.RoleId,
                Roles = await _roleManager.GetAllAsync()
            };


            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserUpdateVm vm)
        {
            if (!ModelState.IsValid)
            {
                vm.Roles = await _roleManager.GetAllAsync();
                return View(vm);
            }

            var user = await _userManager.GetByIdAsync(vm.Id);

            user.FirstName = vm.FirstName;
            user.LastName = vm.LastName;
            user.Email = vm.Email;
            user.RoleId = vm.RoleId;

            await _userManager.UpdateAsync(user);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var user = await _userManager.GetByIdAsync(id);

            if (user == null)
                return NotFound();

            UserDeleteVm vm = new()
            {
                Id = user.Id,
                FullName = user.FirstName + " " + user.LastName,
                Email = user.Email,
                RoleName = user.Role?.Name ?? "No Role",
                ProjectCount = user.Projects?.Count ?? 0,
                TaskCount = user.Tasks?.Count ?? 0,
                Status = user.Status
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(UserDeleteVm vm)
        {
            var user = await _userManager.GetByIdAsync(vm.Id);

            if (user == null)
                return NotFound();

            await _userManager.MakePassiveAsync(user);

            return RedirectToAction(nameof(Index));
        }
    }
}