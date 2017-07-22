using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSS.HanbaiKanri.DataAccess.DataEntity.Models
{
    /// <summary>
    /// サンプル社員マスタモデルクラス
    /// </summary>
    public class Sample_M_Employee
    {
        /// <summary>社員番号</summary>
        [Key][Column(Order = 0)]
        public string ShainCode { get; set; }

        /// <summary>社員名：姓</summary>
        public string ShainName_Sei { get; set; }
        /// <summary>社員名：名</summary>
        public string ShainName_Mei { get; set; }

        /// <summary>社員名（カナ）：姓</summary>
        public string ShainName_Kana_Sei { get; set; }
        /// <summary>社員名（カナ）：名</summary>
        public string ShainName_Kana_Mei { get; set; }

        /// <summary>役職コード</summary>
        public string YakushokuCode { get; set; }
        /// <summary>年齢</summary>
        public int Age { get; set; }
        /// <summary>入社年月日</summary>
        public DateTime NyushaDate { get; set; }
        /// <summary>月給</summary>
        public decimal Salary { get; set; }
        /// <summary>退職フラグ</summary>
        public bool TaishokuFlg { get; set; }
        /// <summary>記事</summary>
        public string Kiji { get; set; }

        /// <summary>オプティミスト</summary>
        [Timestamp]
        public byte[] Optimist { get; set; }
        /// <summary>入力者</summary>
        public string InputUser { get; set; }
        /// <summary>入力日時</summary>
        public DateTime InputDate { get; set; }
        /// <summary>更新者</summary>
        public string UpdateUser { get; set; }
        /// <summary>更新日時</summary>
        public DateTime UpdateDate { get; set; }
}
}
