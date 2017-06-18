using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using System.Globalization;

namespace NSS.HanbaiKanri.Common.Controls.MenuPanel
{
    public class HamburgerMenuPanelViewModel : BindableBase
    {

        /// <summary>チェック状態</summary>
        public bool IsChecked
        {
            get { return _isChecked; }
            set { SetProperty(ref _isChecked, value); }
        }
        private bool _isChecked;

        public DelegateCommand<HamburgerMenuPanel> CMD_Form_Loaded { get; }
        public DelegateCommand CMD_btnMenu_Click { get; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public HamburgerMenuPanelViewModel()
        {
            // イベント定義
            CMD_Form_Loaded = new DelegateCommand<HamburgerMenuPanel>(param => From_Loaded(param));
            CMD_btnMenu_Click = new DelegateCommand(btnMenu_Click);

            _isChecked = false;
        }

        /// <summary>
        /// 画面初期表示イベント
        /// </summary>
        public void From_Loaded(HamburgerMenuPanel param)
        {
            int i = 1;
        }

        /// <summary>
        /// メニューボタンクリックイベント
        /// </summary>
        public void btnMenu_Click()
        {
            //チェック状態の反転
            IsChecked = !IsChecked;
        }
    }
}
