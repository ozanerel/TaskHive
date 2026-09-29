using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TH.BLL.Managers.Abstracts;
using TH.BLL.Managers.Concretes;
using TH.BLL.Services.Abstracts;
using TH.ENTITIES.Enums;
using TH.ENTITIES.Models;
using TH.MVCUI.Areas.Admin.Models.PageVMs;
using TH.MVCUI.Areas.Admin.Models.PageVMs.TaskVM;

namespace TH.MVCUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class TaskController : Controller
    {
        private readonly ITaskManager _taskManager;
        private readonly IUserManager _userManager;
        private readonly IProjectManager _projectManager;
        private readonly ITeamManager _teamManager;
        private readonly ITeamMemberManager _teamMemberManager;
        private readonly IUserContext _userContext;
        private readonly IRoleManager _roleManager;

        public TaskController(ITaskManager taskManager, IUserManager userManager, IProjectManager projectManager,ITeamManager teamManager,ITeamMemberManager teamMemberManager,IUserContext userContext, IRoleManager roleManager)
        {
            _taskManager = taskManager;
            _userManager = userManager;
            _projectManager = projectManager;
            _teamManager = teamManager;
            _teamMemberManager = teamMemberManager;
            _userContext = userContext;
            _roleManager = roleManager;
        }
        public async Task<IActionResult> Index(string search,PriorityLevel? priority,bool? isCompleted)
        {
            var user = await _userContext.GetCurrentUserAsync();

            if (user == null)
                return NotFound();

            var adminTeams = await GetAdminTeamsAsync();

            var teamIds = adminTeams
                .Select(x => x.Id)
                .ToList();

            var tasks = await _taskManager.FilterTasksAsync(
                search,
                priority,
                isCompleted,
                teamIds);

            TaskIndexVm vm = new()
            {
                Tasks = tasks,
                Search = search,
                Priority = priority,
                IsCompleted = isCompleted
            };

            return View(vm);
        }

        public async Task<IActionResult> Details(int id)
        {
            var task = await _taskManager.GetTaskDetailsAsync(id);

            if (task == null)
                return NotFound();

            if (task.Status == DataStatus.Deleted)
                return NotFound();

            if (task.Project == null)
                return NotFound();

            var isTeamAdmin = await IsTeamAdminAsync(
                task.Project.TeamId);

            if (!isTeamAdmin)
                return Forbid();

            TaskDetailsVm vm = new()
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                Priority = task.Priority,
                DueDate = task.DueDate,
                CompletedDate = task.CompletedDate,
                IsCompleted = task.IsCompleted,

                UserName = task.User != null
                    ? task.User.FirstName + " " + task.User.LastName
                    : null,

                ProjectName = task.Project?.ProjectName,

                RequiredRoleName = task.RequiredRole?.Name,

                Comments = task.TaskComments?
                    .Where(x => x.Status != DataStatus.Deleted)
                    .ToList() ?? new()
            };

            return View(vm);
        }

        public async Task<IActionResult> Create()
        {
            var user = await _userContext.GetCurrentUserAsync();

            if (user == null)
                return NotFound();

            var adminTeams = await GetAdminTeamsAsync();

            var teamIds = adminTeams
                .Select(x => x.Id)
                .ToList();

            var allProjects = await _projectManager.GetAllAsync();

            var projects = allProjects
                .Where(x =>
                    teamIds.Contains(x.TeamId) &&
                    x.Status != DataStatus.Deleted)
                .ToList();

            var teamMemberUsers = new List<ENTITIES.Models.User>();

            foreach (var team in adminTeams)
            {
                var members = await _teamMemberManager
                    .GetTeamMembersAsync(team.Id);

                teamMemberUsers.AddRange(
                    members
                        .Where(x => x.User != null)
                        .Select(x => x.User));
            }

            var users = teamMemberUsers
                .Where(x => x.Status != DataStatus.Deleted)
                .GroupBy(x => x.Id)
                .Select(x => x.First())
                .ToList();

            var roles = _roleManager
                .GetActives()
                .OrderBy(x => x.Name)
                .ToList();

            var assignmentSuggestions =
                await _taskManager.GetTaskAssignmentSuggestionsAsync(teamIds);

            TaskCreateVm vm = new()
            {
                Users = users,
                Projects = projects,
                AssignmentSuggestions = assignmentSuggestions,
                Roles = roles
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TaskCreateVm vm)
        {
            if (!ModelState.IsValid)
            {
                return View(await PrepareCreateVmAsync(vm));
            }

            var project = await _projectManager.GetByIdAsync(vm.ProjectId);

            if (project == null)
                return NotFound();

            if (project.Status == DataStatus.Deleted)
                return NotFound();

            var isTeamAdmin = await IsTeamAdminAsync(
                project.TeamId);

            if (!isTeamAdmin)
                return Forbid();

            var teamMember = await _teamMemberManager.GetTeamMemberAsync(
                project.TeamId,
                vm.UserId);

            if (teamMember == null)
                return Forbid();

            // Atanacak kullanıcının rolünü kontrol et.
            var assignedUser = await _userManager.GetByIdAsync(vm.UserId);

            if (assignedUser == null)
            {
                return NotFound();
            }

            if (vm.RequiredRoleId.HasValue &&
                assignedUser.RoleId != vm.RequiredRoleId.Value)
            {
                ModelState.AddModelError(
                    nameof(vm.UserId),
                    "Seçilen kullanıcının rolü, görevin gerekli rolüyle uyuşmuyor.");

                return View(await PrepareCreateVmAsync(vm));
            }

            ENTITIES.Models.Task task = new()
            {
                Title = vm.Title,
                Description = vm.Description,
                Priority = vm.Priority,
                DueDate = vm.DueDate,
                UserId = vm.UserId,
                ProjectId = vm.ProjectId,
                RequiredRoleId = vm.RequiredRoleId
            };

            await _taskManager.CreateAsync(task);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> GetAssignmentSuggestions(int projectId,int? requiredRoleId)
        {
            var project = await _projectManager.GetByIdAsync(projectId);

            if (project == null)
                return NotFound();

            if (project.Status == DataStatus.Deleted)
                return NotFound();

            if (!await IsTeamAdminAsync(project.TeamId))
                return Forbid();

            var teamMembers = await _teamMemberManager
                .GetTeamMembersAsync(project.TeamId);

            var users = teamMembers
                .Where(x =>
                    x.User != null &&
                    x.User.Status != DataStatus.Deleted)
                .Where(x =>
                    !requiredRoleId.HasValue ||
                    x.User.RoleId == requiredRoleId.Value)
                .Select(x => new
                {
                    id = x.User.Id,
                    name = $"{x.User.FirstName} {x.User.LastName}".Trim(),
                    roleId = x.User.RoleId
                })
                .ToList();

            var suggestions = await _taskManager.GetTaskAssignmentSuggestionsByTeamAsync(project.TeamId,requiredRoleId);

            return Json(new
            {
                users,
                suggestions
            });
        }

        public async Task<IActionResult> Edit(int id)
        {
            var task = await _taskManager
                .GetTaskDetailsAsync(id);

            if (task == null)
                return NotFound();

            if (task.Status == DataStatus.Deleted)
                return NotFound();

            if (task.Project == null)
                return NotFound();

            if (!await IsTeamAdminAsync(task.Project.TeamId))
                return Forbid();

            var adminTeams = await GetAdminTeamsAsync();

            var teamIds = adminTeams
                .Select(x => x.Id)
                .ToList();

            var projects = await _projectManager
                .GetAllAsync();

            projects = projects
                .Where(x =>
                    teamIds.Contains(x.TeamId) &&
                    x.Status != DataStatus.Deleted)
                .ToList();

            var users = new List<TH.ENTITIES.Models.User>();

            foreach (var team in adminTeams)
            {
                var members = await _teamMemberManager
                    .GetTeamMembersAsync(team.Id);

                users.AddRange(
                    members
                        .Where(x => x.User != null)
                        .Select(x => x.User));
            }

            users = users
                .Where(x => x.Status != DataStatus.Deleted)
                .GroupBy(x => x.Id)
                .Select(x => x.First())
                .ToList();

            var roles = _roleManager
                .GetActives()
                .OrderBy(x => x.Name)
                .ToList();

            TaskUpdateVm vm = new()
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                Priority = task.Priority,
                DueDate = task.DueDate,
                UserId = task.UserId,
                ProjectId = task.ProjectId,
                RequiredRoleId = task.RequiredRoleId,
                IsCompleted = task.IsCompleted,
                Users = users,
                Projects = projects,
                Roles = roles
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TaskUpdateVm vm)
        {
            var task = await _taskManager
                .GetTaskDetailsAsync(vm.Id);

            if (task == null)
                return NotFound();

            if (task.Status == DataStatus.Deleted)
                return NotFound();

            if (task.Project == null)
                return NotFound();

            // Mevcut task'ın Team'inde Admin mi?
            if (!await IsTeamAdminAsync(task.Project.TeamId))
                return Forbid();

            var newProject = await _projectManager
                .GetByIdAsync(vm.ProjectId);

            if (newProject == null)
                return NotFound();

            if (newProject.Status == DataStatus.Deleted)
                return NotFound();

            // Yeni Project'in Team'inde Admin mi?
            if (!await IsTeamAdminAsync(newProject.TeamId))
                return Forbid();

            // Atanmak istenen kullanıcı yeni Team'in üyesi mi?
            var teamMember = await _teamMemberManager
                .GetTeamMemberAsync(
                    newProject.TeamId,
                    vm.UserId);

            if (teamMember == null)
                return BadRequest();

            // Atanacak kullanıcının rolünü kontrol et
            var assignedUser = await _userManager
                .GetByIdAsync(vm.UserId);

            if (assignedUser == null)
                return NotFound();

            if (vm.RequiredRoleId.HasValue &&
                assignedUser.RoleId != vm.RequiredRoleId.Value)
            {
                ModelState.AddModelError(
                    nameof(vm.UserId),
                    "Seçilen kullanıcının rolü, görevin gerekli rolüyle uyuşmuyor.");
            }

            if (!ModelState.IsValid)
            {
                var adminTeams = await GetAdminTeamsAsync();

                var teamIds = adminTeams
                    .Select(x => x.Id)
                    .ToList();

                var projects = await _projectManager
                    .GetAllAsync();

                projects = projects
                    .Where(x =>
                        teamIds.Contains(x.TeamId) &&
                        x.Status != DataStatus.Deleted)
                    .ToList();

                var users = new List<TH.ENTITIES.Models.User>();

                foreach (var team in adminTeams)
                {
                    var members = await _teamMemberManager
                        .GetTeamMembersAsync(team.Id);

                    users.AddRange(
                        members
                            .Where(x => x.User != null)
                            .Select(x => x.User));
                }

                vm.Users = users
                    .Where(x => x.Status != DataStatus.Deleted)
                    .GroupBy(x => x.Id)
                    .Select(x => x.First())
                    .ToList();

                vm.Projects = projects;

                vm.Roles = _roleManager
                    .GetActives()
                    .OrderBy(x => x.Name)
                    .ToList();

                return View(vm);
            }

            task.Title = vm.Title;
            task.Description = vm.Description;
            task.Priority = vm.Priority;
            task.DueDate = vm.DueDate;
            task.UserId = vm.UserId;
            task.ProjectId = vm.ProjectId;
            task.RequiredRoleId = vm.RequiredRoleId;
            task.IsCompleted = vm.IsCompleted;

            await _taskManager.UpdateAsync(task);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var task = await _taskManager.GetTaskDetailsAsync(id);

            if (task == null)
                return NotFound();

            if (task.Status == DataStatus.Deleted)
                return NotFound();

            if (task.Project == null)
                return NotFound();

            if (!await IsTeamAdminAsync(task.Project.TeamId))
                return Forbid();

            TaskDeleteVm vm = new()
            {
                Id = task.Id,
                Title = task.Title,
                UserName = task.User?.FirstName,
                ProjectName = task.Project?.ProjectName,
                IsCompleted = task.IsCompleted
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(TaskDeleteVm vm)
        {
            var task = await _taskManager.GetTaskDetailsAsync(vm.Id);

            if (task == null)
                return NotFound();

            if (task.Status == DataStatus.Deleted)
                return NotFound();

            if (task.Project == null)
                return NotFound();

            if (!await IsTeamAdminAsync(task.Project.TeamId))
                return Forbid();

            await _taskManager.MakePassiveAsync(task);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CompleteTask(int id)
        {
            var user = await _userContext.GetCurrentUserAsync();

            if (user == null)
                return Unauthorized();

            var task = await _taskManager.GetTaskDetailsAsync(id);

            if (task == null)
                return NotFound();

            if (task.Status == DataStatus.Deleted)
                return NotFound();

            if (task.Project == null)
                return NotFound();

            if (!await IsTeamAdminAsync(task.Project.TeamId))
                return Forbid();

            await _taskManager.CompleteTaskAsync(id, task.UserId);

            return RedirectToAction(nameof(Index));
        }

        private async Task<List<Team>> GetAdminTeamsAsync()
        {
            var user = await _userContext.GetCurrentUserAsync();

            if (user == null)
                return new List<Team>();

            var teams = await _teamManager.GetTeamsByUserAsync(user.Id);

            var adminTeams = new List<Team>();

            foreach (var team in teams)
            {
                var teamMember = await _teamMemberManager.GetTeamMemberAsync(
                    team.Id,
                    user.Id);

                if (teamMember != null &&
                    teamMember.TeamRole == TeamRole.Admin &&
                    teamMember.Status != DataStatus.Deleted)
                {
                    adminTeams.Add(team);
                }
            }

            return adminTeams;
        }

        private async Task<bool> IsTeamAdminAsync(int teamId)
        {
            var user = await _userContext.GetCurrentUserAsync();

            if (user == null)
                return false;

            var teamMember = await _teamMemberManager.GetTeamMemberAsync(
                teamId,
                user.Id);

            return teamMember != null &&
                   teamMember.TeamRole == TeamRole.Admin &&
                   teamMember.Status != DataStatus.Deleted;
        }

        //Create Vm'i tekrar doldurmak için kullanılan yardımcı metod
        private async Task<TaskCreateVm> PrepareCreateVmAsync(TaskCreateVm vm)
        {
            var adminTeams = await GetAdminTeamsAsync();

            var teamIds = adminTeams
                .Select(x => x.Id)
                .ToList();

            var allProjects = await _projectManager.GetAllAsync();

            vm.Projects = allProjects
                .Where(x =>
                    teamIds.Contains(x.TeamId) &&
                    x.Status != DataStatus.Deleted)
                .ToList();

            vm.Roles = _roleManager
                .GetActives()
                .OrderBy(x => x.Name)
                .ToList();


            // Project seçilmişse sadece o Project'in
            // bağlı olduğu Team üzerinden kullanıcıları getir.
            if (vm.ProjectId > 0)
            {
                var project = allProjects
                    .FirstOrDefault(x =>
                        x.Id == vm.ProjectId &&
                        x.Status != DataStatus.Deleted);

                if (project != null &&
                    teamIds.Contains(project.TeamId))
                {
                    var teamMembers =
                        await _teamMemberManager
                            .GetTeamMembersAsync(project.TeamId);

                    vm.Users = teamMembers
                        .Where(x =>
                            x.User != null &&
                            x.User.Status != DataStatus.Deleted)
                        .Select(x => x.User)
                        .GroupBy(x => x.Id)
                        .Select(x => x.First())
                        .ToList();

                    vm.AssignmentSuggestions =
                        await _taskManager
                            .GetTaskAssignmentSuggestionsByTeamAsync(
                                project.TeamId,vm.RequiredRoleId);

                    return vm;
                }
            }


            // Henüz Project seçilmemişse Admin'in yönettiği
            // takımların üyelerini getir.
            var teamMemberUsers =
                new List<ENTITIES.Models.User>();

            foreach (var team in adminTeams)
            {
                var members =
                    await _teamMemberManager
                        .GetTeamMembersAsync(team.Id);

                teamMemberUsers.AddRange(
                    members
                        .Where(x =>
                            x.User != null &&
                            x.User.Status != DataStatus.Deleted)
                        .Select(x => x.User));
            }

            vm.Users = teamMemberUsers
                .GroupBy(x => x.Id)
                .Select(x => x.First())
                .ToList();

            vm.AssignmentSuggestions =
                await _taskManager
                    .GetTaskAssignmentSuggestionsAsync(teamIds);

            return vm;
        }
    }
}
