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
        private readonly IUserManager _userManager;

        public ProjectManager(IProjectRepository repository, INotificationManager notificationManager,IUserManager userManager)
            : base(repository)
        {
            _repository = repository;
            _notificationManager = notificationManager;
            _userManager = userManager;
        }

        public override async Task CreateAsync(Project project)
        {
            await base.CreateAsync(project);

            //await _notificationManager.CreateNotificationAsync(
            //    1, // Admin Id
            //    "New Project",
            //    $"{project.ProjectName} created.",NotificationType.ProjectCreated
            //);

            // Kullanıcılara bildir
            foreach (var user in project.Users)
            {
                await _notificationManager.CreateNotificationAsync(
                    user.Id,
                    "New Project Assigned",
                    $"{project.ProjectName} assigned to you.",
                    NotificationType.ProjectCreated
                );
            }

            var admins = await _userManager.GetAdminsAsync();

            foreach (var user in admins)
            {
                // Admin bildirimi
                await _notificationManager.CreateNotificationAsync(
                    user.Id,
                    "New Project Created",
                    $"{project.ProjectName} created.",
                    NotificationType.ProjectCreated
                );
            }
            
        }

        public override async Task MakePassiveAsync(Project project)
        {
            //Projeyi kullanıcılar ile birlikte getiriyoruz ki kullanıcıları da bildirelim.
            var projectWithUsers = await _repository.GetProjectDetailsAsync(project.Id);

            if (projectWithUsers == null)
                return;

            //Silinmeden önce kullanı listelerini alıyoruz
            var users = projectWithUsers.Users.ToList();

            //Soft delete işlemi
            await base.MakePassiveAsync(projectWithUsers);

            //Projeye bağlı kullanıcılara bildirim gönderiyoruz
            foreach (var user in users)
            {
                await _notificationManager.CreateNotificationAsync(
                    user.Id,
                    "Project Deleted",
                    $"Project \"{projectWithUsers.ProjectName}\" has been deleted.",
                    NotificationType.ProjectDeleted
                );
            }

            var admins = await _userManager.GetAdminsAsync();

            foreach (var user in admins)
            {
                await _notificationManager.CreateNotificationAsync(
                    user.Id,
                    "Project Deleted",
                    $"Project \"{projectWithUsers.ProjectName}\" has been deleted.",
                    NotificationType.ProjectDeleted
                );
            }

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
            //return await _repository
            //    .Where(x => x.Users.Any(u => u.Id == userId))
            //    .ToListAsync();

            return await _repository.GetProjectsByUserAsync(userId);
        }

        public async Task<List<Project>> GetDashboardProjectsAsync()
        {
            return await _repository.GetDashboardProjectsAsync();
        }

        public async Task<List<Project>> FilterProjectsAsync(string search, DataStatus? status, string sortBy,List<int> teamIds)
        {
            return await _repository.FilterProjectsAsync(search,status,sortBy,teamIds);
        }

        public async Task<Project> GetProjectDetailsByUserAsync(int projectId, int userId)
        {
            return await _repository.GetProjectDetailsByUserAsync(projectId,userId);
        }
    }
}
