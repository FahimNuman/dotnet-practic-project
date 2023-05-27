using Microsoft.EntityFrameworkCore;
using Social.Models.DbModels;
using Social.Repositories.Administration.Interfaces;
using Social.Repositories.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Repositories.Administration
{
    public class RoleRepo :IRoleRepo
    {
        private readonly SocialDbContext _socialDbContext;
        public RoleRepo(SocialDbContext socialDbContext) {
            _socialDbContext = socialDbContext;
        }

        public async Task<IEnumerable<DbRole>> GetAllRolesAsync()
        {
            return await _socialDbContext.Roles.AsNoTracking().OrderByDescending(x => x.Id).ToListAsync();
        }

        public async Task<DbRole?> GetRoleByIdAsync(int roleId)
        {
            return await _socialDbContext.Roles.Where(x => x.Id == roleId).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<int> SaveRoleAsync(DbRole model)
        {
            await _socialDbContext.Roles.AddAsync(model);
            return await _socialDbContext.SaveChangesAsync();
        }

        public async Task<bool> UpdateRoleAsync(DbRole model)
        {
            bool isSuccess = true;
            DbRole? dbRole = await _socialDbContext.Roles.Where(x => x.Id == model.Id).FirstOrDefaultAsync();

            if(dbRole == null)
            {
                isSuccess = false;
            }

            dbRole.Name = model.Name;
            dbRole.UpdatedDate = DateTime.Now;
            dbRole.UpdatedBy = model.UpdatedBy;
            _socialDbContext.Roles.Update(dbRole);
            await _socialDbContext.SaveChangesAsync();

            return isSuccess;
        }


        public async Task<bool> DeleteRoleAsync(DbRole model)
        {
            bool isSuccess = true;
            DbRole? dbRole = await _socialDbContext.Roles.Where(x => x.Id == model.Id).FirstOrDefaultAsync();

            if (dbRole == null)
            {
                isSuccess = false;
            }

            _socialDbContext.Roles.Remove(dbRole);
            await _socialDbContext.SaveChangesAsync();

            return isSuccess;
        }
    }
}
