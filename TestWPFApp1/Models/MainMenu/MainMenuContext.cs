using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWPFApp1.Models.MainMenu
{
    public class MainMenuContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            string conn = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
            options.UseSqlServer(conn);
        }
    }
}
