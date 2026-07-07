using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TH.BLL.Managers.Abstracts;
using TH.BLL.Services.Abstracts;
using TH.MVCUI.Areas.Member.Models.PageVMs;

namespace TH.MVCUI.Areas.Member.Controllers
{
    [Area("Member")]
    [Authorize(Roles = "Member")]
    public class DashboardController : Controller
    {
        private readonly IProjectManager _projectManager;
        private readonly ITaskManager _taskManager;
        private readonly IUserManager _userManager;
        private readonly IUserContext _userContext;

        public DashboardController(
            IProjectManager projectManager,
            ITaskManager taskManager,
            IUserManager userManager,
            IUserContext userContext)
        {
            _projectManager = projectManager;
            _taskManager = taskManager;
            _userManager = userManager;
            _userContext = userContext;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userContext.GetCurrentUserAsync();

            var projects = user.Projects.ToList();
            var tasks = user.Tasks.ToList();

            DashboardVm vm = new()
            {
                TotalProjects = projects.Count,

                TotalTasks = tasks.Count,

                CompletedTasks = tasks.Count(x => x.IsCompleted),

                TotalUsers = projects
                    .SelectMany(x => x.Users)
                    .Distinct()
                    .Count(),

                RecentProjects = projects
                    .OrderByDescending(x => x.CreatedDate)
                    .Take(5)
                    .ToList(),

                RecentTasks = tasks
                    .OrderByDescending(x => x.CreatedDate)
                    .Take(5)
                    .ToList()
            };

            return View(vm);
        }
    }
}