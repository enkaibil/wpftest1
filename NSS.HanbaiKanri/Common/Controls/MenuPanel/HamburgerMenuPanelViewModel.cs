using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

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

        public DelegateCommand CMD_Form_Loaded { get; }
        public DelegateCommand CMD_btnMenu_Click { get; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public HamburgerMenuPanelViewModel()
        {
            // イベント定義
            CMD_Form_Loaded = new DelegateCommand(From_Loaded);
            CMD_btnMenu_Click = new DelegateCommand(btnMenu_Click);

            _isChecked = false;
        }

        /// <summary>
        /// 画面初期表示イベント
        /// </summary>
        public void From_Loaded()
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

        private T FindVisualChild<T>(DependencyObject obj)
        where T : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(obj, i);
                if (child != null && child is T)
                {
                    return (T)child;
                }
                else
                {
                    T childOfChild = FindVisualChild<T>(child);
                    if (childOfChild != null) return childOfChild;
                }
            }

            return null;
        }
    }
}
