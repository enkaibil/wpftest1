using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestWPFApp1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class GT_Meisai
    {
        public string KojiNo { get; set; }
        public int No { get; set; }
        public string Hinban { get; set; }
        public string Hinmei { get; set; }
        public string Hinkei { get; set; }
        public Nullable<decimal> Tanka { get; set; }
        public Nullable<int> Suryo { get; set; }
        public Nullable<decimal> Kingaku { get; set; }
    }
}
