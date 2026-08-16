using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TH.BLL.Managers.Abstracts;
using TH.ENTITIES.Enums;
using TH.ENTITIES.Models;
using TH.MVCUI.Models.ViewModels.AppUserViewModels;

namespace TH.MVCUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IAppUserManager _appUserManager;
        private readonly IUserManager _userManagerBLL;
        private readonly IRoleManager _roleManager;

        public AccountController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, IUserManager userManagerBLL, IRoleManager roleManager,IAppUserManager appUserManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _userManagerBLL = userManagerBLL;
            _roleManager = roleManager;
            _appUserManager = appUserManager;
        }

        [HttpGet]
        public IActionResult Login() => View();

        //[HttpPost]
        //public async Task<IActionResult> Login(string username, string password)
        //{
        //    if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
        //    {
        //        ViewBag.Error = "Kullanıcı adı ve şifre gerekli.";
        //        return View();
        //    }

        //    var user = await _userManager.FindByNameAsync(username);
        //    if (user == null)
        //    {
        //        ViewBag.Error = "Kullanıcı bulunamadı.";
        //        return View();
        //    }

        //    var result = await _signInManager.PasswordSignInAsync(user, password, false, false);
        //    if (!result.Succeeded)
        //    {
        //        ViewBag.Error = "Giriş başarısız.";
        //        return View();
        //    }

        //    var roles = await _userManager.GetRolesAsync(user);

        //    if (roles.Contains("Admin"))
        //        return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
        //    else if (roles.Contains("Member"))
        //        return RedirectToAction("Index", "Dashboard", new { area = "Member" });
        //    else
        //        return RedirectToAction("AccessDenied", "Account");
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = await _userManager.FindByNameAsync(model.UserName);

            if (user == null)
            {
                ViewBag.Error = "Kullanıcı bulunamadı.";
                return View(model);
            }

            var result = await _signInManager.PasswordSignInAsync(
                user,
                model.Password,
                false,
                false);

            if (!result.Succeeded)
            {
                ViewBag.Error = "Giriş başarısız.";
                return View(model);
            }

            var roles = await _userManager.GetRolesAsync(user);

            if (roles.Contains("Admin"))
                return RedirectToAction(
                    "Index",
                    "Dashboard",
                    new { area = "Admin" });

            if (roles.Contains("Member"))
                return RedirectToAction(
                    "Index",
                    "Dashboard",
                    new { area = "Member" });

            return RedirectToAction("AccessDenied", "Account");
        }

        //Register 
        [HttpGet]
        public async Task<IActionResult> Register()
        {
            var roles = await _roleManager.GetAllAsync();

            var vm = new RegisterViewModel
            {
                Roles = roles
                    .Where(x => x.Name != "Admin")
                    .ToList()
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var roles = await _roleManager.GetAllAsync();

                model.Roles = roles
                    .Where(x => x.Name != "Admin")
                    .ToList();

                return View(model);
            }

            try
            {
                // Role gerçekten mevcut mu?
                var selectedRole = await _roleManager.GetByIdAsync(model.RoleId);

                if (selectedRole == null ||
                    selectedRole.Name == "Admin")
                {
                    ModelState.AddModelError(
                        "RoleId",
                        "Geçersiz rol seçimi.");

                    var roles = await _roleManager.GetAllAsync();

                    model.Roles = roles
                        .Where(x => x.Name != "Admin")
                        .ToList();

                    return View(model);
                }


                //1.Identity AppUser oluşturma

                var appUser = await _appUserManager.CreateUserWithRoleAsync(
                    model.UserName,
                    model.Email,
                    model.Password,
                    "Member");


                //2.User Entity oluşturma

                var user = new User
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    RoleId = model.RoleId,
                    AppUserId = appUser.Id,
                    Status = DataStatus.Inserted,
                    CreatedDate = DateTime.Now
                };

                await _userManagerBLL.CreateAsync(user);


                //3.Kullanıcıya otomatik giriş yaptırma

                await _signInManager.SignInAsync(
                    appUser,
                    isPersistent: false);


                return RedirectToAction(
                    "Index",
                    "Dashboard",
                    new { area = "Member" });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(
                    string.Empty,
                    ex.Message);

                var roles = await _roleManager.GetAllAsync();

                model.Roles = roles
                    .Where(x => x.Name != "Admin")
                    .ToList();

                return View(model);
            }
        }



        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult AccessDenied() => Content("Bu alana erişim yetkiniz yok.");
    }
}

