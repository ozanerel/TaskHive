using System.Collections.Generic;
using System.Threading.Tasks;
using TH.ENTITIES.Models;

namespace TH.BLL.Managers.Abstracts
{
    public interface ITaskMemberManager
    {
        Task<List<TaskMember>> GetByTaskIdAsync(int taskId);
        Task<TaskMember> GetAsync(int taskId, int userId);
        System.Threading.Tasks.Task CreateAsync(TaskMember taskMember);
        System.Threading.Tasks.Task DeleteAsync(TaskMember taskMember);
    }
}