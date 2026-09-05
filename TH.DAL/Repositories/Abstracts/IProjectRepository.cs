using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TH.ENTITIES.Enums;
using TH.ENTITIES.Models;

namespace TH.DAL.Repositories.Abstracts
{
    public interface IProjectRepository:IRepository<Project>
    {
        Task<List<Project>> GetProjectsWithTasksAsync();
        Task<Project> GetProjectDetailsAsync(int id);
        Task<List<Project>> SearchProjectsAsync(string keyword);
        Task<List<Project>> SearchProjectsByUserAsync(string keyword,int userId);
        Task<List<Project>> GetDashboardProjectsAsync();
        Task<List<Project>> FilterProjectsAsync(string search, DataStatus? status, string sortBy,List<int> teamIds);
    }
}
