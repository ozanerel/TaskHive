using TH.BLL.Managers.Abstracts;
using TH.DAL.Repositories.Abstracts;
using TH.ENTITIES.Models;

namespace TH.BLL.Managers.Concretes
{
    public class TeamManager : BaseManager<Team>, ITeamManager
    {
        private readonly ITeamRepository _repository;

        public TeamManager(ITeamRepository repository)
            : base(repository)
        {
            _repository = repository;
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
    }
}