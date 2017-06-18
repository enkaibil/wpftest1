using NSS.HanbaiKanri.Common.Controls.MenuItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xaml;
using System.Globalization;

namespace NSS.HanbaiKanri.Common.Controls.MenuPanel
{
    /// <summary>
    /// MenuPanel.xaml の相互作用ロジック
    /// </summary>
    public partial class HamburgerMenuPanel : ListBox
    {
        #region 依存関係プロパティ定義

        /// <summary>
        /// メニュー展開時横幅
        /// </summary>
        public static readonly DependencyProperty OpenWidthProperty = DependencyProperty.Register(
            "OpenWidth",
            typeof(double),
            typeof(HamburgerMenuPanel),
            new FrameworkPropertyMetadata());

        /// <summary>
        /// メニュー展開フラグ
        /// </summary>
        public static readonly DependencyProperty IsMenuOpenProperty = DependencyProperty.Register(
            "IsMenuOpen",
            typeof(bool),
            typeof(HamburgerMenuPanel),
            new FrameworkPropertyMetadata());
        #endregion

        #region CLRラッパープロパティ
        /// <summary>
        /// メニュー展開時横幅
        /// </summary>
        public double OpenWidth
        {
            get { return (double)GetValue(OpenWidthProperty); }
            set { SetValue(OpenWidthProperty, value); }
        }

        /// <summary>
        /// メニュー展開フラグ
        /// </summary>
        public bool IsMenuOpen
        {
            get { return (bool)GetValue(IsMenuOpenProperty); }
            set { SetValue(IsMenuOpenProperty, value); }
        }

        #endregion

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public HamburgerMenuPanel()
        {
            InitializeComponent();
        }
        #endregion

        /// <summary>
        /// フォームロードイベント
        /// </summary>
        /// <param name="sender">イベント発生元オブジェクト</param>
        /// <param name="e">イベント引数</param>
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            Popup popup = FindVisualChild<Popup>(this);
            StackPanel popupPanel = (StackPanel)popup.Child;
            foreach(UIElement item in this.Items)
            {
                if (item is HamburgerMenuItem)
                {
                    HamburgerMenuItem copyItem = (HamburgerMenuItem)item;
                    HamburgerMenuItem newItem = new HamburgerMenuItem();
                    newItem.Alias = copyItem.Alias;
                    newItem.Caption = copyItem.Caption;
                    newItem.Command = copyItem.Command;
                    newItem.IsOpen = true;

                    popupPanel.Children.Add(newItem);
                }
                else
                {
                    StackPanel spacer = new StackPanel();
                    spacer.Height = ((Control)item).Height;

                    popupPanel.Children.Add(spacer);
                }
            }
        }

        /// <summary>
        /// ビジュアルツリー内のノードから指定の要素を取得します。
        /// </summary>
        /// <typeparam name="T">取得対象要素の型</typeparam>
        /// <param name="obj">検索対象</param>
        /// <returns>取得結果</returns>
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
