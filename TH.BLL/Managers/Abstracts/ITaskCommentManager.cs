using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TH.ENTITIES.Models;

namespace TH.BLL.Managers.Abstracts
{
    public interface ITaskCommentManager:IManager<TH.ENTITIES.Models.TaskComment>
    {
        Task<List<TaskComment>> GetCommentsByTaskAsync(int taskId);
        Task<List<TaskComment>> GetCommentsByUserAsync(int userId);
        Task<TaskComment> GetCommentByUserAsync(int commentId, int userId);
        Task<TaskComment> GetCommentDetailsAsync(int commentId);
        System.Threading.Tasks.Task DeleteCommentByTeamAdminAsync(int commentId, int teamAdminUserId);
        Task<List<TaskComment>> GetCommentsByTeamIdsAsync(List<int> teamIds);
    }
}
