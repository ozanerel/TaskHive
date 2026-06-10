using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TH.DAL.Repositories.Abstracts;
using TH.DAL.Repositories.Concretes;

namespace TH.BLL.DependencyResolvers
{
    public static class RepositoryResolver
    {
        public static void AddRepositoryService(this IServiceCollection services)
        {
            services.AddScoped<IAppUserRepository, AppUserRepository>();
            services.AddScoped<IAppUserProfileRepository, AppUserProfileRepository>();
            services.AddScoped<INotificationRepository,NotificationRepository>();
            services.AddScoped<IProjectRepository,ProjectRepository>();
            services.AddScoped<IRoleRepository,RoleRepository>();
            services.AddScoped<ITaskCommentRepository,TaskCommentRepository>();
            services.AddScoped<ITaskRepository,TaskRepository>();
            services.AddScoped<IUserRepository,UserRepository>();
        }
    }
}
