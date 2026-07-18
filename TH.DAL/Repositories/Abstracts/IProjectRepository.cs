using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TH.ENTITIES.Models;

namespace TH.DAL.Repositories.Abstracts
{
    public interface IProjectRepository:IRepository<Project>
    {
        Task<List<Project>> GetProjectsWithTasksAsync();
        Task<Project> GetProjectDetailsAsync(int id);
        Task<List<Project>> SearchProjectsAsync(string keyword);
        Task<List<Project>> GetDashboardProjectsAsync();
    }
}
