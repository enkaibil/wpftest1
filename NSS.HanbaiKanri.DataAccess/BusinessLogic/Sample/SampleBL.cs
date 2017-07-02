using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;
using NSS.HanbaiKanri.DataAccess.BusinessEntity.Models.SampleTables;

namespace NSS.HanbaiKanri.DataAccess.BusinessLogic.Sample
{
    /// <summary>
    /// サンプルBLクラス
    /// </summary>
    public class SampleBL
    {
        #region コンストラクタ
        /// <summary>
        /// SampleBLクラスのインスタンスを生成します。
        /// </summary>
        public SampleBL()
        {
        }
        #endregion

        /// <summary>
        /// 社員マスタ（一覧）初期表示処理
        /// </summary>
        /// <returns></returns>
        public List<Sample_M_Shubetsu> Init()
        {
            List<Sample_M_Shubetsu> resut;

            using (SampleContext context = new SampleContext())
            {
                resut = (from row in context.Sample_M_Shubetsu
                         where row.KBN == 1
                         orderby row.Sort
                         select row).ToList();
            }

            return resut;
        }

        /// <summary>
        /// 社員マスタ（一覧）検索処理
        /// </summary>
        /// <param name="param">検索パラメータ</param>
        /// <returns>取得結果</returns>
        public SampleSearchParam Search(SampleSearchParam param)
        {
            using (SampleContext context = new SampleContext())
            {
                try
                {
                    //context.Database.BeginTransaction();

                    var query1 = from row in context.Sample_M_Employee select row;

                    if (!string.IsNullOrEmpty(param.YakushokuCode))
                    {
                        query1 = from row in query1 where row.YakushokuCode == param.YakushokuCode select row;
                    }

                    var result = from row in query1
                                 join ysm in context.Sample_M_Shubetsu
                                 on row.YakushokuCode equals ysm.Code
                                 where ysm.KBN == 1
                                 select new SearchResult
                                 {
                                     ShainCode = row.ShainCode,
                                     ShainName = row.ShainName_Sei + " " + row.ShainName_Mei,
                                     Yakushoku = ysm.Name,
                                     Age = row.Age
                                 };

                    if (!string.IsNullOrEmpty(param.KeyWord))
                    {
                        result = from row in result
                                 where row.ShainName.Contains(param.KeyWord)
                                    || row.Yakushoku.Contains(param.KeyWord)
                                 select row;
                    }

                    param.ResultData = result.ToList();

                    //context.Database.CommitTransaction();
                }
                catch (Exception)
                {
                    //context.Database.RollbackTransaction();
                }
            }

            return param;
        }
    }
}
