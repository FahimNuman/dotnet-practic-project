using Microsoft.Extensions.DependencyInjection;
using Social.Repositories.Administration.Interfaces;
using Social.Repositories.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Repositories.Utilities
{
    public static class SericeCollections
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IRoleRepo, RoleRepo>();
            services.AddTransient<IUserRepo, UserRepo>();
            return services;
        }
    }
}
