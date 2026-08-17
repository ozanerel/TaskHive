using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TH.ENTITIES.Models;

namespace TH.BLL.Managers.Abstracts
{
    public interface ITeamManager : IManager<Team>
    {
        Task<Team> GetTeamDetailsAsync(int teamId);

        Task<List<Team>> GetTeamsByUserAsync(int userId);

        Task<List<Team>> SearchTeamsAsync(string keyword);

        System.Threading.Tasks.Task CreateTeamWithAdminAsync(Team team, int userId);
    }
}