using Microsoft.EntityFrameworkCore;
using Social.Repository.Db;
using Social.Repository.Modules.Interfaces;
using SocialApp.Models.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Repository.Modules
{
	public class UserRepository: IUserRepository
	{
		private readonly SocialDbContext _socialDbContext;
		public UserRepository(SocialDbContext socialDbContext) { 
			_socialDbContext = socialDbContext;
		}

		public async Task<IEnumerable<DbUser>>  GetAllUsers()
		{
			return await _socialDbContext.Users.ToListAsync();
		}
	}
}
