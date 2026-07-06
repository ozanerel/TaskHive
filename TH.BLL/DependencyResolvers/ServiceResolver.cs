using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TH.BLL.Services.Abstracts;
using TH.BLL.Services.Concretes;

namespace TH.BLL.DependencyResolvers
{
    public static class ServiceResolver
    {
        public static void AddService(this IServiceCollection services)
        {
            services.AddScoped<IUserContext,UserContext>();
        }
    }
}
