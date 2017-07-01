using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NSS.HanbaiKanri.DataAccess.BusinessEntity.Models.SampleTables
{
    public class Sample_M_Shubetsu
    {
        /// <summary>区分</summary>
        //[Key][Column(Order =0)]
        public int KBN { get; set; }
        /// <summary>コード</summary>
        //[Key][Column(Order = 1)]
        public string Code { get; set; }
        /// <summary>名称</summary>
        public string Name { get; set; }
        /// <summary>並び順</summary>
        public int Sort { get; set; }
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
