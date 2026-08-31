using System.Collections.Generic;
using System.Threading.Tasks;
using TH.ENTITIES.Models;

namespace TH.BLL.Managers.Abstracts
{
    public interface ITeamInvitationManager
        : IManager<TeamInvitation>
    {
        Task<TeamInvitation> GetPendingInvitationAsync(
            int teamId,
            int userId);

        Task<List<TeamInvitation>> GetUserInvitationsAsync(
            int userId);

        Task<bool> AcceptInvitationAsync(int invitationId, int userId);

        Task<bool> RejectInvitationAsync(int invitationId, int userId);

        Task<bool> SendInvitationAsync(int teamId,int invitedUserId,int invitedByUserId);
    }
}