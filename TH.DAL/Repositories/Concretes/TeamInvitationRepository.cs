using Microsoft.EntityFrameworkCore;
using TH.DAL.ContextClasses;
using TH.DAL.Repositories.Abstracts;
using TH.ENTITIES.Enums;
using TH.ENTITIES.Models;

namespace TH.DAL.Repositories.Concretes
{
    public class TeamInvitationRepository
        : BaseRepository<TeamInvitation>, ITeamInvitationRepository
    {
        private readonly MyContext _context;

        public TeamInvitationRepository(MyContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<TeamInvitation> GetPendingInvitationAsync(
            int teamId,
            int userId)
        {
            return await _context.TeamInvitations
                .Include(x => x.Team)
                .FirstOrDefaultAsync(x =>
                    x.TeamId == teamId &&
                    x.InvitedUserId == userId &&
                    x.InvitationStatus == InvitationStatus.Pending &&
                    x.Status != DataStatus.Deleted);
        }

        public async Task<List<TeamInvitation>> GetUserInvitationsAsync(
            int userId)
        {
            return await _context.TeamInvitations
                .Include(x => x.Team)
                .Include(x => x.InvitedByUser)
                .Where(x =>
                    x.InvitedUserId == userId &&
                    x.InvitationStatus == InvitationStatus.Pending &&
                    x.Status != DataStatus.Deleted)
                .OrderByDescending(x => x.CreatedDate)
                .ToListAsync();
        }
    }
}