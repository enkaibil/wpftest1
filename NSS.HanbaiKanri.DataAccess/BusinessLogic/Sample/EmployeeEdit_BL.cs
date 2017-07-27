using NSS.HanbaiKanri.DataAccess.DataEntity;
using NSS.HanbaiKanri.DataAccess.DataEntity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NSS.HanbaiKanri.DataAccess.BusinessLogic.Common.BLConst;

namespace NSS.HanbaiKanri.DataAccess.BusinessLogic.Sample
{
    /// <summary>
    /// 社員マスタ（編集）画面用BLクラス
    /// </summary>
    public class EmployeeEdit_BL
    {
        /// <summary>
        /// 初期表示処理
        /// </summary>
        /// <param name="param">社員番号</param>
        /// <returns>取得結果</returns>
        public EmployeeEditInitParam Init(string shainCode)
        {
            EmployeeEditInitParam result = new EmployeeEditInitParam();
            Sample_M_Shubetsu_DE yakushokuDe = new Sample_M_Shubetsu_DE();
            Sample_M_Employee_DE empDe = new Sample_M_Employee_DE();

            using (NssDbContext db = new NssDbContext())
            {
                // 役職一覧の取得
                result.YakushokuList = yakushokuDe.SelectOneKbn(db, ShubetsuKbn.Yakushoku);

                // 社員情報の取得
                if (!string.IsNullOrEmpty(shainCode))
                {
                    List<Sample_M_Employee> selectResult = empDe.SelectByShainCode(db, shainCode);
                    if (selectResult.Count > 0)
                    {
                        result.Employee = selectResult[0];
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// 保存処理
        /// </summary>
        /// <param name="param">パラメータ</param>
        /// <returns>処理結果</returns>
        public EmployeeEditSaveParam Save(EmployeeEditSaveParam param)
        {
            Sample_M_Employee_DE de = new Sample_M_Employee_DE();

            using (NssDbContext db = new NssDbContext())
            {
                try
                {
                    // トランザクション開始
                    db.Database.BeginTransaction();

                    // 登録処理
                    if(param.InsertList != null && param.InsertList.Count > 0)
                    {
                        de.Insert(db, param.InsertList);
                    }

                    // 更新処理
                    if(param.UpdateList != null && param.UpdateList.Count > 0)
                    {
                        de.Update(db, param.UpdateList);
                    }

                    // 削除処理
                    if (param.DeleteList != null && param.DeleteList.Count > 0)
                    {
                        de.Delete(db, param.DeleteList);
                    }

                    // コミット処理
                    db.Database.CommitTransaction();
                }
                catch(Exception ex)
                {
                    // ロールバック処理
                    db.Database.RollbackTransaction();

                    // ビジネスエラー判定
                    param.CheckBusinessError(ex);
                }
            }

            return param;
        }
    }
}
