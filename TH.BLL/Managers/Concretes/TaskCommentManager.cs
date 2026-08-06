using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TH.BLL.Managers.Abstracts;
using TH.DAL.Repositories.Abstracts;
using TH.DAL.Repositories.Concretes;
using TH.ENTITIES.Enums;
using TH.ENTITIES.Models;
using Task = System.Threading.Tasks.Task;

namespace TH.BLL.Managers.Concretes
{
    public class TaskCommentManager : BaseManager<TaskComment>, ITaskCommentManager
    {
        private readonly ITaskCommentRepository _repository;
        private readonly INotificationManager _notificationManager;
        private readonly ITaskRepository _taskRepository;
        private readonly IUserRepository _userRepository;

        public TaskCommentManager(ITaskCommentRepository repository, INotificationManager notificationManager,ITaskRepository taskRepository,IUserRepository userRepository)
            : base(repository)
        {
            _repository = repository;
            _notificationManager = notificationManager;
            _taskRepository = taskRepository;
            _userRepository = userRepository;
        }

        public override async Task CreateAsync(TaskComment comment)
        {
            var task = await _taskRepository.GetTaskDetailsAsync(comment.TaskId);

            if (task == null)
                return;

            await base.CreateAsync(comment);

            var user = await _userRepository.GetByIdAsync(comment.UserId);

            // Yorumu yapan kişi task sahibi değilse bildirim gönder
            if (task.UserId != comment.UserId)
            {
                await _notificationManager.CreateNotificationAsync(
                    task.UserId,
                    "New Comment Added",
                    //$"A new comment was added to your task \"{task.Title}\".",
                    $"{user.FirstName} {user.LastName} commented on \"{task.Title}\".",
                    NotificationType.CommentAdded
                );
            }
        }

        public async Task<List<TaskComment>> GetCommentsByTaskAsync(int taskId)
        {
            return await _repository
                .Where(x => x.TaskId == taskId)
                .ToListAsync();
        }

        public async Task<List<TaskComment>> GetCommentsByUserAsync(int userId)
        {
            return await _repository
                .Where(x => x.UserId == userId)
                .ToListAsync();
        }
    }
}
