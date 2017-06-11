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

namespace NSS.HanbaiKanri.Common.Controls.MenuItem
{
    /// <summary>
    /// ハンバーガーメニューコントロール
    /// </summary>
    public partial class HamburgerMenuItem : UserControl
    {
        #region 依存関係プロパティ定義

        /// <summary>
        /// エイリアスアイコン
        /// </summary>
        public static readonly DependencyProperty AliasProperty = DependencyProperty.Register(
            "Alias",
            typeof(string),
            typeof(HamburgerMenuItem),
            new FrameworkPropertyMetadata(string.Empty));

        /// <summary>
        /// メニュー項目名
        /// </summary>
        public static readonly DependencyProperty CaptionProperty = DependencyProperty.Register(
            "Caption",
            typeof(string),
            typeof(HamburgerMenuItem),
            new FrameworkPropertyMetadata("メニュー"));
        /// <summary>
        /// コマンド
        /// </summary>
        public static readonly DependencyProperty CommandProperty = DependencyProperty.Register(
            "Command",
            typeof(ICommand),
            typeof(HamburgerMenuItem),
            new FrameworkPropertyMetadata());
        #endregion

        #region CLRラッパープロパティ

        /// <summary>
        /// エイリアスアイコン
        /// </summary>
        public string Alias
        {
            get { return (string)GetValue(AliasProperty); }
            set { SetValue(AliasProperty, value); }
        }

        /// <summary>
        /// キャプション
        /// </summary>
        public string Caption
        {
            get { return (string)GetValue(CaptionProperty); }
            set { SetValue(CaptionProperty, value); }
        }

        /// <summary>
        /// コマンド
        /// </summary>
        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        #endregion

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public HamburgerMenuItem()
        {
            InitializeComponent();
        }
        #endregion
    }
}