using Prism.Unity;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Prism.Mvvm;

namespace NSS.HanbaiKanri.Common
{
    class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            // this.ContainerでUnityのコンテナが取得できるので
            // そこからShellを作成する
            return this.Container.Resolve<Shell>();
        }

        protected override void InitializeShell()
        {
            // Shellを表示する
            ((Window)this.Shell).Show();
        }

        protected override void ConfigureViewModelLocator()
        {
            base.ConfigureViewModelLocator();
            // ViewとViewModelの紐付ルール変更
            ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver(viewType =>
            {
                return Type.GetType(viewType.FullName + "Model");
            });
        }
    }
}
