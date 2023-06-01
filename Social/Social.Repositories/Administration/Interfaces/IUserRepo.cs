using Social.Models.DbModels;
using Social.Models.VwModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Repositories.Administration.Interfaces
{
    public interface IUserRepo
    {
        Task<IEnumerable<VwUser>> GetAllUserAsync();
        Task<VwUser?> GetUserByIdAsync(int id);
        Task<VwUser?> GetUserByEmailAsync(string email);
        Task<VwUser?> GetAuthorizedUserAsync(string email, string password);
        Task<VwUser?> SaveUserAsync(DbUser model);
    }
}
