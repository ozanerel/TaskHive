using Microsoft.AspNetCore.Mvc;
using TH.BLL.Managers.Abstracts;
using Microsoft.AspNetCore.Authorization;
using TH.ENTITIES.Models;
using TH.MVCUI.Areas.Admin.Models.PageVMs.ProjectVM;
using TH.ENTITIES.Enums;
using Microsoft.AspNetCore.Identity;

namespace TH.MVCUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ProjectController : Controller
    {
        private readonly IProjectManager _projectManager;
        private readonly IUserManager _userManager;
        private readonly INotificationManager _notificationManager;
        private readonly ITeamManager _teamManager;
        private readonly ITeamMemberManager _teamMemberManager;
        private readonly UserManager<AppUser> _identityUserManager;

        public ProjectController(IProjectManager projectManager, IUserManager userManager,INotificationManager notificationManager,ITeamManager teamManager,ITeamMemberManager teamMemberManager,UserManager<AppUser> identityUserManager)
        {
            _projectManager = projectManager;
            _userManager = userManager;
            _notificationManager = notificationManager;
            _teamManager = teamManager;
            _teamMemberManager = teamMemberManager;
            _identityUserManager = identityUserManager;
        }

        // Proje Listesi
        public async Task<IActionResult> Index(string search,DataStatus? status,string sortBy)
        {
            var projects = await _projectManager.FilterProjectsAsync(search,status,sortBy);

            ProjectIndexVm vm = new()
            {
                Projects = projects,
                Search = search,
                //Status = status?.ToString(),
                Status = status,
                SortBy = sortBy
            };

            return View(vm);
        }

        // Proje Detayı
        public async Task<IActionResult> Details(int id)
        {
            var currentUser = await GetCurrentUserAsync();

            if (currentUser == null)
                return NotFound();

            var project = await _projectManager.GetProjectDetailsAsync(id);

            if (project == null)
                return NotFound();

            if (project.Status == DataStatus.Deleted)
                return NotFound();

            var isTeamAdmin = await IsTeamAdminAsync(
                project.TeamId,
                currentUser.Id);

            if (!isTeamAdmin)
                return Forbid();


            ProjectDetailsVm vm = new ProjectDetailsVm
            {
                Id = project.Id,
                ProjectName = project.ProjectName,
                Description = project.Description,
                TeamId = project.TeamId,
                TeamName = project.Team?.Name,
                Tasks = project.Tasks?.ToList() ?? new(),
                Users = project.Users?.ToList() ?? new(),
                CreatedDate = project.CreatedDate,
                Status = project.Status
            };

            return View(vm);
        }

        // GET
        public async Task<IActionResult> Create()
        {
            var appUser = await _identityUserManager.GetUserAsync(User);

            if (appUser == null)
                return RedirectToAction("Login", "Account", new { area = "" });

            var currentUser = await _userManager.GetByAppUserIdAsync(appUser.Id);

            if (currentUser == null)
                return NotFound();

            var teams = await _teamManager.GetTeamsByUserAsync(currentUser.Id);

            var adminTeams = new List<Team>();

            foreach (var team in teams)
            {
                var teamMember = await _teamMemberManager.GetTeamMemberAsync(
                    team.Id,
                    currentUser.Id);

                if (teamMember != null &&
                    teamMember.TeamRole == TeamRole.Admin)
                {
                    adminTeams.Add(team);
                }
            }

            ProjectCreateVm vm = new()
            {
                Users = await _userManager.GetAllAsync(),
                Teams = await GetAdminTeamsAsync()
            };
            //vm.Project = new Project(); // Initialize the Project property

            return View(vm);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProjectCreateVm vm)
        {
            if (!ModelState.IsValid)
            {
                vm.Users = await _userManager.GetAllAsync();
                vm.Teams = await GetAdminTeamsAsync();

                return View(vm);
            }

            //var appUser = await _identityUserManager.GetUserAsync(User);

            //if (appUser == null)
            //    return RedirectToAction("Login", "Account", new { area = "" });

            //var currentUser = await _userManager.GetByAppUserIdAsync(appUser.Id);

            //if (currentUser == null)
            //    return NotFound();

            //var currentMember = await _teamMemberManager.GetTeamMemberAsync(
            //    vm.TeamId,
            //    currentUser.Id);

            //if (currentMember == null ||
            //    currentMember.TeamRole != TeamRole.Admin)
            //{
            //    return Forbid();
            //}

            //Sadeleştirilmiş hali
            var currentUser = await GetCurrentUserAsync();

            if (currentUser == null)
                return NotFound();

            var isTeamAdmin = await IsTeamAdminAsync(
                vm.TeamId,
                currentUser.Id);

            if (!isTeamAdmin)
                return Forbid();

            var team = await _teamManager.GetByIdAsync(vm.TeamId);

            if (team == null ||
                team.Status == DataStatus.Deleted)
            {
                return NotFound();
            }

            Project project = new Project
            {
                ProjectName = vm.ProjectName,
                Description = vm.Description,
                TeamId = vm.TeamId,
                Users = new List<User>()
            };

            foreach (var id in vm.UserIds)
            {
                var user = await _userManager.GetByIdAsync(id);

                if (user != null)
                    project.Users.Add(user);
            }

            await _projectManager.CreateAsync(project);

            return RedirectToAction(nameof(Index));

        }

        // GET
        public async Task<IActionResult> Update(int id)
        {
            var currentUser = await GetCurrentUserAsync();

            if (currentUser == null)
                return NotFound();

            var project = await _projectManager.GetProjectDetailsAsync(id);

            if (project == null)
                return NotFound();

            if (project.Status == DataStatus.Deleted)
                return NotFound();

            var isTeamAdmin = await IsTeamAdminAsync(
                project.TeamId,
                currentUser.Id);

            if (!isTeamAdmin)
                return Forbid();

            ProjectUpdateVm vm = new()
            {
                Id = project.Id,
                ProjectName = project.ProjectName,
                Description = project.Description,
                TeamId = project.TeamId,
                UserIds = project.Users.Select(x => x.Id).ToList(),
                Users = await _userManager.GetAllAsync()
            };

            return View(vm);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(ProjectUpdateVm vm)
        {

            var currentUser = await GetCurrentUserAsync();

            if (currentUser == null)
                return NotFound();

            var project = await _projectManager.GetProjectDetailsAsync(vm.Id);

            if (project == null)
                return NotFound();

            if (project.Status == DataStatus.Deleted)
                return NotFound();

            var isTeamAdmin = await IsTeamAdminAsync(
                project.TeamId,
                currentUser.Id);

            if (!isTeamAdmin)
                return Forbid();

            project.ProjectName = vm.ProjectName;
            project.Description = vm.Description;

            var oldUsers = project.Users.ToList();

            // Önce mevcut kullanıcıları temizle
            project.Users.Clear();

            // Yeni seçilen kullanıcıları ekle
            foreach (var userId in vm.UserIds)
            {
                var user = await _userManager.GetByIdAsync(userId);

                if (user != null)
                {
                    project.Users.Add(user);
                }
            }

            //Eklenen kullanıcıları bulma
            var addedUsers = project.Users
                .Where(x => !oldUsers.Any(y => y.Id == x.Id))
                .ToList();

            //Çıkarılan kullanıcıları bulma 
            var removedUsers = oldUsers
                .Where(x => !project.Users.Any(y => y.Id == x.Id))
                .ToList();

            foreach (var user in addedUsers)
            {
                await _notificationManager.CreateNotificationAsync(
                    user.Id,
                    "Project Updated",
                    $"You have been added to project '{project.ProjectName}'.",
                    NotificationType.ProjectUpdated
                );
            }

            foreach (var user in removedUsers)
            {
                await _notificationManager.CreateNotificationAsync(
                    user.Id,
                    "Project Updated",
                    $"You have been removed from project '{project.ProjectName}'.",
                    NotificationType.ProjectUpdated
                );
            }


            await _projectManager.UpdateAsync(project);

            return RedirectToAction(nameof(Index));
        }

        // GET
        public async Task<IActionResult> Delete(int id)
        {
            var currentUser = await GetCurrentUserAsync();

            if (currentUser == null)
                return NotFound();

            var project = await _projectManager.GetByIdAsync(id);

            if (project == null)
                return NotFound();

            if (project.Status == DataStatus.Deleted)
                return NotFound();

            var isTeamAdmin = await IsTeamAdminAsync(
                project.TeamId,
                currentUser.Id);

            if (!isTeamAdmin)
                return Forbid();

            ProjectDeleteVm vm = new ProjectDeleteVm
            {
                Id = project.Id,
                ProjectName = project.ProjectName,
                Description = project.Description
            };

            return View(vm);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(ProjectDeleteVm vm)
        {
            var currentUser = await GetCurrentUserAsync();

            if (currentUser == null)
                return NotFound();

            var project = await _projectManager.GetProjectDetailsAsync(vm.Id);

            if (project == null)
                return NotFound();

            if (project.Status == DataStatus.Deleted)
                return NotFound();

            var isTeamAdmin = await IsTeamAdminAsync(
                project.TeamId,
                currentUser.Id);

            if (!isTeamAdmin)
                return Forbid();

            await _projectManager.MakePassiveAsync(project);

            return RedirectToAction(nameof(Index));
        }

        private async Task<List<Team>> GetAdminTeamsAsync()
        {
            var appUser = await _identityUserManager.GetUserAsync(User);

            if (appUser == null)
                return new List<Team>();

            var currentUser = await _userManager.GetByAppUserIdAsync(appUser.Id);

            if (currentUser == null)
                return new List<Team>();

            var teams = await _teamManager.GetTeamsByUserAsync(currentUser.Id);

            var adminTeams = new List<Team>();

            foreach (var team in teams)
            {
                var teamMember = await _teamMemberManager.GetTeamMemberAsync(
                    team.Id,
                    currentUser.Id);

                if (teamMember != null &&
                    teamMember.TeamRole == TeamRole.Admin)
                {
                    adminTeams.Add(team);
                }
            }

            return adminTeams;
        }

        //Ortak Team Admin kontrolü için kullanılabilir
        private async Task<User> GetCurrentUserAsync()
        {
            var appUser = await _identityUserManager.GetUserAsync(User);

            if (appUser == null)
                return null;

            return await _userManager.GetByAppUserIdAsync(appUser.Id);
        }

        private async Task<bool> IsTeamAdminAsync(int teamId, int userId)
        {
            var teamMember = await _teamMemberManager.GetTeamMemberAsync(
                teamId,
                userId);

            return teamMember != null &&
                   teamMember.TeamRole == TeamRole.Admin &&
                   teamMember.Status != DataStatus.Deleted;
        }
    }
}