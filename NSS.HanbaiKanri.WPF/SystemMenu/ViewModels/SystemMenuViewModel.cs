using NSS.HanbaiKanri.WPF.Common;
using NSS.HanbaiKanri.WPF.Common.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using NSS.HanbaiKanri.WPF.Sample.Views;

namespace NSS.HanbaiKanri.WPF.StartMenu.ViewModels
{
    public class SystemMenuViewModel : BaseViewModel
    {
        /// <summary>ウィンドウタイトル</summary>
        public override string Title { get { return "システムメニュー"; } }

        public DelegateCommand CMD_btnBack_Click { get; }
        public DelegateCommand CMD_btnMMEmp_Click { get; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public SystemMenuViewModel() : base()
        {
            CMD_btnMMEmp_Click = new DelegateCommand(btnMMEmp_Click);
            CMD_btnBack_Click = new DelegateCommand(OnBackButtonClick);
        }

        /// <summary>
        /// 戻るボタンイベントのオーバーライド
        /// </summary>
        protected override void OnBackButtonClick()
        {
            // アプリを終了する。
            Application.Current.Shutdown();
        }

        /// <summary>
        /// 社員マスタボタン押下イベント
        /// </summary>
        private void btnMMEmp_Click()
        {
            this.RequestNavigate<EmployeeListView>();
        }

    }
}
