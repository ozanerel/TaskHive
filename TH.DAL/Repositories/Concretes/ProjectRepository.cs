using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TH.DAL.ContextClasses;
using TH.DAL.Repositories.Abstracts;
using TH.ENTITIES.Enums;
using TH.ENTITIES.Models;

namespace TH.DAL.Repositories.Concretes
{
    public class ProjectRepository : BaseRepository<Project>, IProjectRepository
    {
        readonly MyContext _context;
        public ProjectRepository(MyContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Project>> GetDashboardProjectsAsync()
        {
            return await _context.Projects
                .Where(x => x.Status != DataStatus.Deleted)
                .Include(x => x.Tasks)
                .OrderByDescending(x => x.CreatedDate)
                .Take(5)
                .ToListAsync();
        }

        public async Task<Project> GetProjectDetailsAsync(int id)
        {
            //return await _context.Projects
            //    .Include(x => x.Tasks)
            //    .FirstOrDefaultAsync(x => x.Id == id);

            //return await _context.Projects
            //    .Where(x => x.Status != DataStatus.Deleted)
            //    .Include(x => x.Tasks)
            //    .FirstOrDefaultAsync(x => x.Id == id);

            return await _context.Projects
                .Include(x => x.Users)
                .Include(x => x.Tasks)
                .FirstOrDefaultAsync(x => x.Id == id); 
        }

        public async Task<List<Project>> GetProjectsWithTasksAsync()
        {
            //return await _context.Projects
            //    .Include(x => x.Tasks)
            //    .ToListAsync();

            return await _context.Projects
                .Where(x => x.Status != DataStatus.Deleted)
                .Include(x => x.Tasks)
                .ToListAsync();
        }

        public async Task<List<Project>> SearchProjectsAsync(string keyword)
        {
            keyword = keyword.Trim().ToLower();

            return await _context.Projects
                //.Where(x =>
                //    x.ProjectName.Contains(keyword) ||
                //    x.Description.Contains(keyword))
                .Where(x =>
                x.Status != DataStatus.Deleted &&
                (
                x.ProjectName.Contains(keyword) ||x.Description.Contains(keyword)
                ))
                .OrderBy(x => x.ProjectName)
                .Take(10)
                .ToListAsync();
        }
    }
}
