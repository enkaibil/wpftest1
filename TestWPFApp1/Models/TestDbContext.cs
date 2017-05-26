using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.EntityFrameworkCore;

namespace TestWPFApp1.Models
{
    public class TestDbContext : DbContext
    {
        public virtual DbSet<GT_Kenmei> GT_Kenmei { get; set; }
        public virtual DbSet<GT_Meisai> GT_Meisai { get; set; }
        public virtual DbSet<MT_Shubetsu> MT_Shubetsu { get; set; }

        public TestDbContext() : base()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            string conn = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
            options.UseSqlServer(conn);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GT_Kenmei>().HasKey(key => key.KojiNo);
            modelBuilder.Entity<GT_Meisai>().HasKey(key => new { key.KojiNo, key.No });
            modelBuilder.Entity<MT_Shubetsu>().HasKey(key => key.Code);
        }
    }
}
