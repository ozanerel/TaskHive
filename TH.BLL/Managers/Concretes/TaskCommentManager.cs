using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TH.BLL.Managers.Abstracts;
using TH.DAL.Repositories.Abstracts;
using TH.DAL.Repositories.Concretes;
using TH.ENTITIES.Models;

namespace TH.BLL.Managers.Concretes
{
    public class TaskCommentManager : BaseManager<TaskComment>, ITaskCommentManager
    {
        private readonly ITaskCommentRepository _repository;

        public TaskCommentManager(ITaskCommentRepository repository)
            : base(repository)
        {
            _repository = repository;
        }

        public async Task<List<TaskComment>> GetCommentsByTaskAsync(int taskId)
        {
            return _repository
                .Where(x => x.TaskId == taskId)
                .ToList();
        }

        public async Task<List<TaskComment>> GetCommentsByUserAsync(int userId)
        {
            return await _repository
                .Where(x => x.UserId == userId)
                .ToListAsync();
        }
    }
}
