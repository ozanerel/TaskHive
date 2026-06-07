using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TH.DAL.ContextClasses;
using TH.DAL.Repositories.Abstracts;
using TH.ENTITIES.Models;

namespace TH.DAL.Repositories.Concretes
{
    public class ProjectRepository : BaseRepository<Project>, IProjectRepository
    {
        readonly MyContext _context;
        public ProjectRepository(MyContext context):base(context)
        {
            _context = context;
        }
        public async Task<Project> GetProjectDetailsAsync(int id)
        {
            return await _context.Projects
                .Include(x => x.Tasks)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Project>> GetProjectsWithTasksAsync()
        {
            return await _context.Projects
                .Include(x => x.Tasks)
                .ToListAsync();
        }
    }
}
