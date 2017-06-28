using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSS.HanbaiKanri.DataAccess.BusinessLogic.Common
{
    public class BaseDbContext : DbContext
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public BaseDbContext() : base()
        {
        }

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
    }
}
