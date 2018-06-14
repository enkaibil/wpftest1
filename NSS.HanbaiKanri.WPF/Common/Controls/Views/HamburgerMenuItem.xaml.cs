using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace NSS.HanbaiKanri.WPF.Common.Controls.Views
{
    /// <summary>
    /// ハンバーガーメニューコントロール
    /// </summary>
    public partial class HamburgerMenuItem : Button
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
        /// メニュー展開フラグ
        /// </summary>
        public static readonly DependencyProperty IsOpenProperty = DependencyProperty.Register(
            "IsOpen",
            typeof(bool),
            typeof(HamburgerMenuItem),
            new FrameworkPropertyMetadata(false));
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
        /// メニュー展開フラグ
        /// </summary>
        public bool IsOpen
        {
            get { return (bool)GetValue(IsOpenProperty); }
            set { SetValue(IsOpenProperty, value); }
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

    #region VisibleStyleConverter
    /// <summary>
    /// ブール値からコントロールのVisiblityを設定します。
    /// True：表示、Flse：非表示（Collapsed）
    /// </summary>
    public class VisibleStyleConverter : IValueConverter
    {
        /// <summary>
        /// ソース→ターゲット変換
        /// </summary>
        /// <param name="value">変換対象値</param>
        /// <param name="targetType">変換対象の型</param>
        /// <param name="parameter">Bindingで指定されたパラメーター</param>
        /// <param name="culture">カルチャー情報</param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Visibility result = Visibility.Collapsed;

            result = (value is true) ? Visibility.Visible : Visibility.Collapsed;

            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    #endregion
}