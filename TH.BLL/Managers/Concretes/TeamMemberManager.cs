using TH.BLL.Managers.Abstracts;
using TH.DAL.Repositories.Abstracts;
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
    }
}