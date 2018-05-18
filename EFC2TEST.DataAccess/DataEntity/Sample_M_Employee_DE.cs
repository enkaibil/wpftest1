using Microsoft.EntityFrameworkCore;
using EFC2TEST.DataAccess.DataEntity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFC2TEST.DataAccess.DataEntity
{
    /// <summary>
    /// Sample_M_Employeeテーブル用データエンティティクラス
    /// </summary>
    internal class Sample_M_Employee_DE
    {
        /// <summary>
        /// 検索処理
        /// </summary>
        /// <param name="db">DBコンテキスト</param>
        /// <returns>取得結果</returns>
        public List<Sample_M_Employee> SelectAll(NssDbContext db)
        {
            List<Sample_M_Employee> result;

            var query = from row in db.Sample_M_Employee
                        orderby row.ShainCode
                        select row;

            result = query.ToList();

            return result;
        }

        /// <summary>
        /// 検索処理
        /// </summary>
        /// <param name="db">DBコンテキスト</param>
        /// <param name="shainCode">社員番号</param>
        /// <returns>取得結果</returns>
        public List<Sample_M_Employee> SelectByShainCode(NssDbContext db, string shainCode)
        {
            List<Sample_M_Employee> result;

            var query = from row in db.Sample_M_Employee
                        where row.ShainCode == shainCode
                        select row;

            result = query.ToList();

            return result;
        }
        
        /// <summary>
        /// 登録処理
        /// </summary>
        /// <param name="db">DBコンテキスト</param>
        /// <param name="insertTarget">登録対象データ</param>
        /// <returns>処理件数</returns>
        public int Insert(NssDbContext db, List<Sample_M_Employee> insertTarget)
        {
            db.Sample_M_Employee.AddRange(insertTarget);

            return db.SaveChanges();
        }
        
        /// <summary>
        /// 更新処理
        /// </summary>
        /// <param name="db">DBコンテキスト</param>
        /// <param name="insertTarget">登録対象データ</param>
        /// <returns>処理件数</returns>
        public int Update(NssDbContext db, List<Sample_M_Employee> updateTarget)
        {
            db.UpdateRange(updateTarget);
            db.Sample_M_Employee.UpdateRange(updateTarget);

            return db.SaveChanges();
        }
        
        /// <summary>
        /// 登録処理
        /// </summary>
        /// <param name="db">DBコンテキスト</param>
        /// <param name="sourceData">削除対象データ</param>
        /// <returns>処理件数</returns>
        public int Delete(NssDbContext db, List<Sample_M_Employee> deleteTarget)
        {
            db.Sample_M_Employee.RemoveRange(deleteTarget);

            return db.SaveChanges();
        }
    }
}
