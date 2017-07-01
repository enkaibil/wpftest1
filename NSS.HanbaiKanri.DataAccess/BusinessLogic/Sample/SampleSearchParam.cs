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
        /// <summary>検索キーワード</summary>
        public string KeyWord { get; set; } = string.Empty;

        /// <summary>検索結果</summary>
        public List<SearchResult> ResultData { get; set; } = new List<SearchResult>();

    }

    public class SearchResult
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
