using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TH.BLL.Managers.Abstracts;
using TH.DAL.Repositories.Abstracts;
using TH.DAL.Repositories.Concretes;
using TH.ENTITIES.Models;
using Task = System.Threading.Tasks.Task;

namespace TH.BLL.Managers.Concretes
{
    public class TaskCommentManager : BaseManager<TaskComment>, ITaskCommentManager
    {
        private readonly ITaskCommentRepository _repository;
        private readonly INotificationManager _notificationManager;

        public TaskCommentManager(ITaskCommentRepository repository, INotificationManager notificationManager)
            : base(repository)
        {
            _repository = repository;
            _notificationManager = notificationManager;
        }

        public override async Task CreateAsync(TaskComment comment)
        {
            await base.CreateAsync(comment);

            await _notificationManager.CreateNotificationAsync(
                comment.Task.UserId,
                "New Comment",
                "Someone commented on your task."
            );
        }

        public async Task<List<TaskComment>> GetCommentsByTaskAsync(int taskId)
        {
            return _repository
                .Where(x => x.TaskId == taskId)
                .ToList();
        }

        public async Task<List<TaskComment>> GetCommentsByUserAsync(int userId)
        {
            return await _repository
                .Where(x => x.UserId == userId)
                .ToListAsync();
        }
    }
}
