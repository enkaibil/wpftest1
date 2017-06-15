using NSS.HanbaiKanri.Common;
using NSS.HanbaiKanri.Common.Models;
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
        /// <summary>ウィンドウタイトル</summary>
        public override string Title { get { return "スタートメニュー"; } }

        public DelegateCommand CMD_Form_Loaded { get; }
        public DelegateCommand CMD_btnMMEmp_Click { get; }

        public StartMenuViewModel() : base()
        {
            CMD_Form_Loaded = new DelegateCommand(From_Loaded);
            CMD_btnMMEmp_Click = new DelegateCommand(btnMMEmp_Click);
        }

        /// <summary>
        /// 画面初期表示イベント
        /// </summary>
        public void From_Loaded()
        {
            int a = 1;
            //PageInfoPubSubEvent.Publish(this.EventAggregator, this);
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
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            base.OnNavigatedTo(navigationContext);
        }
    }
}
