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
                .Where(t => t.ProjectId == projectId)
                .ToListAsync();
        }

        public async Task<List<ENTITIES.Models.Task>> GetTasksByUserAsync(int userId)
        {
            return await _context.Tasks
                .Where(t => t.UserId == userId)
                .ToListAsync();
        }

        public async Task<List<ENTITIES.Models.Task>> SearchTasksAsync(string keyword)
        {
            keyword = keyword.Trim().ToLower();

            return await _context.Tasks
                .Where(x =>
                    x.Title.Contains(keyword) ||
                    x.Description.Contains(keyword))
                .OrderBy(x => x.Title)
                .Take(10)
                .ToListAsync();
        }
    }
}
