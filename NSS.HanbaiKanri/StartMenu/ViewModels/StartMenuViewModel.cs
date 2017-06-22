using NSS.HanbaiKanri.Common;
using NSS.HanbaiKanri.Common.Models;
using NSS.HanbaiKanri.MasterMeinte.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSS.HanbaiKanri.StartMenu.ViewModels
{
    public class StartMenuViewModel : BaseViewModel
    {
        /// <summary>ウィンドウタイトル</summary>
        public override string Title { get { return "スタートメニュー"; } }
        
        public DelegateCommand CMD_btnMMEmp_Click { get; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public StartMenuViewModel() : base()
        {
            CMD_btnMMEmp_Click = new DelegateCommand(btnMMEmp_Click);
        }

        /// <summary>
        /// 社員マスタボタン押下イベント
        /// </summary>
        private void btnMMEmp_Click()
        {
            this.RequestNavigate<EmployeeView>();
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
