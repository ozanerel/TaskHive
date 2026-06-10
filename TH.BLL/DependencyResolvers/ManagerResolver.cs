using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TH.BLL.Managers.Abstracts;
using TH.BLL.Managers.Concretes;

namespace TH.BLL.DependencyResolvers
{
    public static class ManagerResolver
    {
        public static void AddManagerService(this IServiceCollection services)
        {
            services.AddScoped<IAppUserManager,AppUserManager>();
            services.AddScoped<IAppUserProfileManager,AppUserProfileManager>();
            services.AddScoped<INotificationManager,NotificationManager>();
            services.AddScoped<IProjectManager,ProjectManager>();
            services.AddScoped<IRoleManager,RoleManager>();
            services.AddScoped<ITaskCommentManager,TaskCommentManager>();
            services.AddScoped<ITaskManager,TaskManager>();
            services.AddScoped<IUserManager,UserManager>();

        }
    }
}
