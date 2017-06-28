using Microsoft.EntityFrameworkCore;
using NSS.HanbaiKanri.DataAccess.BusinessLogic.Common;
using NSS.HanbaiKanri.DataAccess.Models.MasterTables;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSS.HanbaiKanri.DataAccess.BusinessLogic.MasterTable
{
    public class MasterTableContext : BaseDbContext
    {
        public virtual DbSet<MT_Shubetsu> MT_Shubetsu { get; set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MasterTableContext() : base()
        {
        }

        /// <summary>
        /// Fluent API 方式によるO/Rマッピング情報設定用メソッド
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MT_Shubetsu>().HasKey(key => key.Code);
        }
    }
}
