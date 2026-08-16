using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TH.ENTITIES.Models;

namespace TH.DAL.Repositories.Abstracts
{
    public interface ITeamRepository : IRepository<Team>
    {
        Task<Team> GetTeamDetailsAsync(int teamId);

        Task<List<Team>> GetTeamsByUserAsync(int userId);

        Task<List<Team>> SearchTeamsAsync(string keyword);
    }
}