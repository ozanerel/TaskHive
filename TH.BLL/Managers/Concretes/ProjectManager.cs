using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TH.BLL.Managers.Abstracts;
using TH.DAL.Repositories.Abstracts;
using TH.ENTITIES.Enums;
using TH.ENTITIES.Models;
using Task = System.Threading.Tasks.Task;

namespace TH.BLL.Managers.Concretes
{
    public class ProjectManager : BaseManager<Project>, IProjectManager
    {
        private readonly IProjectRepository _repository;
        private readonly INotificationManager _notificationManager;

        public ProjectManager(IProjectRepository repository, INotificationManager notificationManager)
            : base(repository)
        {
            _repository = repository;
            _notificationManager = notificationManager;
        }

        public override async Task CreateAsync(Project project)
        {
            await base.CreateAsync(project);

            await _notificationManager.CreateNotificationAsync(
                1, // Admin Id
                "New Project",
                $"{project.ProjectName} created.",NotificationType.ProjectCreated
            );
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

        public async Task<List<Project>> GetProjectsByUserAsync(int userId)
        {
            return await _repository
                .Where(x => x.Users.Any(u => u.Id == userId))
                .ToListAsync();
        }

        public async Task<List<Project>> GetDashboardProjectsAsync()
        {
            return await _repository.GetDashboardProjectsAsync();
        }
    }
}
