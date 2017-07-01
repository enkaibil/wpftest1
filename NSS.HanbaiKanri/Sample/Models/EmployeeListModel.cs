using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSS.HanbaiKanri.DataAccess.BusinessLogic.Sample;
using NSS.HanbaiKanri.DataAccess.BusinessEntity.Models.SampleTables;
using Prism.Mvvm;
using System.Collections.ObjectModel;

namespace NSS.HanbaiKanri.Sample.Models
{
    public class EmployeeListModel : BindableBase
    {
        private List<Sample_M_Shubetsu> _yakushokuList = new List<Sample_M_Shubetsu>();
        public List<Sample_M_Shubetsu> YakushokuList
        {
            get { return _yakushokuList; }
            set { SetProperty(ref _yakushokuList, value); }
        }

        public void InitAction()
        {
            SampleBL bl = new SampleBL();
            List<Sample_M_Shubetsu> result = bl.Init();

            YakushokuList.AddRange(result);
        }

        public void SearchAction()
        {
            SampleBL bl = new SampleBL();
        }
    }
}
