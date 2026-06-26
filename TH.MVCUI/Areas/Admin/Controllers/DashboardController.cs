using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TH.BLL.Managers.Abstracts;
using TH.MVCUI.Areas.Admin.Models.PageVMs;

namespace TH.MVCUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class DashboardController : Controller
    {
        private readonly IProjectManager _projectManager;
        private readonly ITaskManager _taskManager;
        private readonly IUserManager _userManager;

        public DashboardController
        (
            IProjectManager projectManager,
            ITaskManager taskManager,
            IUserManager userManager
        )
        {
            _projectManager = projectManager;
            _taskManager = taskManager;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var projects = await _projectManager.GetAllAsync();
            var tasks = await _taskManager.GetAllAsync();
            var users = await _userManager.GetAllAsync();

            DashboardVm vm = new DashboardVm
            {
                TotalProjects = projects.Count,
                TotalTasks = tasks.Count,
                CompletedTasks = tasks.Count(x => x.IsCompleted),
                TotalUsers = users.Count,

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