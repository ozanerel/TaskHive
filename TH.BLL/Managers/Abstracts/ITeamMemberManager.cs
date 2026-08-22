using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TH.ENTITIES.Enums;
using TH.ENTITIES.Models;

namespace TH.BLL.Managers.Abstracts
{
    public interface ITeamMemberManager : IManager<TeamMember>
    {
        Task<List<TeamMember>> GetTeamMembersAsync(int teamId);

        Task<List<TeamMember>> GetUserTeamsAsync(int userId);

        Task<TeamMember> GetTeamMemberAsync(int teamId, int userId);

        Task<bool> IsUserInTeamAsync(int teamId, int userId);

        System.Threading.Tasks.Task RemoveMemberAsync(int teamId, int userId);

        Task<TeamMember> GetTeamMemberIncludingDeletedAsync(int teamId,int userId);

        Task<int> GetAdminCountAsync(int teamId);

        System.Threading.Tasks.Task UpdateTeamRoleAsync(int teamId, int userId, TeamRole teamRole);
    }
}