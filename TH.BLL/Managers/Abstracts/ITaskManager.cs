using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TH.ENTITIES.Enums;

namespace TH.BLL.Managers.Abstracts
{
    public interface ITaskManager:IManager<TH.ENTITIES.Models.Task>
    {
        Task AssignTaskAsync(int taskId, int userId);

        Task ChangePriorityAsync(int taskId, PriorityLevel priority);

        Task<List<Task>> GetTasksByUserAsync(int userId);

        Task<List<Task>> GetTasksByProjectAsync(int projectId);

        Task CompleteTaskAsync(int taskId);
    }
}
