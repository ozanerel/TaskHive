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

            var isMember = await _teamMemberManager
                .IsUserInTeamAsync(id, user.Id);

            if (!isMember)
                return Forbid();

            var team = await _teamManager.GetTeamDetailsAsync(id);

            if (team == null)
                return NotFound();

            var model = new TeamDetailsViewModel
            {
                Id = team.Id,
                Name = team.Name,
                Description = team.Description,

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
    }
}