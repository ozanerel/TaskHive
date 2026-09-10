using Microsoft.EntityFrameworkCore;
using TH.BLL.Managers.Abstracts;
using TH.DAL.Repositories.Abstracts;
using TH.ENTITIES.Enums;
using TH.ENTITIES.Models;
using Task = System.Threading.Tasks.Task;

namespace TH.BLL.Managers.Concretes
{
    public class TaskCommentManager
        : BaseManager<TaskComment>,
          ITaskCommentManager
    {
        private readonly ITaskCommentRepository _repository;
        private readonly INotificationManager _notificationManager;
        private readonly ITaskRepository _taskRepository;
        private readonly IUserRepository _userRepository;
        private readonly ITeamMemberManager _teamMemberManager;

        public TaskCommentManager(
            ITaskCommentRepository repository,
            INotificationManager notificationManager,
            ITaskRepository taskRepository,
            IUserRepository userRepository,
            ITeamMemberManager teamMemberManager)
            : base(repository)
        {
            _repository = repository;
            _notificationManager = notificationManager;
            _taskRepository = taskRepository;
            _userRepository = userRepository;
            _teamMemberManager = teamMemberManager;
        }

        public override async Task CreateAsync(TaskComment comment)
        {
            var task = await _taskRepository
                .GetTaskDetailsAsync(comment.TaskId);

            if (task == null)
                return;

            if (task.Status == DataStatus.Deleted)
                return;

            if (task.Project == null)
                return;

            var teamMember = await _teamMemberManager
                .GetTeamMemberAsync(
                    task.Project.TeamId,
                    comment.UserId);

            if (teamMember == null)
                return;

            var user = await _userRepository
                .GetByIdAsync(comment.UserId);

            if (user == null)
                return;

            if (user.Status == DataStatus.Deleted)
                return;

            await base.CreateAsync(comment);

            if (task.UserId != comment.UserId)
            {
                await _notificationManager.CreateNotificationAsync(
                    task.UserId,
                    "New Comment Added",
                    $"{user.FirstName} {user.LastName} commented on \"{task.Title}\".",
                    NotificationType.CommentAdded);
            }
        }

        public override async Task UpdateAsync(TaskComment comment)
        {
            var existingComment = await _repository
                .GetCommentDetailsAsync(comment.Id);

            if (existingComment == null)
                return;

            if (existingComment.Status == DataStatus.Deleted)
                return;

            if (existingComment.UserId != comment.UserId)
                return;

            if (existingComment.TaskId != comment.TaskId)
                return;

            existingComment.Message = comment.Message;

            await base.UpdateAsync(existingComment);
        }

        public override async Task MakePassiveAsync(TaskComment comment)
        {
            var existingComment = await _repository
                .GetCommentDetailsAsync(comment.Id);

            if (existingComment == null)
                return;

            if (existingComment.Status == DataStatus.Deleted)
                return;

            if (existingComment.UserId != comment.UserId)
                return;

            await base.MakePassiveAsync(existingComment);
        }

        public async Task DeleteCommentByTeamAdminAsync(
            int commentId,
            int teamAdminUserId)
        {
            var comment = await _repository
                .GetCommentDetailsAsync(commentId);

            if (comment == null)
                return;

            if (comment.Status == DataStatus.Deleted)
                return;

            if (comment.Task == null)
                return;

            if (comment.Task.Project == null)
                return;

            var teamMember = await _teamMemberManager
                .GetTeamMemberAsync(
                    comment.Task.Project.TeamId,
                    teamAdminUserId);

            if (teamMember == null)
                return;

            if (teamMember.TeamRole != TeamRole.Admin)
                return;

            await base.MakePassiveAsync(comment);
        }

        public async Task<List<TaskComment>> GetCommentsByTaskAsync(
            int taskId)
        {
            return await _repository
                .Where(x =>
                    x.TaskId == taskId &&
                    x.Status != DataStatus.Deleted)
                .Include(x => x.User)
                .OrderBy(x => x.CreatedDate)
                .ToListAsync();
        }

        public async Task<List<TaskComment>> GetCommentsByUserAsync(
            int userId)
        {
            return await _repository
                .Where(x =>
                    x.UserId == userId &&
                    x.Status != DataStatus.Deleted)
                .Include(x => x.Task)
                .OrderByDescending(x => x.CreatedDate)
                .ToListAsync();
        }

        public async Task<TaskComment> GetCommentByUserAsync(
            int commentId,
            int userId)
        {
            return await _repository
                .GetCommentByUserAsync(
                    commentId,
                    userId);
        }

        public async Task<TaskComment> GetCommentDetailsAsync(
            int commentId)
        {
            return await _repository
                .GetCommentDetailsAsync(commentId);
        }

        public async Task<List<TaskComment>> GetCommentsByTeamIdsAsync(
            List<int> teamIds)
        {
            if (teamIds == null || teamIds.Count == 0)
                return new List<TaskComment>();

            return await _repository
                .GetCommentsByTeamIdsAsync(teamIds);
        }

    }
}