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
        public DelegateCommand CMD_btnMMEmp_Click { get; }

        public StartMenuViewModel()
        {
            CMD_btnMMEmp_Click = new DelegateCommand(btnMMEmp_Click);
        }

        private void btnMMEmp_Click()
        {
            this.RegionManager.RequestNavigate("main", nameof(EmployeeView));
        }

        private void btnBack_Click()
        {
            int i = 1;
        }

        public override void OnNavigatedFrom(NavigationContext navigationContext)
        {
            base.OnNavigatedFrom(navigationContext);

            int i = 1;
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {

            int i = 1;
        }
    }
}
