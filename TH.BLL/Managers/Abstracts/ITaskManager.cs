using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TH.BLL.DTOs.Task;
using TH.ENTITIES.Enums;

namespace TH.BLL.Managers.Abstracts
{
    public interface ITaskManager:IManager<TH.ENTITIES.Models.Task>
    {
        Task AssignTaskAsync(int taskId, int userId);

        Task ChangePriorityAsync(int taskId, PriorityLevel priority);

        Task<List<TH.ENTITIES.Models.Task>> GetTasksByUserAsync(int userId);

        Task<List<TH.ENTITIES.Models.Task>> GetTasksByProjectAsync(int projectId);

        Task CompleteTaskAsync(int taskId,int userId);

        Task<ENTITIES.Models.Task> GetTaskDetailsAsync(int id);

        Task<List<TH.ENTITIES.Models.Task>> FilterTasksAsync(string search,PriorityLevel? priority,bool? isCompleted,List<int> teamIds);

        Task<ENTITIES.Models.Task> GetTaskDetailsByUserAsync(int taskId,int userId);

        Task<TaskAnalyticsDto> GetTaskAnalyticsAsync(List<int> teamIds);

        Task<List<ProjectTaskAnalyticsDto>> GetProjectTaskAnalyticsAsync(List<int> teamIds);

        Task<List<UserTaskAnalyticsDto>> GetUserTaskAnalyticsAsync(List<int> teamIds);

        Task<List<TaskAssignmentSuggestionDto>> GetTaskAssignmentSuggestionsAsync(List<int> teamIds);
    }
}
