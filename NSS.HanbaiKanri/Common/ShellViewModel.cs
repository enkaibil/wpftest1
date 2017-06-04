using Microsoft.Practices.Unity;
using NSS.HanbaiKanri.Common.Models;
using NSS.HanbaiKanri.StartMenu;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using Reactive.Bindings;
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
        public PageInfoSubscriber sub = new PageInfoSubscriber();

        public HeaderInfoModel HeaderInfo { get; set; }

        /// <summary>ウィンドウタイトル</summary>
        public override string Title { get { return "BLANK"; } }

        public DelegateCommand CMD_Form_Loaded { get; }
        public DelegateCommand CMD_btnBack_Click { get; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ShellViewModel()
        {
            if (this.EventAggregator == null) EventAggregator = new EventAggregator();

            // Model初期化
            HeaderInfo = new HeaderInfoModel(EventAggregator, sub);

            // イベント定義
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
