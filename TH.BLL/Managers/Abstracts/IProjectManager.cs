using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TH.ENTITIES.Enums;
using TH.ENTITIES.Models;
using Task = System.Threading.Tasks.Task;

namespace TH.BLL.Managers.Abstracts
{
    public interface IProjectManager:IManager<Project>
    {
        Task<List<Project>> GetProjectsWithTasksAsync();

        Task<Project> GetProjectDetailsAsync(int projectId);

        Task<List<Project>> GetProjectsByUserAsync(int userId);

        Task AddUserToProjectAsync(int projectId, int userId);
        Task<List<Project>> GetDashboardProjectsAsync();
        Task<List<Project>> FilterProjectsAsync(string search,DataStatus? status,string sortBy,List<int> teamIds);
    }
}
