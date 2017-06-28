using NSS.HanbaiKanri.DataAccess.Models.MasterTables;
//using Microsoft.Extensions.Logging;
//using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSS.HanbaiKanri.DataAccess.BusinessLogic.StartMenu
{
    public class StartMenuBL
    {
        public List<MT_Shubetsu> Initialize()
        {
            NSSDBContext context = new NSSDBContext();


            List<MT_Shubetsu> result = context.MT_Shubetsu.ToList();

            return result;
        }
    }
}
