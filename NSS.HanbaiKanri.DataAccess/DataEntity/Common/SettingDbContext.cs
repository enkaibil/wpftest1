using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Xml;
using NSS.HanbaiKanri.DataAccess.DataEntity.Models;

namespace NSS.HanbaiKanri.DataAccess.DataEntity.Common
{
    /// <summary>
    /// ＤＢコンテキストクラス
    /// </summary>
    public class SettingDbContext : DbContext
    {
        #region DbSet定義

        /// <summary>社員マスタ</summary>
        public DbSet<Settings> Settings { get; set; }

        #endregion

        //===========================================================================================
        /// <summary>
        /// コンテキストの設定
        /// </summary>
        /// <param name="optionsBuilder">オプション</param>
        //===========================================================================================
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Environment.CurrentDirectory)
                .AddXmlFile("DbSettings.xml");
            IConfiguration conf = builder.Build();

            // 接続文字列の設定
            string conn = conf["connectionString"];
            optionsBuilder.UseSqlServer(conn);

            // ログの設定
            optionsBuilder.EnableSensitiveDataLogging();
        }
    }
}
