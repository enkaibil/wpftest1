using NSS.HanbaiKanri.DataAccess.DataEntity;
using NSS.HanbaiKanri.DataAccess.DataEntity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSS.HanbaiKanri.DataAccess.BusinessLogic.Sample
{
    /// <summary>
    /// 社員マスタ（編集）画面用BLクラス
    /// </summary>
    public class EmployeeEdit_BL
    {/// <summary>
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

                //社員情報の取得
                if (!string.IsNullOrEmpty(shainCode))
                {
                    List<Sample_M_Employee> selectResult = empDe.SelectByShainCode(db, shainCode);
                    if(selectResult.Count > 0)
                    {
                        result.Employee = selectResult[0];
                    }
                }
            }

            return result;
        }
    }
}
