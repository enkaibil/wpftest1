using EFC2TEST.DataAccess.DataEntity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFC2TEST.BusinessLogic.Sample
{
    /// <summary>
    /// 社員マスタ（編集）画面初期化処理用パラメータクラス
    /// </summary>
    public class EmployeeEditInitParam
    {
        #region Input

        /// <summary>社員番号</summary>
        public string ShainCode { get; set; }

        #endregion

        #region Output

        /// <summary>役職一覧</summary>
        public List<Sample_M_Shubetsu> YakushokuList { get; set; }

        /// <summary>社員情報</summary>
        public Sample_M_Employee Employee { get; set; }

        #endregion
    }
}
