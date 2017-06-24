using Microsoft.EntityFrameworkCore;
using NSS.HanbaiKanri.DataAccess.Models.MasterTables;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSS.HanbaiKanri.DataAccess
{
    public class NSSDBContext : DbContext
    {
        public virtual DbSet<MT_Shubetsu> MT_Shubetsu { get; set; }

        public NSSDBContext() : base()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            string conn = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
            options.UseSqlServer(conn);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MT_Shubetsu>().HasKey(key => key.Code);
        }
    }
}
