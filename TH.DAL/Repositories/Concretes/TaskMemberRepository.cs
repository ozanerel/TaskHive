using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TH.DAL.ContextClasses;
using TH.DAL.Repositories.Abstracts;
using TH.ENTITIES.Models;

namespace TH.DAL.Repositories.Concretes
{
    public class TaskMemberRepository : ITaskMemberRepository
    {
        readonly MyContext _context;

        public TaskMemberRepository(MyContext context)
        {
            _context = context;
        }

        public async Task<List<TaskMember>> GetByTaskIdAsync(int taskId)
        {
            return await _context.TaskMembers
                .Include(x => x.User)
                .Where(x => x.TaskId == taskId)
                .ToListAsync();
        }

        public async Task<TaskMember> GetAsync(
            int taskId,
            int userId)
        {
            return await _context.TaskMembers
                .FirstOrDefaultAsync(x =>
                    x.TaskId == taskId &&
                    x.UserId == userId);
        }

        public async System.Threading.Tasks.Task CreateAsync(TaskMember taskMember)
        {
            await _context.TaskMembers.AddAsync(taskMember);
            await _context.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task DeleteAsync(TaskMember taskMember)
        {
            _context.TaskMembers.Remove(taskMember);
            await _context.SaveChangesAsync();
        }
    }
}