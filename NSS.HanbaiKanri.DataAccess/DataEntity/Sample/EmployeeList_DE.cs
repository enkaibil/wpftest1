using NSS.HanbaiKanri.DataAccess.DataEntity.Models.Sample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSS.HanbaiKanri.DataAccess.DataEntity.Sample
{
    /// <summary>
    /// 社員マスタ（一覧）画面用DEクラス
    /// </summary>
    public class EmployeeList_DE
    {
        /// <summary>
        /// 社員一覧検索処理
        /// </summary>
        /// <param name="db">DBコンテキスト</param>
        /// <param name="yakushokuCode">役職コード</param>
        /// <param name="keyword">キーワード</param>
        public List<EmployeeList_SearchResult> SelectEmployeeList(NssDbContext db, string yakushokuCode, string keyword)
        {
            var query1 = from row in db.Sample_M_Employee select row;

            // まず役職コードがあれば事前に絞り込む
            if (!string.IsNullOrEmpty(yakushokuCode))
            {
                query1 = from row in query1 where row.YakushokuCode == yakushokuCode select row;
            }

            // コードマスタとJOINし、必要な項目のみ抽出
            var query2 = from row in query1
#warning 外部結合にする。
                         join ysm in db.Sample_M_Shubetsu on row.YakushokuCode equals ysm.Code
                         where ysm.KBN == 1
                         select new EmployeeList_SearchResult
                         {
                             ShainCode = row.ShainCode,
                             ShainName = row.ShainName_Sei + " " + row.ShainName_Mei,
                             Yakushoku = ysm.Name,
                             Age = row.Age,
                             NyushaDate = row.NyushaDate,
                             TaishokuFlg = row.TaishokuFlg
                         };

            // キーワード検索処理
            if (!string.IsNullOrEmpty(keyword))
            {
                // 社員氏名と役職を検索
                query2 = from row in query2
                         where row.ShainName.Contains(keyword)
                            || row.Yakushoku.Contains(keyword)
                         select row;
            }

            return query2.ToList();
        }
    }
}
