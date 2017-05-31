using NSS.HanbaiKanri.StartMenu;
using Prism.Commands;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSS.HanbaiKanri.Common
{
    public class ShellViewModel : BaseViewModel
    {
        public DelegateCommand CMD_Form_Loaded { get; }
        public DelegateCommand CMD_btnBack_Click { get; }
        public DelegateCommand<object> CMD_Region_Chenged { get; }

        public ShellViewModel()
        {
            CMD_Form_Loaded = new DelegateCommand(From_Loaded);
            CMD_btnBack_Click = new DelegateCommand(btnBack_Click);
        }

        public void From_Loaded()
        {
            this.RegionManager.RequestNavigate("main", nameof(StartMenuView));
        }

        public void btnBack_Click()
        {
            // バックボタンが押された場合、
            // リージョンに表示しているビューにNavigationTromイベントをキックさせるために空ページへの遷移を実行する。
            this.RegionManager.RequestNavigate("main", string.Empty);
        }
    }
}
