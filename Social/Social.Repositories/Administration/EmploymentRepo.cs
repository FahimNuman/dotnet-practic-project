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
    public class EmploymentRepo: IEmploymentRepo
    {
        private readonly SocialDbContext _socialDbContext;
        public EmploymentRepo(SocialDbContext socialDbContext)
        {
            _socialDbContext = socialDbContext;
        }

        public async Task<IEnumerable<DbEmployment>> GetAllEmploymentsAsync()
        {
            return await _socialDbContext.Employments.AsNoTracking().OrderByDescending(x => x.StartDate).ToListAsync();
        }

        public async Task<DbEmployment?> GetEmploymentByIdAsync(int employmentId)
        {
            return await _socialDbContext.Employments.Where(x => x.Id == employmentId).AsNoTracking().SingleOrDefaultAsync();
        }

        public async Task<int> SaveEmploymentAsync(DbEmployment model)
        {
            await _socialDbContext.Employments.AddAsync(model);
            return await _socialDbContext.SaveChangesAsync();
        }

        public async Task<bool> UpdateEmploymentAsync(DbEmployment model)
        {
            bool isSuccess = true;
            DbEmployment? employment = await _socialDbContext.Employments.Where(x => x.Id == model.Id).SingleOrDefaultAsync();

            if (employment == null)
            {
                isSuccess = false;
            }

            employment.JobTitle = model.JobTitle;
            employment.CompanyName = model.CompanyName;
            employment.StartDate = model.StartDate;
            employment.EndDate = model.EndDate;
            employment.UpdatedDate = DateTime.Now;
            employment.UpdatedBy = model.UpdatedBy;
            _socialDbContext.Employments.Update(employment);
            await _socialDbContext.SaveChangesAsync();

            return isSuccess;
        }

        public async Task<bool> DeleteEmploymentAsync(DbEmployment model)
        {
            bool isSuccess = true;
            DbEmployment? employment = await _socialDbContext.Employments.Where(x => x.Id == model.Id).SingleOrDefaultAsync();

            if (employment == null)
            {
                isSuccess = false;
            }

            _socialDbContext.Employments.Remove(employment);
            await _socialDbContext.SaveChangesAsync();

            return isSuccess;
        }

    }
}
