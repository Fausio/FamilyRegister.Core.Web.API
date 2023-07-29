using Data.Helper;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.AppDBContext
{
    public class FamilyRegisterDbContext : DbContext
    {
        public FamilyRegisterDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(AppSettings.SqlServer);
            }
        }

        //public FamilyRegisterDbContext()
        //{

        //}
        public FamilyRegisterDbContext(DbContextOptions opts) :base(opts)
        {
            
        }

        public DbSet<Family> Families { get; set; }
    }
}
