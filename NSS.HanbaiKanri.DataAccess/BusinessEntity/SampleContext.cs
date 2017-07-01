using Microsoft.EntityFrameworkCore;
using NSS.HanbaiKanri.DataAccess.BusinessLogic.Common;
using NSS.HanbaiKanri.DataAccess.BusinessEntity.Models.SampleTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.Configuration;

namespace NSS.HanbaiKanri.DataAccess.BusinessLogic.Sample
{
    public class SampleContext : DbContext
    {
        #region DbSet定義

        /// <summary>社員マスタ</summary>
        public DbSet<Sample_M_Employee> Sample_M_Employee { get; set; }

        /// <summary>種別マスタ</summary>
        public DbSet<Sample_M_Shubetsu> Sample_M_Shubetsu { get; set; }

        #endregion

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public SampleContext() : base()
        {
        }
        #endregion

        /// <summary>
        /// コンテキストの設定
        /// </summary>
        /// <param name="options">オプション</param>
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // 接続文字列の設定
            string conn = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
            options.UseSqlServer(conn);

            // デバッグログの出力設定
            ILoggerFactory logFactory = new LoggerFactory();
            logFactory.AddDebug();
            options.UseLoggerFactory(logFactory);
        }

        /// <summary>
        /// Fluent API 方式によるO/Rマッピング情報設定用メソッド
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 主キー(複合キー)の設定
            modelBuilder.Entity<Sample_M_Shubetsu>().HasKey(key => new { key.KBN, key.Code });
        }
    }
}
