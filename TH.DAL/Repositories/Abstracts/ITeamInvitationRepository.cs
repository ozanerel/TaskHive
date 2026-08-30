using System.Collections.Generic;
using System.Threading.Tasks;
using TH.ENTITIES.Models;

namespace TH.DAL.Repositories.Abstracts
{
    public interface ITeamInvitationRepository : IRepository<TeamInvitation>
    {
        Task<TeamInvitation> GetPendingInvitationAsync(
            int teamId,
            int userId);

        Task<List<TeamInvitation>> GetUserInvitationsAsync(
            int userId);
    }
}