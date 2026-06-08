using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TH.ENTITIES.Models;
using Task = System.Threading.Tasks.Task;

namespace TH.BLL.Managers.Abstracts
{
    public interface IProjectManager:IManager<Project>
    {
        Task<List<Project>> GetProjectsWithTasksAsync();

        Task<Project> GetProjectDetailsAsync(int projectId);

        Task AddUserToProjectAsync(int projectId, int userId);
    }
}
