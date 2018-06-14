using Prism.Unity;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Prism.Mvvm;
using System.Windows.Controls;
using System.Reflection;
using Prism.Events;
using NSS.HanbaiKanri.WPF.Common.Models;
using NSS.HanbaiKanri.WPF.Common.Controls.Views;
using NSS.HanbaiKanri.WPF.Common;

namespace NSS.HanbaiKanri.WPF
{
    public class Bootstrapper : UnityBootstrapper
    {
        /// <summary>
        /// シェルウィンドウを生成する。
        /// </summary>
        /// <returns>シェルウィンドウ</returns>
        protected override DependencyObject CreateShell()
        {
            // this.ContainerでUnityのコンテナが取得できるので
            // そこからShellを作成する
            return this.Container.Resolve<ShellView>();
        }

        /// <summary>
        /// シェルウィンドウを表示する。
        /// </summary>
        protected override void InitializeShell()
        {
            // Shellのハンドルを保持しておく
            SystemConst.Global.ActiveWindow = (Window)this.Shell;

            // Shellを表示する
            ((Window)this.Shell).Show();
        }

        ///// <summary>
        ///// ViewとViewModelの自動紐づけルールを設定する。
        ///// </summary>
        //protected override void ConfigureViewModelLocator()
        //{
        //    base.ConfigureViewModelLocator();
        //    // ViewとViewModelの紐付ルール変更
        //    //ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver(viewType =>
        //    //{
        //    //    return Type.GetType(viewType.FullName + "Model");
        //    //});
        //}

        /// <summary>
        /// コンテナへの格納の設定。
        /// </summary>
        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            // ダイアログサービスの登録
            this.Container.RegisterType<IDialogService, DialogService>();

            // Viewを全てobject型としてコンテナに登録しておく（RegionManagerで使うため）
            var views = (from x in AllClasses.FromLoadedAssemblies()
                         where (x.BaseType == typeof(Window) || x.BaseType == typeof(UserControl))
                                && x.FullName.StartsWith("NSS.HanbaiKanri.WPF")
                         select x);
            this.Container.RegisterTypes(views,
                getFromTypes: _ => new[] { typeof(object) },
                getName: WithName.TypeName);
        }
    }
}
