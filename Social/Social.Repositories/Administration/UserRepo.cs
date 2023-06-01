using Microsoft.EntityFrameworkCore;
using Social.Common.Utilities;
using Social.Models.DbModels;
using Social.Models.VwModel;
using Social.Repositories.Administration.Interfaces;
using Social.Repositories.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Repositories.Administration
{
    public class UserRepo: IUserRepo
    {
        private readonly SocialDbContext _dbContext;
        public UserRepo(SocialDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<VwUser>> GetAllUserAsync()
        {
            return await _dbContext.Users.Select(x => new VwUser
            {
                Id=x.Id,
                Name=x.Name,
                Email=x.Email,
                RoleId=x.RoleId,
                Role=x.Role,
                CreatedBy =x.CreatedBy,
                CreatedDate=x.CreatedDate,
                UpdatedBy=x.UpdatedBy,
                UpdatedDate=x.UpdatedDate,

            }).ToListAsync();
        }


        public async Task<VwUser?> GetUserByIdAsync(int id)
        {
            return await _dbContext.Users.Where(x => x.Id == id).Select(x => new VwUser
            {
                Id = x.Id,
                Name = x.Name,
                Email = x.Email,
                RoleId = x.RoleId,
                Role = x.Role,
                CreatedBy = x.CreatedBy,
                CreatedDate = x.CreatedDate,
                UpdatedBy = x.UpdatedBy,
                UpdatedDate = x.UpdatedDate,

            }).FirstOrDefaultAsync();
        }


        public async Task<VwUser?> GetUserByEmailAsync(string email)
        {
            return await _dbContext.Users.Where(x => x.Email.ToLower() == email.ToLower()).Select(x => new VwUser
            {
                Id = x.Id,
                Name = x.Name,
                Email = x.Email,
                RoleId = x.RoleId,
                Role = x.Role,
                CreatedBy = x.CreatedBy,
                CreatedDate = x.CreatedDate,
                UpdatedBy = x.UpdatedBy,
                UpdatedDate = x.UpdatedDate,

            }).FirstOrDefaultAsync();
        }

        public async Task<VwUser?> GetAuthorizedUserAsync(string email, string password)
        {
            return await _dbContext.Users.Where(x => x.Email.ToLower() == email.ToLower() && x.Password == password).Select(x => new VwUser
            {
                Id = x.Id,
                Name = x.Name,
                Email = x.Email,
                RoleId = x.RoleId,
                Role = x.Role,
                CreatedBy = x.CreatedBy,
                CreatedDate = x.CreatedDate,
                UpdatedBy = x.UpdatedBy,
                UpdatedDate = x.UpdatedDate,

            }).FirstOrDefaultAsync();
        }

        public async Task<VwUser?> SaveUserAsync(DbUser model)
        {
            if(model == null) { 
                throw new ArgumentNullException("User can't be null",nameof(model)); 
            }

            bool isExit = await _dbContext.Users.AnyAsync(x => x.Email.ToLower() == model.Email.ToLower());

            if(isExit)
            {
                throw new Exception(ConstantMessages.DataExist);
            }

            await _dbContext.Users.AddAsync(model);
            await _dbContext.SaveChangesAsync();

            return await GetUserByIdAsync(model.Id);
        }

    }
}
