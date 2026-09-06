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

        public async Task<List<Project>> FilterProjectsAsync(string search,DataStatus? status,string sortBy, List<int> teamIds)
        {
            var query = _context.Projects
                .Include(x => x.Tasks)
                .Include(x => x.Users)
                .Include(x => x.Team)
                .Where(x => teamIds.Contains(x.TeamId))
                .AsQueryable();

            // SEARCH
            if (!string.IsNullOrWhiteSpace(search))
            {
                search = search.Trim().ToLower();

                query = query.Where(x =>
                    x.ProjectName.ToLower().Contains(search) ||
                    x.Description.ToLower().Contains(search));
            }

            // STATUS
            if (status.HasValue)
            {
                query = query.Where(x => x.Status == status);
            }

            // SORT
            switch (sortBy)
            {
                case "Name":
                    query = query.OrderBy(x => x.ProjectName);
                    break;

                case "Date":
                    query = query.OrderByDescending(x => x.CreatedDate);
                    break;

                case "TaskCount":
                    query = query.OrderByDescending(x => x.Tasks.Count);
                    break;

                default:
                    query = query.OrderByDescending(x => x.CreatedDate);
                    break;
            }

            return await query.ToListAsync();
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
                .Include(x => x.Team)
                .Include(x => x.Users)
                .Include(x => x.Tasks)
                .FirstOrDefaultAsync(x => x.Id == id); 
        }

        public async Task<Project> GetProjectDetailsByUserAsync(int projectId, int userId)
        {
            return await _context.Projects
                .Include(x => x.Team)
                .Include(x => x.Users)
                .Include(x => x.Tasks)
                .FirstOrDefaultAsync(x =>
                    x.Id == projectId &&
                    x.Users.Any(u => u.Id == userId) &&
                    x.Status != DataStatus.Deleted);
        }

        public async Task<List<Project>> GetProjectsByUserAsync(int userId)
        {
            return await _context.Projects
                .Include(x => x.Users)
                .Include(x => x.Tasks)
                .Include(x => x.Team)
                .Where(x => x.Users.Any(u => u.Id == userId) && x.Status != DataStatus.Deleted)
                .OrderByDescending(x => x.CreatedDate)
                .ToListAsync();
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
                .Where(x =>x.ProjectName.Contains(keyword) ||x.Description.Contains(keyword))
                .OrderBy(x => x.ProjectName)
                .Take(10)
                .ToListAsync();
        }

        public async Task<List<Project>> SearchProjectsByUserAsync(string keyword,int userId)
        {
            keyword = keyword.Trim().ToLower();

            return await _context.Projects
                .Include(x => x.Users)
                .Where(x => x.Users.Any(u => u.Id == userId) && (x.ProjectName.ToLower().Contains(keyword) || x.Description.ToLower().Contains(keyword)))
                .OrderBy(x => x.ProjectName)
                .Take(10)
                .ToListAsync();
        }
    }
}
