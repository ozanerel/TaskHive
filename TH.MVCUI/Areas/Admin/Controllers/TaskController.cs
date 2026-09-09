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

        public TaskController(ITaskManager taskManager, IUserManager userManager, IProjectManager projectManager,ITeamManager teamManager,ITeamMemberManager teamMemberManager,IUserContext userContext)
        {
            _taskManager = taskManager;
            _userManager = userManager;
            _projectManager = projectManager;
            _teamManager = teamManager;
            _teamMemberManager = teamMemberManager;
            _userContext = userContext;
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
                IsCompleted = task.IsCompleted,
                UserName = task.User?.FirstName,
                ProjectName = task.Project?.ProjectName,
                Comments = task.TaskComments?.Where(x => x.Status != DataStatus.Deleted).ToList() ?? new()
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
                .GroupBy(x => x.Id)
                .Select(x => x.First())
                .ToList();

            TaskCreateVm vm = new()
            {
                Users = users,
                Projects = projects
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

            ENTITIES.Models.Task task = new()
            {
                Title = vm.Title,
                Description = vm.Description,
                Priority = vm.Priority,
                UserId = vm.UserId,
                ProjectId = vm.ProjectId
            };

            await _taskManager.CreateAsync(task);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
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

            var adminTeams = await GetAdminTeamsAsync();

            var teamIds = adminTeams
                .Select(x => x.Id)
                .ToList();

            var projects = await _projectManager.GetAllAsync();

            projects = projects
                .Where(x =>
                    teamIds.Contains(x.TeamId) &&
                    x.Status != DataStatus.Deleted)
                .ToList();

            var users = new List<TH.ENTITIES.Models.User>();

            foreach (var team in adminTeams)
            {
                var members = await _teamMemberManager.GetTeamMembersAsync(team.Id);

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

            TaskUpdateVm vm = new()
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                Priority = task.Priority,
                UserId = task.UserId,
                ProjectId = task.ProjectId,
                IsCompleted = task.IsCompleted,
                Users = users,
                Projects = projects
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TaskUpdateVm vm)
        {
            var task = await _taskManager.GetTaskDetailsAsync(vm.Id);

            if (task == null)
                return NotFound();

            if (task.Status == DataStatus.Deleted)
                return NotFound();

            if (task.Project == null)
                return NotFound();

            // Mevcut task'ın Team'inde Admin mi?
            if (!await IsTeamAdminAsync(task.Project.TeamId))
                return Forbid();

            var newProject = await _projectManager.GetByIdAsync(vm.ProjectId);

            if (newProject == null)
                return NotFound();

            if (newProject.Status == DataStatus.Deleted)
                return NotFound();

            // Yeni Project'in Team'inde Admin mi?
            if (!await IsTeamAdminAsync(newProject.TeamId))
                return Forbid();

            // Atanmak istenen kullanıcı yeni Team'in üyesi mi?
            var teamMember = await _teamMemberManager.GetTeamMemberAsync(
                newProject.TeamId,
                vm.UserId);

            if (teamMember == null)
                return BadRequest();

            if (!ModelState.IsValid)
            {
                var adminTeams = await GetAdminTeamsAsync();

                var teamIds = adminTeams
                    .Select(x => x.Id)
                    .ToList();

                var projects = await _projectManager.GetAllAsync();

                projects = projects
                    .Where(x =>
                        teamIds.Contains(x.TeamId) &&
                        x.Status != DataStatus.Deleted)
                    .ToList();

                var users = new List<TH.ENTITIES.Models.User>();

                foreach (var team in adminTeams)
                {
                    var members = await _teamMemberManager.GetTeamMembersAsync(team.Id);

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

                return View(vm);
            }

            task.Title = vm.Title;
            task.Description = vm.Description;
            task.Priority = vm.Priority;
            task.UserId = vm.UserId;
            task.ProjectId = vm.ProjectId;
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

            await _taskManager.CompleteTaskAsync(id, user.Id);

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
        private async Task<TaskCreateVm> PrepareCreateVmAsync(
    TaskCreateVm vm)
        {
            var adminTeams = await GetAdminTeamsAsync();

            var teamIds = adminTeams
                .Select(x => x.Id)
                .ToList();

            var projects = await _projectManager.GetAllAsync();

            vm.Projects = projects
                .Where(x =>
                    teamIds.Contains(x.TeamId) &&
                    x.Status != DataStatus.Deleted)
                .ToList();

            var users = new List<ENTITIES.Models.User>();

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
                .GroupBy(x => x.Id)
                .Select(x => x.First())
                .ToList();

            return vm;
        }
    }
}
