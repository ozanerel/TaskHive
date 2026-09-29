using System.Collections.Generic;
using System.Threading.Tasks;
using TH.BLL.Managers.Abstracts;
using TH.DAL.Repositories.Abstracts;
using TH.ENTITIES.Models;

namespace TH.BLL.Managers.Concretes
{
    public class TaskMemberManager : ITaskMemberManager
    {
        readonly ITaskMemberRepository _repository;

        public TaskMemberManager(ITaskMemberRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<TaskMember>> GetByTaskIdAsync(int taskId)
        {
            return await _repository.GetByTaskIdAsync(taskId);
        }

        public async Task<TaskMember> GetAsync(
            int taskId,
            int userId)
        {
            return await _repository.GetAsync(
                taskId,
                userId);
        }

        public async System.Threading.Tasks.Task CreateAsync(TaskMember taskMember)
        {
            await _repository.CreateAsync(taskMember);
        }

        public async System.Threading.Tasks.Task DeleteAsync(TaskMember taskMember)
        {
            await _repository.DeleteAsync(taskMember);
        }
    }
}