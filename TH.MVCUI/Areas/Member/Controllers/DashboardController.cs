using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TH.BLL.Managers.Abstracts;
using TH.BLL.Services.Abstracts;
using TH.ENTITIES.Models;
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
        private readonly INotificationManager _notificationManager;

        public DashboardController(
            IProjectManager projectManager,
            ITaskManager taskManager,
            IUserManager userManager,
            IUserContext userContext,
            INotificationManager notificationManager)
        {
            _projectManager = projectManager;
            _taskManager = taskManager;
            _userManager = userManager;
            _userContext = userContext;
            _notificationManager = notificationManager;
        }

        public async Task<IActionResult> Index()
        {
            //var user = await _userContext.GetCurrentUserAsync();

            //var projects = user.Projects.ToList();
            //var tasks = user.Tasks.ToList();

            var currentUser = await _userContext.GetCurrentUserAsync();

            if (currentUser == null)
                return RedirectToAction("Login", "Account", new { area = "" });

            var projects = await _projectManager.GetProjectsByUserAsync(currentUser.Id);

            var tasks = await _taskManager.GetTasksByUserAsync(currentUser.Id);

            //var notifications = await _notificationManager.GetAllAsync();
            var notifications = await _notificationManager.GetNotificationsByUserAsync(currentUser.Id);

            DashboardVm vm = new()
            {
                TotalProjects = projects.Count,

                TotalTasks = tasks.Count,

                CompletedTasks = tasks.Count(x => x.IsCompleted),

                CompletionRate = tasks.Count == 0 ? 0 : (tasks.Count(x => x.IsCompleted) * 100) / tasks.Count,

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
                .ToList(),

                Notifications = notifications,

                UnreadNotificationCount = notifications.Count(x => !x.IsRead),

                RecentNotifications = notifications
                .OrderByDescending(x => x.NotificationDate)
                .Take(5).ToList(),

                RecentUsers = projects
                .SelectMany(x => x.Users)
                .Distinct()
                .Take(5)
                .ToList()
            };

            return View(vm);
        }
    }
}