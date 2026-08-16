using Microsoft.EntityFrameworkCore;
using TH.DAL.ContextClasses;
using TH.DAL.Repositories.Abstracts;
using TH.ENTITIES.Models;

namespace TH.DAL.Repositories.Concretes
{
    public class TeamRepository : BaseRepository<Team>, ITeamRepository
    {
        private readonly MyContext _context;

        public TeamRepository(MyContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<Team> GetTeamDetailsAsync(int teamId)
        {
            return await _context.Teams
                .Include(x => x.TeamMembers)
                    .ThenInclude(x => x.User)//Buranın amacı ileride Team detayında bulunan üyeleri gösterebilmek.
                        .ThenInclude(x => x.Role)//Bununla birlikte rolünü de elde ediyoruz
                .Include(x => x.Projects)
                    .ThenInclude(x => x.Tasks)
                .FirstOrDefaultAsync(x => x.Id == teamId);
        }

        public async Task<List<Team>> GetTeamsByUserAsync(int userId)
        {
            return await _context.Teams
                .Include(x => x.TeamMembers)
                .Where(x => x.TeamMembers.Any(tm => tm.UserId == userId))
                .Where(x => x.Status != TH.ENTITIES.Enums.DataStatus.Deleted)
                .OrderBy(x => x.Name)
                .ToListAsync();
        }

        public async Task<List<Team>> SearchTeamsAsync(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return new List<Team>();

            keyword = keyword.Trim().ToLower();

            return await _context.Teams
                .Where(x =>
                    x.Name.ToLower().Contains(keyword) ||
                    x.Description.ToLower().Contains(keyword))
                .Where(x => x.Status != TH.ENTITIES.Enums.DataStatus.Deleted)
                .OrderBy(x => x.Name)
                .Take(10)
                .ToListAsync();
        }
    }
}