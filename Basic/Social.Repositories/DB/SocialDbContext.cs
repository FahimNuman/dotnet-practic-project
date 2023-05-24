using Microsoft.EntityFrameworkCore;
using Social.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Repositories.DB
{
    public class SocialDbContext : DbContext
    {
        public SocialDbContext(DbContextOptions<SocialDbContext> options) : base(options)
        {
            
        }

        public virtual DbSet<DbRole> Roles { get; set; }
    }
}
