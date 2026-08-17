using TH.BLL.Managers.Abstracts;
using TH.DAL.Repositories.Abstracts;
using TH.ENTITIES.Enums;
using TH.ENTITIES.Models;

namespace TH.BLL.Managers.Concretes
{
    public class TeamManager : BaseManager<Team>, ITeamManager
    {
        private readonly ITeamRepository _repository;
        private readonly ITeamMemberManager _teamMemberManager;

        public TeamManager(ITeamRepository repository,ITeamMemberManager teamMemberManager)
            : base(repository)
        {
            _repository = repository;
            _teamMemberManager = teamMemberManager;
        }

        public async Task<Team> GetTeamDetailsAsync(int teamId)
        {
            return await _repository.GetTeamDetailsAsync(teamId);
        }

        public async Task<List<Team>> GetTeamsByUserAsync(int userId)
        {
            return await _repository.GetTeamsByUserAsync(userId);
        }

        public async Task<List<Team>> SearchTeamsAsync(string keyword)
        {
            return await _repository.SearchTeamsAsync(keyword);
        }

        public async System.Threading.Tasks.Task CreateTeamWithAdminAsync(Team team,int userId)
        {
            await CreateAsync(team);

            var teamMember = new TeamMember
            {
                TeamId = team.Id,
                UserId = userId,
                TeamRole = TeamRole.Admin,
                Status = DataStatus.Inserted
            };

            await _teamMemberManager.CreateAsync(teamMember);
        }
    }
}