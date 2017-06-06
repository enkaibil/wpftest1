using NSS.HanbaiKanri.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Regions;
using NSS.HanbaiKanri.StartMenu;
using NSS.HanbaiKanri.Common.Models;

namespace NSS.HanbaiKanri.MasterMeinte.Employee
{
    public class EmployeeViewModel : BaseViewModel
    {
        /// <summary>ウィンドウタイトル</summary>
        public override string Title { get { return "社員マスタ"; } }

        public override void OnNavigatedFrom(NavigationContext navigationContext)
        {
            base.OnNavigatedFrom(navigationContext);

        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            base.OnNavigatedTo(navigationContext);

        }

        protected override void OnBackButtonClick()
        {
            this.RegionManager.RequestNavigate("main", nameof(StartMenuView));
        }
    }
}
