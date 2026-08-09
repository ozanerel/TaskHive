using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TH.BLL.Managers.Abstracts;
using TH.DAL.Repositories.Abstracts;
using TH.ENTITIES.Enums;
using TH.ENTITIES.Models;
using Task = System.Threading.Tasks.Task;

namespace TH.BLL.Managers.Concretes
{
    public class TaskManager : BaseManager<TH.ENTITIES.Models.Task>,ITaskManager
    {
        private readonly ITaskRepository _repository;
        private readonly INotificationManager _notificationManager;
        private readonly IUserManager _userManager;

        public TaskManager(ITaskRepository repository, INotificationManager notificationManager,IUserManager userManager)
            : base(repository)
        {
            _repository = repository;
            _notificationManager = notificationManager;
            _userManager = userManager;
        }

        public override async Task CreateAsync(ENTITIES.Models.Task task)
        {
            await base.CreateAsync(task);


            if (task.UserId > 0)
            {
                await _notificationManager.CreateNotificationAsync(
                    task.UserId,
                    "New Task Assigned",
                    $"You have been assigned a new task: {task.Title}",
                    NotificationType.TaskAssigned
                );
            }
        }

        public async Task AssignTaskAsync(int taskId, int userId)
        {
            var task = await _repository.GetByIdAsync(taskId);

            if (task == null)
                return;

            task.UserId = userId;

            await _notificationManager.CreateNotificationAsync(userId,"New Task",$"{task.Title} assigned to you.",NotificationType.TaskAssigned);

            await _repository.UpdateAsync(task, task);
        }

        public async Task ChangePriorityAsync(int taskId, PriorityLevel priority)
        {
            var task = await _repository.GetByIdAsync(taskId);

            if (task == null)
                return;

            task.Priority = priority;

            await _repository.UpdateAsync(task, task);
        }

        public async Task CompleteTaskAsync(int taskId)
        {
            var task = await _repository.GetByIdAsync(taskId);

            if (task == null)
                return;

            task.IsCompleted = true;
            task.UpdatedDate = DateTime.Now;

            await _notificationManager.CreateNotificationAsync(task.UserId,"Task Completed",$"{task.Title} completed.",NotificationType.TaskCompleted);

            await _repository.UpdateAsync(task, task);
        }

        public override async Task UpdateAsync(ENTITIES.Models.Task task)
        {
            var oldTask = await _repository.GetTaskDetailsAsync(task.Id);

            if (oldTask == null)
                return;

            var oldUserId = oldTask.UserId;

            await base.UpdateAsync(task);

            // Eğer görev başka kullanıcıya atanmışsa
            if (oldUserId != task.UserId)
            {
                await _notificationManager.CreateNotificationAsync(
                    task.UserId,
                    "Task Updated",
                    $"You have been assigned to task \"{task.Title}\".",
                    NotificationType.TaskUpdated
                );
            }
            else 
            {
                // Güncel kullanıcıya bilgi ver
                await _notificationManager.CreateNotificationAsync(
                    task.UserId,
                    "Task Updated",
                    $"Task \"{task.Title}\" has been updated.",
                    NotificationType.TaskUpdated
                );
            }
        }

        public override async Task MakePassiveAsync(ENTITIES.Models.Task task)
        {
            var taskWithDetails = await _repository.GetTaskDetailsAsync(task.Id);

            if (taskWithDetails == null)
                return;

            await base.MakePassiveAsync(taskWithDetails);

            // Atanan kullanıcıya bildir
            if (taskWithDetails.UserId > 0)
            {
                await _notificationManager.CreateNotificationAsync(
                    taskWithDetails.UserId,
                    "Task Deleted",
                    $"Task \"{taskWithDetails.Title}\" has been deleted.",
                    NotificationType.TaskDeleted
                );
            }

            // Tüm adminlere bildir
            var admins = await _userManager.GetAdminsAsync();

            foreach (var admin in admins)
            {
                await _notificationManager.CreateNotificationAsync(
                    admin.Id,
                    "Task Deleted",
                    $"Task \"{taskWithDetails.Title}\" has been deleted.",
                    NotificationType.TaskDeleted
                );
            }
        }

        public async Task<List<ENTITIES.Models.Task>> GetTasksByProjectAsync(int projectId)
        {
            return await _repository.GetTasksByProjectAsync(projectId);
        }

        public async Task<List<ENTITIES.Models.Task>> GetTasksByUserAsync(int userId)
        {
            return await _repository.GetTasksByUserAsync(userId);
        }

        public async Task<ENTITIES.Models.Task> GetTaskDetailsAsync(int id)
        {
            return await _repository.GetTaskDetailsAsync(id);
        }

        public async Task<List<ENTITIES.Models.Task>> FilterTasksAsync(string search, PriorityLevel? priority, bool? isCompleted)
        {
            return await _repository.FilterTasksAsync(search,priority,isCompleted);
        }

        public async Task<ENTITIES.Models.Task> GetTaskDetailsByUserAsync(int taskId, int userId)
        {
            return await _repository.GetTaskDetailsByUserAsync(taskId,userId);
        }
    }
}
