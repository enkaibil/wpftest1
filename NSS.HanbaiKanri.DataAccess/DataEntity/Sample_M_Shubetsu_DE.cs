using NSS.HanbaiKanri.DataAccess.DataEntity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSS.HanbaiKanri.DataAccess.DataEntity
{
    /// <summary>
    /// Sample_M_Shubetsuテーブル用データエンティティクラス
    /// </summary>
    public class Sample_M_Shubetsu_DE
    {
        /// <summary>
        /// 選択処理
        /// </summary>
        /// <param name="db">DBコンテキスト</param>
        /// <param name="kbn">区分</param>
        /// <returns></returns>
        public List<Sample_M_Shubetsu> SelectOneKbn(NssDbContext db, int kbn)
        {
            List<Sample_M_Shubetsu> result;

            var query = from row in db.Sample_M_Shubetsu
                        where row.KBN == kbn
                        orderby row.Sort
                        select row;

            result = query.ToList();

            return result;
        }
    }
}
