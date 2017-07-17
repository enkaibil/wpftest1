using NSS.HanbaiKanri.DataAccess.DataEntity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSS.HanbaiKanri.DataAccess.DataEntity.Common
{
    /// <summary>
    /// Sample_M_Employeeテーブル用データエンティティクラス
    /// </summary>
    public class Sample_M_Employee_DE
    {
        /// <summary>
        /// 検索処理
        /// </summary>
        /// <param name="db">DBコンテキスト</param>
        /// <returns></returns>
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
        /// <returns></returns>
        public List<Sample_M_Employee> SelectByShainCode(NssDbContext db, string shainCode)
        {
            List<Sample_M_Employee> result;

            var query = from row in db.Sample_M_Employee
                        where row.ShainCode == shainCode
                        select row;

            result = query.ToList();

            return result;
        }
    }
}
