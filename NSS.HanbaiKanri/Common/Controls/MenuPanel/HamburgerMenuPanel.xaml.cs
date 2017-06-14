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

        /// <summary>
        /// メニュー展開時横幅
        /// </summary>
        public static readonly DependencyProperty OpenWidthProperty = DependencyProperty.Register(
            "OpenWidth",
            typeof(IEnumerable<object>),
            typeof(HamburgerMenuPanel),
            new FrameworkPropertyMetadata());
        #endregion

        #region CLRラッパープロパティ
        /// <summary>
        /// メニュー展開時横幅
        /// </summary>
        public int OpenWidth
        {
            get { return (int)GetValue(OpenWidthProperty); }
            set { SetValue(OpenWidthProperty, value); }
        }

        #endregion

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public HamburgerMenuPanel()
        {
            InitializeComponent();

            // ViewとViewModelの紐付け
            this.DataContext = new HamburgerMenuPanelViewModel();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            int a = 1;
            if(this.DataContext == null)
            {
                a++;
            }
        }
    }
}
