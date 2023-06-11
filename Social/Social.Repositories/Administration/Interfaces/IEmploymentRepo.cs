using Social.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Repositories.Administration.Interfaces
{
    public interface IEmploymentRepo
    {
        Task<IEnumerable<DbEmployment>> GetAllEmploymentsAsync();
        Task<DbEmployment?> GetEmploymentByIdAsync(int employmentId);
        Task<int> SaveEmploymentAsync(DbEmployment model);
        Task<bool> UpdateEmploymentAsync(DbEmployment model);
        Task<bool> DeleteEmploymentAsync(DbEmployment model);
    }
}
