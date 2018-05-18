using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Extensions;
using Microsoft.EntityFrameworkCore.Storage;
using EFC2TEST.DataAccess.DataEntity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.Configuration;
using System.Data.Common;
using EFC2TEST.DataAccess.DataEntity.Common;

namespace EFC2TEST.DataAccess.DataEntity
{
    /// <summary>
    /// ＤＢコンテキストクラス
    /// </summary>
    internal class NssDbContext : DbContext
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
        public NssDbContext() : base()
        {
        }
        #endregion


        //===========================================================================================
        /// <summary>
        /// コンテキストの設定
        /// </summary>
        /// <param name="optionsBuilder">オプション</param>
        //===========================================================================================
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // 接続文字列の設定
            //string conn = DBSettings.Values[DBSettings.SettingID.ConnectionString];
            string conn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\EFC2TEST\EFC2TEST.DataAccess\DataEntity\SampleDB.mdf;Integrated Security=True;Connect Timeout=30";
            optionsBuilder.UseSqlServer(conn);

            // ログの設定
            optionsBuilder.EnableSensitiveDataLogging();
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //{
        //    if (!options.IsConfigured)
        //    {
        //        if(DbLoggerFactory == null)
        //        {
        //            DbLoggerFactory = new LoggerFactory(new)
        //        }

        //        options
        //    }
        //    // 接続文字列の設定
        //    string conn = DBSettings.Values[DBSettings.SettingID.ConnectionString];
        //    options.UseSqlServer(conn);

        //    // デバッグログの出力設定
        //    ILoggerFactory logFactory = new LoggerFactory();
        //    logFactory.AddDebug();
        //    options.UseLoggerFactory(logFactory);
        //}

        //===========================================================================================
        /// <summary>
        /// Fluent API 方式によるO/Rマッピング情報設定用メソッド
        /// </summary>
        /// <param name="modelBuilder">モデルビルダー</param>
        //===========================================================================================
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 主キー(複合キー)の設定
            modelBuilder.Entity<Sample_M_Shubetsu>().HasKey(key => new { key.KBN, key.Code });
        }

        //===========================================================================================
        /// <summary>
        /// コンテキストに対する全ての変更をＤＢに保存します。
        /// </summary>
        /// <returns>処理件数</returns>
        //===========================================================================================
        public override int SaveChanges()
        {
            // 現在日付の取得
            DateTime now = SQLQuery<DateTime>("SELECT GETDATE()").First();
            
            var entities = from e in this.ChangeTracker.Entries()
                           where e.State == EntityState.Added || e.State == EntityState.Modified
                           select e;
            foreach (var entity in entities)
            {
                // 登録日の更新
                if (entity.State == EntityState.Added)
                {
                    
                    entity.Property("InputDate").CurrentValue = now;
                    entity.Property("InputUser").CurrentValue = Environment.UserName;
                }

                // 更新日の設定
                if(entity.State == EntityState.Added || entity.State == EntityState.Modified)
                {
                    entity.Property("UpdateDate").CurrentValue = now;
                    entity.Property("UpdateUser").CurrentValue = Environment.UserName;
                }
            }

            return base.SaveChanges();
        }

        //===========================================================================================
        /// <summary>
        /// クエリ(SELECT)の直接実行
        /// </summary>
        /// <typeparam name="T">マッピング型</typeparam>
        /// <param name="selectSql">クエリ本文</param>
        /// <returns>取得結果</returns>
        //===========================================================================================
        public List<T> SQLQuery<T>(string selectSql)
        {
            DbConnection conn = this.Database.GetDbConnection();
            DbTransaction tran = (this.Database.CurrentTransaction == null) ?
                null : this.Database.CurrentTransaction.GetDbTransaction();

            return conn.Query<T>(selectSql, transaction: tran).ToList();
        }
    }
}
