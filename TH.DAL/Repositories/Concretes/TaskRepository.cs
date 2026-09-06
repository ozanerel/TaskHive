using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TH.DAL.ContextClasses;
using TH.DAL.Repositories.Abstracts;
using TH.ENTITIES.Enums;

namespace TH.DAL.Repositories.Concretes
{
    public class TaskRepository : BaseRepository<ENTITIES.Models.Task>, ITaskRepository
    {
        readonly MyContext _context;
        public TaskRepository(MyContext context): base(context)
        {
            _context = context;
        }
        public async Task<List<ENTITIES.Models.Task>> GetHighPriorityTasksAsync()
        {
            return await _context.Tasks
                .Where(t => t.Priority == PriorityLevel.High)
                .ToListAsync();
        }

        public async Task<List<ENTITIES.Models.Task>> GetTasksByProjectAsync(int projectId)
        {
            return await _context.Tasks
                .Where(t => t.ProjectId == projectId && t.Status != DataStatus.Deleted)
                .ToListAsync();
        }

        public async Task<List<ENTITIES.Models.Task>> GetTasksByUserAsync(int userId)
        {
            return await _context.Tasks
         .Include(x => x.Project)
         .Include(x => x.User)
         .Where(x =>
             x.UserId == userId &&
             x.Status != DataStatus.Deleted)
         .OrderBy(x => x.Status)
         .ThenBy(x => x.Title)
         .ToListAsync();
        }

        public async Task<List<ENTITIES.Models.Task>> SearchTasksAsync(string keyword)
        {
            keyword = keyword.Trim().ToLower();

            return await _context.Tasks
                .Where(x =>x.Title.ToLower().Contains(keyword) ||x.Description.ToLower().Contains(keyword))
                .OrderBy(x => x.Title)
                .Take(10)
                .ToListAsync();
        }

        public async Task<List<ENTITIES.Models.Task>> SearchTasksByUserAsync(string keyword,int userId)
        {
            keyword = keyword.Trim().ToLower();

            return await _context.Tasks
                .Include(x => x.Project)
                .Include(x => x.User)
                .Where(x =>
                    x.UserId == userId &&
                    x.Status != DataStatus.Deleted &&
                    (x.Title.ToLower().Contains(keyword) ||
                     x.Description.ToLower().Contains(keyword)))
                .OrderBy(x => x.Title)
                .Take(10)
                .ToListAsync();
        }

        public async Task<ENTITIES.Models.Task> GetTaskDetailsAsync(int id)
        {
            return await _context.Tasks
                .Include(x => x.Project)
                .Include(x => x.User)
                .Include(x => x.TaskComments)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<ENTITIES.Models.Task>> FilterTasksAsync(string search, PriorityLevel? priority, bool? isCompleted, List<int> teamIds)
        {
            var query = _context.Tasks
        .Include(x => x.User)
        .Include(x => x.Project)
        .Where(x =>
            teamIds.Contains(x.Project.TeamId) &&
            x.Status != DataStatus.Deleted)
        .AsQueryable();

            // SEARCH
            if (!string.IsNullOrWhiteSpace(search))
            {
                search = search.Trim().ToLower();

                query = query.Where(x =>
                    x.Title.ToLower().Contains(search) ||
                    x.Description.ToLower().Contains(search));
            }

            // PRIORITY
            if (priority.HasValue)
            {
                query = query.Where(x => x.Priority == priority.Value);
            }

            // STATUS
            if (isCompleted.HasValue)
            {
                query = query.Where(x => x.IsCompleted == isCompleted.Value);
            }

            return await query
                .OrderBy(x => x.Title)
                .ToListAsync();
        }

        public async Task<ENTITIES.Models.Task> GetTaskDetailsByUserAsync(int taskId,int userId)
        {
            return await _context.Tasks
                .Include(x => x.Project)
                .Include(x => x.User)
                .Include(x => x.TaskComments)
                .FirstOrDefaultAsync(x =>
                    x.Id == taskId &&
                    x.UserId == userId &&
                    x.Status != DataStatus.Deleted);
        }
    }
}
