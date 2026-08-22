using Microsoft.EntityFrameworkCore;
using TH.DAL.ContextClasses;
using TH.DAL.Repositories.Abstracts;
using TH.ENTITIES.Enums;
using TH.ENTITIES.Models;

namespace TH.DAL.Repositories.Concretes
{
    public class TeamMemberRepository : BaseRepository<TeamMember>, ITeamMemberRepository
    {
        private readonly MyContext _context;

        public TeamMemberRepository(MyContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<List<TeamMember>> GetTeamMembersAsync(int teamId)
        {
            return await _context.TeamMembers
                .Include(x => x.User)
                    .ThenInclude(x => x.Role)
                .Where(x => x.TeamId == teamId)
                .Where(x => x.Status != TH.ENTITIES.Enums.DataStatus.Deleted)
                .ToListAsync();
        }

        public async Task<List<TeamMember>> GetUserTeamsAsync(int userId)
        {
            return await _context.TeamMembers
                .Include(x => x.Team)
                .Where(x => x.UserId == userId)
                .Where(x => x.Status != TH.ENTITIES.Enums.DataStatus.Deleted)
                .ToListAsync();
        }

        public async Task<TeamMember> GetTeamMemberAsync(int teamId, int userId)
        {
            return await _context.TeamMembers
                .Include(x => x.Team)
                .Include(x => x.User)
                    .ThenInclude(x => x.Role)
                .FirstOrDefaultAsync(x =>
                    x.TeamId == teamId &&
                    x.UserId == userId &&
                    x.Status != ENTITIES.Enums.DataStatus.Deleted);
        }

        public async Task<bool> IsUserInTeamAsync(int teamId, int userId)
        {
            return await _context.TeamMembers
                .AnyAsync(x =>
                    x.TeamId == teamId &&
                    x.UserId == userId &&
                    x.Status != TH.ENTITIES.Enums.DataStatus.Deleted);
        }

        public async Task<List<int>> GetTeamMemberUserIdsAsync(int teamId)
        {
            return await _context.TeamMembers
                .Where(x =>
                    x.TeamId == teamId &&
                    x.Status != TH.ENTITIES.Enums.DataStatus.Deleted)
                .Select(x => x.UserId)
                .ToListAsync();
        }

        public async Task<TeamMember> GetTeamMemberIncludingDeletedAsync(int teamId,int userId)
        {
            return await _context.TeamMembers
                .Include(x => x.Team)
                .Include(x => x.User)
                    .ThenInclude(x => x.Role)
                .FirstOrDefaultAsync(x =>
                    x.TeamId == teamId &&
                    x.UserId == userId);
        }

        public async Task<int> GetAdminCountAsync(int teamId)
        {
            return await _context.TeamMembers
                .CountAsync(x =>
                x.TeamId == teamId &&
                x.TeamRole == TH.ENTITIES.Enums.TeamRole.Admin &&
                x.Status != TH.ENTITIES.Enums.DataStatus.Deleted);
        }

        public async System.Threading.Tasks.Task UpdateTeamRoleAsync(int teamId, int userId, TeamRole teamRole)
        {
            var teamMember = await _context.TeamMembers
                .FirstOrDefaultAsync(x =>
                x.TeamId == teamId &&
                x.UserId == userId &&
                x.Status != DataStatus.Deleted);

            if (teamMember == null)
                return;

            teamMember.TeamRole = teamRole;

            await _context.SaveChangesAsync();
        }
    }
}