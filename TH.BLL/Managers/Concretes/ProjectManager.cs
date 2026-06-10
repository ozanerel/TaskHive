using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TH.BLL.Managers.Abstracts;
using TH.DAL.Repositories.Abstracts;
using TH.ENTITIES.Models;

namespace TH.BLL.Managers.Concretes
{
    public class ProjectManager : BaseManager<Project>, IProjectManager
    {
        private readonly IProjectRepository _repository;

        public ProjectManager(IProjectRepository repository)
            : base(repository)
        {
            _repository = repository;
        }

        public async Task<Project> GetProjectDetailsAsync(int projectId)
        {
            return await _repository.GetProjectDetailsAsync(projectId);
        }

        public async Task<List<Project>> GetProjectsWithTasksAsync()
        {
            return await _repository.GetProjectsWithTasksAsync();
        }

        public async System.Threading.Tasks.Task AddUserToProjectAsync(int projectId, int userId)
        {
            // Şimdilik boş bırakılabilir.
            // İleride UserProject tablosu eklersek burada kullanacağız.

            await System.Threading.Tasks.Task.CompletedTask;
        }
    }
}
