using NSS.HanbaiKanri.DataAccess.BusinessLogic.MasterTable;
using NSS.HanbaiKanri.DataAccess.Models.MasterTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSS.HanbaiKanri.DataAccess.BusinessLogic.StartMenu
{
    public class StartMenuBL
    {
        public List<M_Shubetsu> Initialize()
        {
            List<M_Shubetsu> result;

            MasterTableContext context = new MasterTableContext();

                // select
                result = context.M_ShubetsuSet.ToList();

            return result;
        }
    }
}
