using Microsoft.EntityFrameworkCore;
using TH.DAL.ContextClasses;
using TH.DAL.Repositories.Abstracts;
using TH.ENTITIES.Enums;
using TH.ENTITIES.Models;

namespace TH.DAL.Repositories.Concretes
{
    public class TaskCommentRepository
        : BaseRepository<TaskComment>,
          ITaskCommentRepository
    {
        private readonly MyContext _context;

        public TaskCommentRepository(MyContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<TaskComment> GetCommentByUserAsync(
            int commentId,
            int userId)
        {
            return await _context.TaskComments
                .Include(x => x.Task)
                    .ThenInclude(x => x.Project)
                .Include(x => x.User)
                .FirstOrDefaultAsync(x =>
                    x.Id == commentId &&
                    x.UserId == userId &&
                    x.Status != DataStatus.Deleted);
        }

        public async Task<TaskComment> GetCommentDetailsAsync(
            int commentId)
        {
            return await _context.TaskComments
                .Include(x => x.Task)
                    .ThenInclude(x => x.Project)
                .Include(x => x.User)
                .FirstOrDefaultAsync(x =>
                    x.Id == commentId &&
                    x.Status != DataStatus.Deleted);
        }
    }
}