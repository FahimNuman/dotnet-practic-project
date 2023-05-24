using Microsoft.Extensions.DependencyInjection;
using Social.Repository.Modules;
using Social.Repository.Modules.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Repository.Utilitites
{
	public static class ServiceCollections
	{
		public static IServiceCollection AddRepositories(IServiceCollection services)
		{

			services.AddTransient<IUserRepository, UserRepository>();
			return services;
		}
	}
}
