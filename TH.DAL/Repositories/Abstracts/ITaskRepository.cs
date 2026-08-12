using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TH.ENTITIES.Enums;
using TH.ENTITIES.Models;

namespace TH.DAL.Repositories.Abstracts
{
    public interface ITaskRepository : IRepository<ENTITIES.Models.Task>
    {
        Task<List<ENTITIES.Models.Task>> GetTasksByUserAsync(int userId);
        Task<List<ENTITIES.Models.Task>> GetTasksByProjectAsync(int projectId);
        Task<List<ENTITIES.Models.Task>> GetHighPriorityTasksAsync();
        Task<List<ENTITIES.Models.Task>> SearchTasksAsync(string keyword);
        Task<List<ENTITIES.Models.Task>> SearchTasksByUserAsync(string keyword,int userId);

        Task<ENTITIES.Models.Task> GetTaskDetailsAsync(int id);
        Task<List<ENTITIES.Models.Task>> FilterTasksAsync(string search,PriorityLevel? priority,bool? isCompleted);

        Task<ENTITIES.Models.Task> GetTaskDetailsByUserAsync(int taskId, int userId);
    }
}
