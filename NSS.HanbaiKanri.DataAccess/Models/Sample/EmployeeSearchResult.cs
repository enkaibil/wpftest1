using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSS.HanbaiKanri.DataAccess.Models.Sample
{
    /// <summary>
    /// 社員一覧検索情報
    /// </summary>
    public class EmployeeSearchResult
    {
        /// <summary>社員番号</summary>
        public string ShainCode { get; set; }
        /// <summary>社員氏名</summary>
        public string ShainName { get; set; }
        /// <summary>役職</summary>
        public string Yakushoku { get; set; }
        /// <summary>年齢</summary>
        public int Age { get; set; }
    }
}
