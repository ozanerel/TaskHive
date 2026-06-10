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

        public TaskManager(ITaskRepository repository)
            : base(repository)
        {
            _repository = repository;
        }

        public async Task AssignTaskAsync(int taskId, int userId)
        {
            var task = await _repository.GetByIdAsync(taskId);

            if (task == null)
                return;

            task.UserId = userId;

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

            await _repository.UpdateAsync(task, task);
        }

        public async Task<List<ENTITIES.Models.Task>> GetTasksByProjectAsync(int projectId)
        {
            return await _repository.GetTasksByProjectAsync(projectId);
        }

        public async Task<List<ENTITIES.Models.Task>> GetTasksByUserAsync(int userId)
        {
            return await _repository.GetTasksByUserAsync(userId);
        }
    }
}
