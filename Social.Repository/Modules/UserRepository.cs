using Microsoft.EntityFrameworkCore;
using Social.Common.Utilities;
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

		public async Task<IEnumerable<DbUser>>  GetAllUsersAsync()
		{
			return await _socialDbContext.Users.ToListAsync();
		}

		public async Task<DbUser> SaveUserAsync(DbUser model)
		{
			if(model == null)
			{
				throw new NullReferenceException(ConstantMessages.NullException);
			}

			bool isExist = await _socialDbContext.Users.AnyAsync( x => x.Email == model.Email);
			
			if(isExist)
			{
				throw new Exception(ConstantMessages.DataExist);
			}

			await _socialDbContext.Users.AddAsync(model);

			return model;
		}
	}
}
