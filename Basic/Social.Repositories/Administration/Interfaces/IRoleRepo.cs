using Social.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Repositories.Administration.Interfaces
{
    public interface IRoleRepo
    {
        Task<IEnumerable<DbRole>> GetAllRolesAsync();
        Task<DbRole?> GetRoleByIdAsync(int roleId);
        Task<int> SaveRoleAsync(DbRole model);
        Task<bool> UpdateRoleAsync(DbRole model);
        Task<bool> DeleteRoleAsync(DbRole model);
    }
}
