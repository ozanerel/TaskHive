using TH.BLL.Managers.Abstracts;
using TH.DAL.Repositories.Abstracts;
using TH.ENTITIES.Models;

namespace TH.BLL.Managers.Concretes
{
    public class TeamInvitationManager
        : BaseManager<TeamInvitation>,
          ITeamInvitationManager
    {
        private readonly ITeamInvitationRepository _repository;

        public TeamInvitationManager(
            ITeamInvitationRepository repository)
            : base(repository)
        {
            _repository = repository;
        }

        public async Task<TeamInvitation> GetPendingInvitationAsync(
            int teamId,
            int userId)
        {
            return await _repository
                .GetPendingInvitationAsync(teamId, userId);
        }

        public async Task<List<TeamInvitation>> GetUserInvitationsAsync(
            int userId)
        {
            return await _repository
                .GetUserInvitationsAsync(userId);
        }
    }
}