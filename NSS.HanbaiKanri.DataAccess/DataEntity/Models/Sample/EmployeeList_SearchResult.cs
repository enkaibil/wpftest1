using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSS.HanbaiKanri.DataAccess.DataEntity.Models.Sample
{
    public class EmployeeList_SearchResult
    {
        /// <summary>社員番号</summary>
        public string ShainCode { get; set; }
        /// <summary>社員氏名</summary>
        public string ShainName { get; set; }
        /// <summary>役職</summary>
        public string Yakushoku { get; set; }
        /// <summary>年齢</summary>
        public int Age { get; set; }
        /// <summary>入社年月日</summary>
        public DateTime NyushaDate { get; set; }
        /// <summary>退職フラグ</summary>
        public bool TaishokuFlg { get; set; }
    }
}
