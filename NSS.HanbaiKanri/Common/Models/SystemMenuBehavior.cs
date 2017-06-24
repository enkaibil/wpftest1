using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interactivity;
using System.Windows.Interop;

namespace NSS.HanbaiKanri.Common.Models
{
    public class SystemMenuBehavior : Behavior<Window>
    {
        [DllImport("user32.dll")]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
        [DllImport("user32.dll")]
        private static extern bool EnableMenuItem(IntPtr hMenu, uint uIDEnableItem, uint uEnable);


        #region 定数
        // GetWindowLong
        private const int GWL_STYLE = -16;
        private const int GWL_EXSTYLE = -20;
        // Window Style
        private const int WS_EX_CONTEXTHELP = 0x00400;
        private const int WS_MAXIMIZEBOX = 0x10000;
        private const int WS_MINIMIZEBOX = 0x20000;
        private const int WS_SYSMENU = 0x80000;
        // Window Message
        private const int WM_SYSKEYDOWN = 0x0104;
        private const int WM_SYSCOMMAND = 0x0112;
        // Enamele
        private const uint MF_BYCOMMAND = 0x00000000;
        private const uint MF_GRAYED = 0x00000001;
        private const uint MF_ENABLED = 0x00000000;
        // System Command
        private const int SC_CLOSE = 0xF060;
        private const int SC_CONTEXTHELP = 0xF180;
        // Virtual Keyboard
        private const int VK_F4 = 0x73;
        #endregion

        #region 依存関係プロパティ定義

        /// <summary>表示/非表示</summary>
        public static readonly DependencyProperty IsVisibleProperty
            = DependencyProperty.Register(
                "IsVisible",
                typeof(bool?),
                typeof(SystemMenuBehavior),
                new FrameworkPropertyMetadata(true, OnPropertyChanged));

        /// <summary>閉じる</summary>
        public static readonly DependencyProperty IsCloseableProperty
            = DependencyProperty.Register(
                "IsCloseable",
                typeof(bool),
                typeof(SystemMenuBehavior),
                new FrameworkPropertyMetadata(false, OnPropertyChanged));

        /// <summary>最小化</summary>
        public static readonly DependencyProperty CanMinimizeProperty
            = DependencyProperty.Register(
                "CanMinimize",
                typeof(bool?),
                typeof(SystemMenuBehavior),
                new FrameworkPropertyMetadata(true, OnPropertyChanged));

        /// <summary>最大化</summary>
        public static readonly DependencyProperty CanMaximizeProperty
            = DependencyProperty.Register(
                "CanMaximize",
                typeof(bool?),
                typeof(SystemMenuBehavior),
                new FrameworkPropertyMetadata(true, OnPropertyChanged));

        /// <summary>ヘルプボタン</summary>
        public static readonly DependencyProperty ShowContextHelpProperty
            = DependencyProperty.Register(
                "ShowContextHelp",
                typeof(bool?),
                typeof(SystemMenuBehavior),
                new FrameworkPropertyMetadata(false, OnPropertyChanged));

        /// <summary>Alt + F4の有効化/無効化</summary>
        public static readonly DependencyProperty EnableAltF4Property
            = DependencyProperty.Register(
                "EnableAltF4",
                typeof(bool),
                typeof(SystemMenuBehavior),
                new FrameworkPropertyMetadata(false));

        #endregion

        #region CLRラッパープロパティ
        
        /// <summary>表示/非表示</summary>
        public bool? IsVisible
        {
            get { return (bool?)this.GetValue(IsVisibleProperty); }
            set { this.SetValue(IsVisibleProperty, value); }
        }

        /// <summary>閉じるボタン</summary>
        public bool IsCloseable
        {
            get { return (bool)this.GetValue(IsCloseableProperty); }
            set { this.SetValue(IsCloseableProperty, value); }
        }

        /// <summary>最小化</summary>
        public bool? CanMinimize
        {
            get { return (bool?)this.GetValue(CanMinimizeProperty); }
            set { this.SetValue(CanMinimizeProperty, value); }
        }

        /// <summary>最大化</summary>
        public bool? CanMaximize
        {
            get { return (bool?)this.GetValue(CanMaximizeProperty); }
            set { this.SetValue(CanMaximizeProperty, value); }
        }

        /// <summary>ヘルプボタン</summary>
        public bool? ShowContextHelp
        {
            get { return (bool?)this.GetValue(ShowContextHelpProperty); }
            set { this.SetValue(ShowContextHelpProperty, value); }
        }
        
        /// <summary>Alt + F4の有効化/無効化</summary>
        public bool EnableAltF4
        {
            get { return (bool)this.GetValue(EnableAltF4Property); }
            set { this.SetValue(EnableAltF4Property, value); }
        }
        
        #endregion

        #region Events
        // ヘルプボタンをクリックしたときに発生するイベント
        public event EventHandler ContextHelpClick = null;
        #endregion

        #region Overrides
        protected override void OnAttached()
        {
            this.AssociatedObject.SourceInitialized += this.OnSourceInitialized;
            base.OnAttached();
        }

        protected override void OnDetaching()
        {
            var source = (HwndSource)HwndSource.FromVisual(this.AssociatedObject);
            source.RemoveHook(this.HookProcedure);
            this.AssociatedObject.SourceInitialized -= this.OnSourceInitialized;
            base.OnDetaching();
        }
        #endregion

        #region Event Handlers
        // プロパティが変更されたら表示更新
        private static void OnPropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            var self = obj as SystemMenuBehavior;
            if (self != null) self.Apply();
        }

        // Windowハンドルを取得できるようになったタイミングで初期化
        private void OnSourceInitialized(object sender, EventArgs e)
        {
            this.Apply();
            var source = (HwndSource)HwndSource.FromVisual(this.AssociatedObject);
            source.AddHook(this.HookProcedure);  // メッセージフック
        }

        // メッセージ処理
        private IntPtr HookProcedure(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            // コンテキストヘルプをクリックした
            if (msg == WM_SYSCOMMAND)
            {
                if (wParam.ToInt32() == SC_CONTEXTHELP)
                {
                    handled = true;
                    var handler = this.ContextHelpClick;
                    if (handler != null) handler(this.AssociatedObject, EventArgs.Empty);
                }
            }

            // Alt + F4を無効化
            if (!this.EnableAltF4)
            {
                if (msg == WM_SYSKEYDOWN && wParam.ToInt32() == VK_F4)
                {
                    handled = true;
                }
            }

            // タスクバー閉じる無効化
            if(!this.IsCloseable)
            {
                if (msg == WM_SYSCOMMAND && wParam.ToInt32() == SC_CLOSE)
                {
                    handled = true;
                }
            }

            // ok
            return IntPtr.Zero;
        }
        #endregion

        #region Methods
        /// <summary>
        /// 設定を反映
        /// </summary>
        private void Apply()
        {
            if (this.AssociatedObject == null) return;

            // スタイル
            var hwnd = new WindowInteropHelper(this.AssociatedObject).Handle;
            var style = GetWindowLong(hwnd, GWL_STYLE);
            if (this.IsVisible.HasValue)
            {
                if (this.IsVisible.Value) style |= WS_SYSMENU;
                else style &= ~WS_SYSMENU;
            }
            if (this.CanMinimize.HasValue)
            {
                if (this.CanMinimize.Value) style |= WS_MINIMIZEBOX;
                else style &= ~WS_MINIMIZEBOX;
            }
            if (this.CanMaximize.HasValue)
            {
                if (this.CanMaximize.Value) style |= WS_MAXIMIZEBOX;
                else style &= ~WS_MAXIMIZEBOX;
            }
            SetWindowLong(hwnd, GWL_STYLE, style);

            // 閉じるボタン無効化
            IntPtr hMenu = GetSystemMenu(hwnd, false);
            if (this.IsCloseable)
            {
                EnableMenuItem(hMenu, SC_CLOSE, MF_BYCOMMAND | MF_ENABLED);
            }
            else
            {
                EnableMenuItem(hMenu, SC_CLOSE, MF_BYCOMMAND | MF_GRAYED);
            }

            // 拡張スタイル
            var exStyle = GetWindowLong(hwnd, GWL_EXSTYLE);
            if (this.ShowContextHelp.HasValue)
            {
                if (this.ShowContextHelp.Value) exStyle |= WS_EX_CONTEXTHELP;
                else exStyle &= ~WS_EX_CONTEXTHELP;
            }
            SetWindowLong(hwnd, GWL_EXSTYLE, exStyle);
        }
        #endregion
    }

}
