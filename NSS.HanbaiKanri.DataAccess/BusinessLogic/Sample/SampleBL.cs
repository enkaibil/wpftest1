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

        public SampleSearchParam Search(SampleSearchParam param)
        {
            using (SampleContext context = new SampleContext())
            {
                try
                {
                    //context.Database.BeginTransaction();

                    var result = from row in context.Sample_M_Employee
                                 join ysm in context.Sample_M_Shubetsu
                                 on row.YakushokuCode equals ysm.Code
                                 where row.YakushokuCode == "01" && ysm.KBN == 1
                                 orderby row.ShainCode
                                 select new SearchResult
                                 {
                                     ShainCode = row.ShainCode,
                                     ShainName = row.ShainName_Mei + "" + row.ShainName_Sei,
                                     Yakushoku = ysm.Name,
                                     Age = row.Age
                                 };

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
