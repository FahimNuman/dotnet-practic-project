using SocialApp.Models.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Repository.Modules.Interfaces
{
	public interface IUserRepository
	{
		Task<IEnumerable<DbUser>> GetAllUsers();
	}
}
