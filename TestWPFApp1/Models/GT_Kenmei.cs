using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestWPFApp1.Models
{
    public class GT_Kenmei
    {
        public string KojiNo { get; set; }
        public string KojiKenmei { get; set; }
        public string ShubetsuCode { get; set; }
        public Nullable<System.DateTime> KeiyakuDate { get; set; }
        public Nullable<System.DateTime> KanseiDate { get; set; }
        public Nullable<decimal> KeiyakuKingaku { get; set; }
    }
}
