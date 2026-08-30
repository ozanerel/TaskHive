using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TH.BLL.Managers.Abstracts;
using TH.ENTITIES.Enums;
using TH.ENTITIES.Models;
using TH.MVCUI.Models.ViewModels.TeamViewModels;

namespace TH.MVCUI.Controllers
{
    [Authorize]
    public class TeamController : Controller
    {
        private readonly ITeamManager _teamManager;
        private readonly ITeamMemberManager _teamMemberManager;
        private readonly UserManager<AppUser> _identityUserManager;
        private readonly IUserManager _userManager;

        public TeamController(
            ITeamManager teamManager,
            ITeamMemberManager teamMemberManager,
            UserManager<AppUser> identityUserManager,
            IUserManager userManager)
        {
            _teamManager = teamManager;
            _teamMemberManager = teamMemberManager;
            _identityUserManager = identityUserManager;
            _userManager = userManager;
        }

        // GET: /Team
        public async Task<IActionResult> Index()
        {
            var appUser = await _identityUserManager.GetUserAsync(User);

            if (appUser == null)
                return RedirectToAction("Login", "Account");

            var user = await _userManager.GetByAppUserIdAsync(appUser.Id);

            if (user == null)
                return NotFound();

            // GEÇİCİ TEST
            Console.WriteLine($"AppUser.Id = {appUser.Id}");
            Console.WriteLine($"User.Id = {user.Id}");
            Console.WriteLine($"User.AppUserId = {user.AppUserId}");

            var teams = await _teamManager.GetTeamsByUserAsync(user.Id);

            var model = teams.Select(team => new TeamListViewModel
            {
                Id = team.Id,
                Name = team.Name,
                Description = team.Description,
                MemberCount = team.TeamMembers?.Count ?? 0,
                ProjectCount = team.Projects?.Count ?? 0
            }).ToList();

            return View(model);
        }

        // GET: /Team/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Team/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TeamCreateViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var appUser = await _identityUserManager.GetUserAsync(User);

            if (appUser == null)
                return RedirectToAction("Login", "Account");

            var user = await _userManager.GetByAppUserIdAsync(appUser.Id);

            if (user == null)
                return NotFound();

            var team = new Team
            {
                Name = model.Name,
                Description = model.Description
            };

            await _teamManager.CreateAsync(team);

            var teamMember = new TeamMember
            {
                TeamId = team.Id,
                UserId = user.Id,
                TeamRole = TeamRole.Admin
            };

            await _teamMemberManager.CreateAsync(teamMember);

            TempData["Success"] = "Takım başarıyla oluşturuldu.";

            return RedirectToAction(nameof(Details), new { id = team.Id });
        }

        // GET: /Team/Details/5
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var appUser = await _identityUserManager.GetUserAsync(User);

            if (appUser == null)
                return RedirectToAction("Login", "Account");

            var user = await _userManager.GetByAppUserIdAsync(appUser.Id);

            if (user == null)
                return NotFound();

            //var isMember = await _teamMemberManager
            //    .IsUserInTeamAsync(id, user.Id);

            //if (!isMember)
            //    return Forbid();

            var currentMember = await _teamMemberManager
                .GetTeamMemberAsync(id, user.Id);

            if (currentMember == null)
                return Forbid();

            var team = await _teamManager.GetTeamDetailsAsync(id);

            if (team == null)
                return NotFound();

            if (team.Status == DataStatus.Deleted)
                return NotFound();

            var model = new TeamDetailsViewModel
            {
                Id = team.Id,
                Name = team.Name,
                Description = team.Description,
                IsAdmin = currentMember.TeamRole == TeamRole.Admin,

                Members = team.TeamMembers?
                    .Select(x => new TeamMemberViewModel
                    {
                        UserId = x.UserId,
                        FirstName = x.User.FirstName,
                        LastName = x.User.LastName,
                        Email = x.User.Email,
                        RoleName = x.User.Role?.Name,
                        TeamRole = x.TeamRole
                    })
                    .ToList() ?? new List<TeamMemberViewModel>(),

                Projects = team.Projects?
                    .Select(x => new TeamProjectViewModel
                    {
                        Id = x.Id,
                        ProjectName = x.ProjectName,
                        Description = x.Description,
                        TaskCount = x.Tasks?.Count ?? 0
                    })
                    .ToList() ?? new List<TeamProjectViewModel>()
            };

            return View(model);
        }

        // GET: /Team/AddMember/5
        [HttpGet]
        public async Task<IActionResult> AddMember(int id)
        {
            var appUser = await _identityUserManager.GetUserAsync(User);

            if (appUser == null)
                return RedirectToAction("Login", "Account");

            var user = await _userManager.GetByAppUserIdAsync(appUser.Id);

            if (user == null)
                return NotFound();

            var teamMember = await _teamMemberManager
                .GetTeamMemberAsync(id, user.Id);

            if (teamMember == null || teamMember.TeamRole != TeamRole.Admin)
                return Forbid();

            var team = await _teamManager.GetByIdAsync(id);

            if (team == null)
                return NotFound();

            var users =
                await _userManager.GetAvailableUsersForTeamAsync(id);

            var model = new TeamAddMemberViewModel
            {
                TeamId = team.Id,
                TeamName = team.Name,

                Users = users.Select(x => new TeamUserSelectViewModel
                {
                    Id = x.Id,
                    FullName = $"{x.FirstName} {x.LastName}",
                    Email = x.Email
                }).ToList()
            };

            return View(model);
        }

        // POST: /Team/AddMember
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddMember(
            TeamAddMemberViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var appUser = await _identityUserManager.GetUserAsync(User);

            if (appUser == null)
                return RedirectToAction("Login", "Account");

            var currentUser = await _userManager
                .GetByAppUserIdAsync(appUser.Id);

            if (currentUser == null)
                return NotFound();

            var currentMember = await _teamMemberManager
                .GetTeamMemberAsync(
                    model.TeamId,
                    currentUser.Id);

            if (currentMember == null ||
                currentMember.TeamRole != TeamRole.Admin)
            {
                return Forbid();
            }

            var team = await _teamManager
                .GetByIdAsync(model.TeamId);

            if (team == null)
                return NotFound();

            //var existingMember = await _teamMemberManager
            //    .GetTeamMemberAsync(
            //        model.TeamId,
            //        model.UserId);

            //if (existingMember != null &&
            //    existingMember.Status != DataStatus.Deleted)
            //{
            //    ModelState.AddModelError(
            //        "UserId",
            //        "Bu kullanıcı zaten takımın üyesi."
            //    );

            //    model.TeamName = team.Name;

            //    return View(model);
            //}

            var existingMember = await _teamMemberManager.GetTeamMemberIncludingDeletedAsync(model.TeamId, model.UserId);

            if (existingMember != null)
            {
                if (existingMember.Status != DataStatus.Deleted)
                {
                    ModelState.AddModelError(
                        "UserId",
                        "Bu kullanıcı zaten takımın üyesi."
                    );

                    model.TeamName = team.Name;

                    return View(model);
                }

                existingMember.Status = DataStatus.Inserted;
                existingMember.TeamRole = TeamRole.Member;

                await _teamMemberManager.UpdateAsync(existingMember);

                TempData["Success"] =
                    "Kullanıcı tekrar takıma başarıyla eklendi.";

                return RedirectToAction(
                    nameof(Details),
                    new { id = model.TeamId });
            }

            var teamMember = new TeamMember
            {
                TeamId = model.TeamId,
                UserId = model.UserId,
                TeamRole = TeamRole.Member
            };

            await _teamMemberManager.CreateAsync(teamMember);

            TempData["Success"] =
                "Kullanıcı takıma başarıyla eklendi.";

            return RedirectToAction(
                nameof(Details),
                new { id = model.TeamId });
        }

        // POST: /Team/RemoveMember
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveMember(
            int teamId,
            int userId)
        {
            var appUser = await _identityUserManager.GetUserAsync(User);

            if (appUser == null)
                return RedirectToAction("Login", "Account");

            var currentUser = await _userManager
                .GetByAppUserIdAsync(appUser.Id);

            if (currentUser == null)
                return NotFound();

            var currentMember = await _teamMemberManager
                .GetTeamMemberAsync(teamId, currentUser.Id);

            if (currentMember == null ||
                currentMember.TeamRole != TeamRole.Admin)
            {
                return Forbid();
            }

            var team = await _teamManager.GetByIdAsync(teamId);

            if (team == null)
                return NotFound();

            var memberToRemove = await _teamMemberManager
                .GetTeamMemberAsync(teamId, userId);

            if (memberToRemove == null)
                return NotFound();

            // Admin kendisini takımdan çıkaramasın
            if (memberToRemove.UserId == currentUser.Id)
            {
                TempData["Error"] =
                    "Takım yöneticisi kendisini takımdan çıkaramaz.";

                return RedirectToAction(
                    nameof(Details),
                    new { id = teamId });
            }

            await _teamMemberManager.RemoveMemberAsync(teamId, userId);

            TempData["Success"] =
                "Kullanıcı takımdan başarıyla çıkarıldı.";

            return RedirectToAction(
                nameof(Details),
                new { id = teamId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangeRole(TeamChangeRoleViewModel model)
        {
            var appUser = await _identityUserManager.GetUserAsync(User);

            if (appUser == null)
                return RedirectToAction("Login", "Account");

            var currentUser = await _userManager
                .GetByAppUserIdAsync(appUser.Id);

            if (currentUser == null)
                return NotFound();

            var currentMember = await _teamMemberManager
                .GetTeamMemberAsync(
                    model.TeamId,
                    currentUser.Id);

            //Burada yaptığımız işlem ile normal Member bu endpoint'i manuel olarak çağırsa bile rol değiştiremez
            if (currentMember == null ||
                currentMember.TeamRole != TeamRole.Admin)
            {
                return Forbid();
            }

            var targetMember = await _teamMemberManager
                .GetTeamMemberAsync(
                    model.TeamId,
                    model.UserId);

            if (targetMember == null)
                return NotFound();

            // Son Admin'in yetkisini kaldırmayı engelle
            if (targetMember.TeamRole == TeamRole.Admin &&
                model.TeamRole == TeamRole.Member)
            {
                var adminCount = await _teamMemberManager
                    .GetAdminCountAsync(model.TeamId);

                if (adminCount <= 1)
                {
                    TempData["Error"] =
                        "Takımda en az bir Admin bulunmalıdır.";

                    return RedirectToAction(
                        nameof(Details),
                        new { id = model.TeamId });
                }
            }

            await _teamMemberManager.UpdateTeamRoleAsync(
                model.TeamId,
                model.UserId,
                model.TeamRole);

            TempData["Success"] =
                "Takım üyesinin rolü başarıyla güncellendi.";

            return RedirectToAction(
                nameof(Details),
                new { id = model.TeamId });
        }

        // GET:
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var appUser = await _identityUserManager.GetUserAsync(User);

            if (appUser == null)
                return RedirectToAction("Login", "Account");

            var currentUser = await _userManager
                .GetByAppUserIdAsync(appUser.Id);

            if (currentUser == null)
                return NotFound();

            var currentMember = await _teamMemberManager
                .GetTeamMemberAsync(id, currentUser.Id);

            if (currentMember == null ||
                currentMember.TeamRole != TeamRole.Admin)
            {
                return Forbid();
            }

            var team = await _teamManager.GetByIdAsync(id);

            if (team == null)
                return NotFound();

            var model = new TeamEditViewModel
            {
                Id = team.Id,
                Name = team.Name,
                Description = team.Description
            };

            return View(model);
        }

        // POST:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TeamEditViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var appUser = await _identityUserManager.GetUserAsync(User);

            if (appUser == null)
                return RedirectToAction("Login", "Account");

            var currentUser = await _userManager
                .GetByAppUserIdAsync(appUser.Id);

            if (currentUser == null)
                return NotFound();

            var currentMember = await _teamMemberManager
                .GetTeamMemberAsync(model.Id, currentUser.Id);

            if (currentMember == null ||
                currentMember.TeamRole != TeamRole.Admin)
            {
                return Forbid();
            }

            var team = await _teamManager.GetByIdAsync(model.Id);

            if (team == null)
                return NotFound();

            team.Name = model.Name;
            team.Description = model.Description;

            await _teamManager.UpdateAsync(team);

            TempData["Success"] =
                "Takım bilgileri başarıyla güncellendi.";

            return RedirectToAction(
                nameof(Details),
                new { id = team.Id });
        }

        // POST: 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var appUser = await _identityUserManager.GetUserAsync(User);

            if (appUser == null)
                return RedirectToAction("Login", "Account");

            var currentUser = await _userManager
                .GetByAppUserIdAsync(appUser.Id);

            if (currentUser == null)
                return NotFound();

            var currentMember = await _teamMemberManager
                .GetTeamMemberAsync(id, currentUser.Id);

            // Sadece takım Admin'i takımı silebilir
            if (currentMember == null ||
                currentMember.TeamRole != TeamRole.Admin)
            {
                return Forbid();
            }

            var team = await _teamManager.GetByIdAsync(id);

            if (team == null)
                return NotFound();

            await _teamManager.MakePassiveAsync(team);

            TempData["Success"] =
                "Takım başarıyla silindi.";

            return RedirectToAction(nameof(Index));
        }
    }
}