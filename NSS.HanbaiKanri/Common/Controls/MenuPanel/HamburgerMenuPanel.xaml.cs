using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NSS.HanbaiKanri.Common.Controls.MenuPanel
{
    /// <summary>
    /// MenuPanel.xaml の相互作用ロジック
    /// </summary>
    public partial class HamburgerMenuPanel : ListBox
    {
        #region 依存関係プロパティ定義

        ///// <summary>
        ///// エイリアスアイコン
        ///// </summary>
        //public static readonly DependencyProperty ItemsSourceProperty = DependencyProperty.Register(
        //    "ItemsSource",
        //    typeof(IEnumerable<object>),
        //    typeof(HamburgerMenuPanel),
        //    new FrameworkPropertyMetadata());
        //#endregion

        //#region CLRラッパープロパティ
        ///// <summary>
        ///// エイリアスアイコン
        ///// </summary>
        //public IEnumerable<object> ItemsSource
        //{
        //    get { return (IEnumerable<object>)GetValue(ItemsSourceProperty); }
        //    set { SetValue(ItemsSourceProperty, value); }
        //}

        #endregion

        public HamburgerMenuPanel()
        {
            InitializeComponent();

            this.DataContext = new HamburgerMenuPanelViewModel();
        }
    }
}
