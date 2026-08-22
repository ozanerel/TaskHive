using TH.BLL.Managers.Abstracts;
using TH.DAL.Repositories.Abstracts;
using TH.ENTITIES.Enums;
using TH.ENTITIES.Models;

namespace TH.BLL.Managers.Concretes
{
    public class TeamMemberManager : BaseManager<TeamMember>, ITeamMemberManager
    {
        private readonly ITeamMemberRepository _repository;

        public TeamMemberManager(ITeamMemberRepository repository)
            : base(repository)
        {
            _repository = repository;
        }

        public async Task<List<TeamMember>> GetTeamMembersAsync(int teamId)
        {
            return await _repository.GetTeamMembersAsync(teamId);
        }

        public async Task<List<TeamMember>> GetUserTeamsAsync(int userId)
        {
            return await _repository.GetUserTeamsAsync(userId);
        }

        public async Task<TeamMember> GetTeamMemberAsync(int teamId, int userId)
        {
            return await _repository.GetTeamMemberAsync(teamId, userId);
        }

        public async Task<bool> IsUserInTeamAsync(int teamId, int userId)
        {
            return await _repository.IsUserInTeamAsync(teamId, userId);
        }

        public async System.Threading.Tasks.Task RemoveMemberAsync(int teamId, int userId)
        {
            var teamMember = await _repository.GetTeamMemberAsync(teamId, userId);

            if (teamMember == null)
                return;

            teamMember.Status = DataStatus.Deleted;

            await _repository.UpdateAsync(teamMember, teamMember);
        }

        public async Task<TeamMember> GetTeamMemberIncludingDeletedAsync(int teamId,int userId)
        {
            return await _repository.GetTeamMemberIncludingDeletedAsync(
                teamId,
                userId);
        }

        public async Task<int> GetAdminCountAsync(int teamId)
        {
            return await _repository.GetAdminCountAsync(teamId);
        }

        public async System.Threading.Tasks.Task UpdateTeamRoleAsync(int teamId, int userId, TeamRole teamRole)
        {
            await _repository.UpdateTeamRoleAsync(teamId,userId,teamRole);
        }
    }
}