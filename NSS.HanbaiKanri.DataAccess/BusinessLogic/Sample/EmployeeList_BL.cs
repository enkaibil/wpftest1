using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSS.HanbaiKanri.DataAccess.DataEntity;
using NSS.HanbaiKanri.DataAccess.DataEntity.Models;
using NSS.HanbaiKanri.DataAccess.DataEntity.Sample;

namespace NSS.HanbaiKanri.DataAccess.BusinessLogic.Sample
{
    /// <summary>
    /// 社員マスタ（一覧）画面用BLクラス
    /// </summary>
    public class EmployeeList_BL
    {
        #region コンストラクタ
        /// <summary>
        /// SampleBLクラスのインスタンスを生成します。
        /// </summary>
        public EmployeeList_BL()
        {
        }
        #endregion

        /// <summary>
        /// 初期表示処理
        /// </summary>
        /// <returns></returns>
        public List<Sample_M_Shubetsu> Init()
        {
            List<Sample_M_Shubetsu> resut;
            Sample_M_Shubetsu_DE de = new Sample_M_Shubetsu_DE();
            
            using (NssDbContext db = new NssDbContext())
            {
                // 役職一覧の取得
                resut = de.SelectOneKbn(db, ShubetsuKbn.Yakushoku);
            }

            return resut;
        }

        /// <summary>
        /// 検索処理
        /// </summary>
        /// <param name="param">検索パラメータ</param>
        /// <returns>取得結果</returns>
        public SampleSearchParam Search(SampleSearchParam param)
        {
            EmployeeList_DE be = new EmployeeList_DE();

            using (NssDbContext db = new NssDbContext())
            {
                try
                {
                    //db.Database.BeginTransaction();
                    
                    param.ResultData = be.SelectEmployeeList(db, param.YakushokuCode, param.KeyWord);

                    //db.Database.CommitTransaction();
                }
                catch (Exception ex)
                {
                    //db.Database.RollbackTransaction();
                    throw;
                }
            }

            return param;
        }
    }
}
