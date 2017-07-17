using NSS.HanbaiKanri.DataAccess.DataEntity.Models.Sample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSS.HanbaiKanri.DataAccess.BusinessLogic.Sample
{
    /// <summary>
    /// サンプル検索パラメータクラス
    /// </summary>
    public class SampleSearchParam
    {
        /// <summary>検索役職コード</summary>
        public string YakushokuCode { get; set; } = string.Empty;
        /// <summary>検索キーワード</summary>
        public string KeyWord { get; set; } = string.Empty;

        /// <summary>検索結果</summary>
        public List<EmployeeList_SearchResult> ResultData { get; set; } = new List<EmployeeList_SearchResult>();

    }
}
