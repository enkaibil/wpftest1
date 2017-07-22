using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSS.HanbaiKanri.DataAccess.DataEntity.Models
{
    /// <summary>
    /// 設定テーブルモデルクラス
    /// </summary>
    public class Settings
    {
        /// <summary>ID</summary>
        [Key]
        public int ID { get; set; }
        /// <summary>暗号化</summary>
        public int Encrypt { get; set; }
        /// <summary>設定値</summary>
        public string Value { get; set; }
        /// <summary>記事</summary>
        public string kiji { get; set; }
    }
}
