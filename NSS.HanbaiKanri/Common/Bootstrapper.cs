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
using NSS.HanbaiKanri.Common.Models;
using NSS.HanbaiKanri.Common.Controls;
using NSS.HanbaiKanri.Common.Controls.Views;

namespace NSS.HanbaiKanri.Common
{
    class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            // this.ContainerでUnityのコンテナが取得できるので
            // そこからShellを作成する
            return this.Container.Resolve<ShellView>();
        }

        protected override void InitializeShell()
        {
            // Shellを表示する
            ((Window)this.Shell).Show();
        }

        //protected override void ConfigureViewModelLocator()
        //{
        //    base.ConfigureViewModelLocator();
        //    // ViewとViewModelの紐付ルール変更
        //    //ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver(viewType =>
        //    //{
        //    //    return Type.GetType(viewType.FullName + "Model");
        //    //});
        //}

        protected override void ConfigureModuleCatalog()
        {
            base.ConfigureModuleCatalog();


        }
        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            // Viewを全てobject型としてコンテナに登録しておく（RegionManagerで使うため）
            var views = (from x in AllClasses.FromLoadedAssemblies()
                         where (x.BaseType == typeof(Window) || x.BaseType == typeof(UserControl))
                                && x.FullName.StartsWith("NSS.HanbaiKanri")
                         select x);
            this.Container.RegisterTypes(views,
                getFromTypes: _ => new[] { typeof(object) },
                getName: WithName.TypeName);
        }
    }
}
