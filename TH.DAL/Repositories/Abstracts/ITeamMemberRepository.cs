using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TH.ENTITIES.Models;

namespace TH.DAL.Repositories.Abstracts
{
    public interface ITeamMemberRepository : IRepository<TeamMember>
    {
        Task<List<TeamMember>> GetTeamMembersAsync(int teamId);

        Task<List<TeamMember>> GetUserTeamsAsync(int userId);

        Task<TeamMember> GetTeamMemberAsync(int teamId, int userId);

        Task<bool> IsUserInTeamAsync(int teamId, int userId);
    }
}