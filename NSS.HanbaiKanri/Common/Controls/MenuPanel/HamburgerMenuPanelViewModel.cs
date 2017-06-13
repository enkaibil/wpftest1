using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public DelegateCommand CMD_btnMenu_Click { get; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public HamburgerMenuPanelViewModel()
        {
            CMD_btnMenu_Click = new DelegateCommand(btnMenu_Click);

            _isChecked = false;
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
