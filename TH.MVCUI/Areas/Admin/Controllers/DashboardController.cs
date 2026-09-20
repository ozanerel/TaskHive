using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TH.BLL.Managers.Abstracts;
using TH.MVCUI.Areas.Admin.Models.PageVMs;
using TH.BLL.DTOs.Task;

namespace TH.MVCUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class DashboardController : Controller
    {
        private readonly IProjectManager _projectManager;
        private readonly ITaskManager _taskManager;
        private readonly IUserManager _userManager;
        private readonly INotificationManager _notificationManager;

        public DashboardController
        (
            IProjectManager projectManager,
            ITaskManager taskManager,
            IUserManager userManager,
            INotificationManager notificationManager
        )
        {
            _projectManager = projectManager;
            _taskManager = taskManager;
            _userManager = userManager;
            _notificationManager = notificationManager;
        }

        public async Task<IActionResult> Index()
        {
            var projects = await _projectManager.GetDashboardProjectsAsync();

            var tasks = await _taskManager.GetAllAsync();

            var users = await _userManager.GetAllAsync();

            var notifications = await _notificationManager.GetAllAsync();

            var teamIds = projects
                .Select(x => x.TeamId)
                .Distinct()
                .ToList();

            var taskAnalytics = await _taskManager.GetTaskAnalyticsAsync(teamIds);

            var projectTaskAnalytics = await _taskManager.GetProjectTaskAnalyticsAsync(teamIds);

            DashboardVm vm = new DashboardVm
            {
                TotalProjects = projects.Count,
                TotalTasks = taskAnalytics.TotalTasks,
                CompletedTasks = taskAnalytics.CompletedTasks,
                PendingTasks = taskAnalytics.PendingTasks,
                OverdueTasks = taskAnalytics.OverdueTasks,
                CompletionRate = taskAnalytics.CompletionRate,
                ProjectTaskAnalytics = projectTaskAnalytics,

                InProgressTasks = tasks.Count(x =>
                    !x.IsCompleted &&
                    x.Status == TH.ENTITIES.Enums.DataStatus.Updated),

                TotalUsers = users.Count,

                RecentProjects = projects
                    .OrderByDescending(x => x.CreatedDate)
                    .Take(5)
                    .ToList(),

                RecentTasks = tasks
                    .OrderByDescending(x => x.CreatedDate)
                    .Take(5)
                    .ToList(),

                RecentNotifications = notifications
                    .OrderByDescending(x => x.CreatedDate)
                    .Take(5)
                    .ToList(),

                RecentUsers = users
                    .OrderByDescending(x => x.CreatedDate)
                    .Take(5)
                    .ToList(),

                Notifications = notifications,

                UnreadNotificationCount = notifications.Count(x => !x.IsRead)
            };

            return View(vm);
        }
    }
}