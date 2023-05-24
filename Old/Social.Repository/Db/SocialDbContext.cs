using Microsoft.EntityFrameworkCore;
using SocialApp.Models.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Repository.Db
{
	public class SocialDbContext : DbContext
	{
        public SocialDbContext(DbContextOptions<SocialDbContext> options) :base(options)
        {
            
        }

        public virtual DbSet<DbUser> Users { get; set; }
    }
}
