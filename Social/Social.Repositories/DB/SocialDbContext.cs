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

        #region Configuration

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DbEducationalLevel>().HasData(
               new DbEducationalLevel
               {
                   Id = 1,
                   Name = "Primary School"
               },
               new DbEducationalLevel
               {
                   Id = 2,
                   Name = "Secondary School"
               },
               new DbEducationalLevel
               {
                   Id = 3,
                   Name = "College"
               },
               new DbEducationalLevel
               {
                   Id = 4,
                   Name = "University"
               }
           );
        }
        #endregion

        public virtual DbSet<DbRole> Roles { get; set; }
        public virtual DbSet<DbUser> Users { get; set; }
        public virtual DbSet<DbEmployment> Employments { get; set; }
        public virtual DbSet<DbEducationalLevel> EducationalLevels { get; set; }
    }
}
