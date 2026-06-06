using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TH.ENTITIES.Models;

namespace TH.DAL.Repositories.Abstracts
{
    public interface ITaskRepository : IRepository<ENTITIES.Models.Task>
    {
        Task<List<ENTITIES.Models.Task>> GetTasksByUserAsync(int userId);
        Task<List<ENTITIES.Models.Task>> GetTasksByProjectAsync(int projectId);
        Task<List<ENTITIES.Models.Task>> GetHighPriorityTasksAsync();
    }
}
