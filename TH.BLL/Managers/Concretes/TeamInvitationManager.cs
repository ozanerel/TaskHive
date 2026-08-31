using TH.BLL.Managers.Abstracts;
using TH.DAL.Repositories.Abstracts;
using TH.ENTITIES.Enums;
using TH.ENTITIES.Models;

namespace TH.BLL.Managers.Concretes
{
    public class TeamInvitationManager
        : BaseManager<TeamInvitation>,
          ITeamInvitationManager
    {
        private readonly ITeamInvitationRepository _repository;
        private readonly ITeamMemberRepository _teamMemberRepository;

        public TeamInvitationManager(
            ITeamInvitationRepository repository,
            ITeamMemberRepository teamMemberRepository)
            : base(repository)
        {
            _repository = repository;
            _teamMemberRepository = teamMemberRepository;
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

        public async Task<bool> SendInvitationAsync(
            int teamId,
            int invitedUserId,
            int invitedByUserId)
        {
            var existingInvitation =
                await _repository.GetPendingInvitationAsync(
                    teamId,
                    invitedUserId);

            if (existingInvitation != null)
                return false;

            var invitation = new TeamInvitation
            {
                TeamId = teamId,
                InvitedUserId = invitedUserId,
                InvitedByUserId = invitedByUserId,
                InvitationStatus = InvitationStatus.Pending
            };

            await base.CreateAsync(invitation);

            return true;
        }

        public async Task<bool> AcceptInvitationAsync(
            int invitationId,
            int userId)
        {
            var invitation =
                await _repository.GetByIdAsync(invitationId);

            if (invitation == null)
                return false;

            if (invitation.InvitedUserId != userId)
                return false;

            if (invitation.Status == DataStatus.Deleted)
                return false;

            if (invitation.InvitationStatus != InvitationStatus.Pending)
                return false;

            var existingMember =
                await _teamMemberRepository.GetTeamMemberIncludingDeletedAsync(
                    invitation.TeamId,
                    userId);

            if (existingMember != null)
            {
                if (existingMember.Status != DataStatus.Deleted)
                {
                    return false;
                }

                existingMember.Status = DataStatus.Inserted;
                existingMember.TeamRole = TeamRole.Member;

                await _teamMemberRepository.UpdateAsync(
                    existingMember,
                    existingMember);
            }
            else
            {
                var teamMember = new TeamMember
                {
                    TeamId = invitation.TeamId,
                    UserId = userId,
                    TeamRole = TeamRole.Member
                };

                teamMember.CreatedDate = DateTime.Now;
                teamMember.Status = DataStatus.Inserted;

                await _teamMemberRepository.CreateAsync(teamMember);
            }

            invitation.InvitationStatus = InvitationStatus.Accepted;
            invitation.Status = DataStatus.Updated;
            invitation.UpdatedDate = DateTime.Now;

            await _repository.UpdateAsync(
                invitation,
                invitation);

            return true;
        }

        public async Task<bool> RejectInvitationAsync(
            int invitationId,
            int userId)
        {
            var invitation =
                await _repository.GetByIdAsync(invitationId);

            if (invitation == null)
                return false;

            if (invitation.InvitedUserId != userId)
                return false;

            if (invitation.Status == DataStatus.Deleted)
                return false;

            if (invitation.InvitationStatus != InvitationStatus.Pending)
                return false;

            invitation.InvitationStatus = InvitationStatus.Rejected;
            invitation.Status = DataStatus.Updated;
            invitation.UpdatedDate = DateTime.Now;

            await _repository.UpdateAsync(
                invitation,
                invitation);

            return true;
        }
    }
}