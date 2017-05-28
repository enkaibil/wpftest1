using NSS.HanbaiKanri.Common;
using NSS.HanbaiKanri.MasterMeinte.Employee;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSS.HanbaiKanri.StartMenu
{
    public class StartMenuViewModel : BaseViewModel
    {

        public DelegateCommand btnMMEmpClick_Cmd { get; set; }

        public StartMenuViewModel()
        {
            btnMMEmpClick_Cmd = new DelegateCommand(btnMMEmpClick);
        }

        private void btnMMEmpClick()
        {
            this.RegionManager.RequestNavigate("main", nameof(EmployeeView));
        }
    }
}
