using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NSS.HanbaiKanri.DataAccess.Models.MasterTables
{    
    public class MT_Shubetsu
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Kiji { get; set; }
    }
}
