using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TH.BLL.Managers.Abstracts;
using TH.DAL.Repositories.Abstracts;
using TH.ENTITIES.Enums;
using TH.ENTITIES.Models;
using TH.BLL.DTOs.Task;
using Task = System.Threading.Tasks.Task;

namespace TH.BLL.Managers.Concretes
{
    public class TaskManager
    : BaseManager<TH.ENTITIES.Models.Task>,
    ITaskManager
    {
        private readonly ITaskRepository _repository;
        private readonly INotificationManager _notificationManager;
        private readonly ITeamMemberManager _teamMemberManager;
        private readonly IProjectManager _projectManager;

        public TaskManager(
            ITaskRepository repository,
            INotificationManager notificationManager,
            ITeamMemberManager teamMemberManager,
            IProjectManager projectManager)
            : base(repository)
        {
            _repository = repository;
            _notificationManager = notificationManager;
            _teamMemberManager = teamMemberManager;
            _projectManager = projectManager;
        }

        public override async Task CreateAsync(
            ENTITIES.Models.Task task)
        {
            var project = await _projectManager
                .GetByIdAsync(task.ProjectId);

            if (project == null)
                return;

            if (project.Status == DataStatus.Deleted)
                return;

            var teamMember = await _teamMemberManager
                .GetTeamMemberAsync(
                    project.TeamId,
                    task.UserId);

            if (teamMember == null)
                return;

            await base.CreateAsync(task);

            if (task.UserId > 0)
            {
                await _notificationManager.CreateNotificationAsync(
                    task.UserId,
                    "New Task Assigned",
                    $"You have been assigned a new task: {task.Title}",
                    NotificationType.TaskAssigned);
            }
        }

        public async Task AssignTaskAsync(
            int taskId,
            int userId)
        {
            var task = await _repository
                .GetTaskDetailsAsync(taskId);

            if (task == null)
                return;

            if (task.Status == DataStatus.Deleted)
                return;

            if (task.Project == null)
                return;

            var teamMember = await _teamMemberManager
                .GetTeamMemberAsync(
                    task.Project.TeamId,
                    userId);

            if (teamMember == null)
                return;

            task.UserId = userId;

            await _notificationManager.CreateNotificationAsync(
                userId,
                "New Task",
                $"{task.Title} assigned to you.",
                NotificationType.TaskAssigned);

            await _repository.UpdateAsync(task, task);
        }

        public async Task ChangePriorityAsync(
            int taskId,
            PriorityLevel priority)
        {
            var task = await _repository
                .GetByIdAsync(taskId);

            if (task == null)
                return;

            if (task.Status == DataStatus.Deleted)
                return;

            task.Priority = priority;

            await _repository.UpdateAsync(task, task);
        }

        public async Task CompleteTaskAsync(int taskId, int userId)
        {
            var task = await _repository.GetTaskDetailsByUserAsync(taskId, userId);

            if (task == null)
                return;

            if (task.IsCompleted)
                return;

            task.IsCompleted = true;
            task.CompletedDate = DateTime.Now;
            task.UpdatedDate = DateTime.Now;

            await _notificationManager.CreateNotificationAsync(
                task.UserId,
                "Task Completed",
                $"{task.Title} completed.",
                NotificationType.TaskCompleted
            );

            await _repository.UpdateAsync(task, task);
        }

        public override async Task UpdateAsync(
            ENTITIES.Models.Task task)
        {
            var oldTask = await _repository
                .GetTaskDetailsAsync(task.Id);

            if (oldTask == null)
                return;

            var wasCompleted = oldTask.IsCompleted;

            if (oldTask.Status == DataStatus.Deleted)
                return;

            var newProject = await _projectManager
                .GetByIdAsync(task.ProjectId);

            if (newProject == null)
                return;

            if (newProject.Status == DataStatus.Deleted)
                return;

            var teamMember = await _teamMemberManager
                .GetTeamMemberAsync(
                    newProject.TeamId,
                    task.UserId);

            if (teamMember == null)
                return;

            var oldUserId = oldTask.UserId;

            if (!wasCompleted && task.IsCompleted)
            {
                task.CompletedDate = DateTime.Now;
            }
            else if (wasCompleted && !task.IsCompleted)
            {
                task.CompletedDate = null;
            }
            else if (wasCompleted && task.IsCompleted)
            {
                task.CompletedDate = oldTask.CompletedDate;
            }

            await base.UpdateAsync(task);

            if (oldUserId != task.UserId)
            {
                await _notificationManager.CreateNotificationAsync(
                    task.UserId,
                    "Task Updated",
                    $"You have been assigned to task \"{task.Title}\".",
                    NotificationType.TaskUpdated);
            }
            else
            {
                await _notificationManager.CreateNotificationAsync(
                    task.UserId,
                    "Task Updated",
                    $"Task \"{task.Title}\" has been updated.",
                    NotificationType.TaskUpdated);
            }
        }

        public override async Task MakePassiveAsync(
            ENTITIES.Models.Task task)
        {
            var taskWithDetails = await _repository
                .GetTaskDetailsAsync(task.Id);

            if (taskWithDetails == null)
                return;

            if (taskWithDetails.Status == DataStatus.Deleted)
                return;

            await base.MakePassiveAsync(taskWithDetails);

            if (taskWithDetails.UserId > 0)
            {
                await _notificationManager.CreateNotificationAsync(
                    taskWithDetails.UserId,
                    "Task Deleted",
                    $"Task \"{taskWithDetails.Title}\" has been deleted.",
                    NotificationType.TaskDeleted);
            }
        }

        public async Task<List<ENTITIES.Models.Task>>
            GetTasksByProjectAsync(int projectId)
        {
            return await _repository
                .GetTasksByProjectAsync(projectId);
        }

        public async Task<List<ENTITIES.Models.Task>>
            GetTasksByUserAsync(int userId)
        {
            return await _repository
                .GetTasksByUserAsync(userId);
        }

        public async Task<ENTITIES.Models.Task>
            GetTaskDetailsAsync(int id)
        {
            return await _repository
                .GetTaskDetailsAsync(id);
        }

        public async Task<List<ENTITIES.Models.Task>>
            FilterTasksAsync(
                string search,
                PriorityLevel? priority,
                bool? isCompleted,
                List<int> teamIds)
        {
            return await _repository
                .FilterTasksAsync(
                    search,
                    priority,
                    isCompleted,
                    teamIds);
        }

        public async Task<ENTITIES.Models.Task>
            GetTaskDetailsByUserAsync(
                int taskId,
                int userId)
        {
            return await _repository
                .GetTaskDetailsByUserAsync(
                    taskId,
                    userId);
        }

        public async Task<TaskAnalyticsDto> GetTaskAnalyticsAsync(List<int> teamIds)
        {
            var tasks = await FilterTasksAsync(null,null,null,teamIds);

            var totalTasks = tasks.Count;

            var completedTasks = tasks
                .Count(x => x.IsCompleted);

            var pendingTasks = tasks
                .Count(x => !x.IsCompleted);

            var overdueTasks = tasks
                .Count(x =>
                    !x.IsCompleted &&
                    x.DueDate.HasValue &&
                    x.DueDate.Value < DateTime.Now);

            double completionRate = totalTasks == 0
                ? 0
                : (double)completedTasks / totalTasks * 100;

            return new TaskAnalyticsDto
            {
                TotalTasks = totalTasks,
                CompletedTasks = completedTasks,
                PendingTasks = pendingTasks,
                OverdueTasks = overdueTasks,
                CompletionRate = Math.Round(completionRate, 2)
            };
        }

        public async Task<List<ProjectTaskAnalyticsDto>> GetProjectTaskAnalyticsAsync(List<int> teamIds)
        {
            var tasks = await FilterTasksAsync(null,null,null,teamIds);

            var projectAnalytics = tasks
                .GroupBy(x => new
                {
                    x.ProjectId,
                    ProjectName = x.Project?.ProjectName
                })
                .Select(group =>
                {
                    var totalTasks = group.Count();

                    var completedTasks = group.Count(x =>
                        x.IsCompleted);

                    var pendingTasks = group.Count(x =>
                        !x.IsCompleted);

                    var overdueTasks = group.Count(x =>
                        !x.IsCompleted &&
                        x.DueDate.HasValue &&
                        x.DueDate.Value < DateTime.Now);

                    var completionRate = totalTasks == 0
                        ? 0
                        : (double)completedTasks / totalTasks * 100;

                    return new ProjectTaskAnalyticsDto
                    {
                        ProjectId = group.Key.ProjectId,

                        ProjectName = group.Key.ProjectName
                            ?? "Unknown Project",

                        TotalTasks = totalTasks,

                        CompletedTasks = completedTasks,

                        PendingTasks = pendingTasks,

                        OverdueTasks = overdueTasks,

                        CompletionRate = Math.Round(
                            completionRate,
                            2)
                    };
                })
                .OrderByDescending(x => x.TotalTasks)
                .ToList();

            return projectAnalytics;
        }

        public async Task<List<UserTaskAnalyticsDto>> GetUserTaskAnalyticsAsync(List<int> teamIds)
        {
            var tasks = await FilterTasksAsync(null,null,null,teamIds);

            var userAnalytics = tasks
                .GroupBy(x => new
                {
                    x.UserId,
                    UserName = x.User != null
                        ? $"{x.User.FirstName} {x.User.LastName}".Trim()
                        : "Unknown User"
                })
                .Select(group =>
                {
                    var totalTasks = group.Count();

                    var completedTasks = group.Count(x =>
                        x.IsCompleted);

                    var pendingTasks = group.Count(x =>
                        !x.IsCompleted);

                    var overdueTasks = group.Count(x =>
                        !x.IsCompleted &&
                        x.DueDate.HasValue &&
                        x.DueDate.Value < DateTime.Now);

                    var completionRate = totalTasks == 0
                        ? 0
                        : (double)completedTasks / totalTasks * 100;

                    return new UserTaskAnalyticsDto
                    {
                        UserId = group.Key.UserId,

                        UserName = string.IsNullOrWhiteSpace(group.Key.UserName)
                            ? "Unknown User"
                            : group.Key.UserName,

                        TotalTasks = totalTasks,

                        CompletedTasks = completedTasks,

                        PendingTasks = pendingTasks,

                        OverdueTasks = overdueTasks,

                        CompletionRate = Math.Round(
                            completionRate,
                            2)
                    };
                })
                .OrderByDescending(x => x.TotalTasks)
                .ToList();

            return userAnalytics;
        }

        public async Task<List<TaskAssignmentSuggestionDto>> GetTaskAssignmentSuggestionsAsync(List<int> teamIds)
        {
            // Görevleri filtreleme
            var tasks = await FilterTasksAsync(null,null,null,teamIds);

            var suggestions = tasks
                .Where(x => x.User != null)

                // Kullanıcı bazında gruplama
                .GroupBy(x => new
                {
                    x.UserId,

                    UserName = $"{x.User.FirstName} {x.User.LastName}".Trim(),

                    RoleId = x.User.RoleId,

                    RoleName = x.User.Role != null
                    ? x.User.Role.Name: "Rol bilgisi yok"
                })

                .Select(group =>
                {
                    var totalTasks = group.Count();

                    var pendingTasks = group.Count(x =>
                        !x.IsCompleted);

                    var overdueTasks = group.Count(x =>
                        !x.IsCompleted &&
                        x.DueDate.HasValue &&
                        x.DueDate.Value < DateTime.Now);

                    var completedTasks = group.Count(x =>
                        x.IsCompleted);

                    var completionRate = totalTasks == 0
                        ? 0
                        : (double)completedTasks / totalTasks * 100;

                    // İş yükü puanı
                    var workloadScore =
                        (pendingTasks * 1) +
                        (overdueTasks * 3);

                    return new TaskAssignmentSuggestionDto
                    {
                        UserId = group.Key.UserId,

                        UserName = string.IsNullOrWhiteSpace(group.Key.UserName)
                        ? "Unknown User": group.Key.UserName,

                        RoleId = group.Key.RoleId,

                        RoleName = string.IsNullOrWhiteSpace(group.Key.RoleName)
                        ? "Rol bilgisi yok": group.Key.RoleName,

                        TotalTasks = totalTasks,

                        PendingTasks = pendingTasks,

                        OverdueTasks = overdueTasks,

                        CompletionRate = Math.Round(
                            completionRate,
                            2),

                        WorkloadScore = workloadScore
                    };
                })

                .OrderBy(x => x.WorkloadScore)
                .ThenByDescending(x => x.CompletionRate)
                .ToList();

            return suggestions;
        }
    }
}
