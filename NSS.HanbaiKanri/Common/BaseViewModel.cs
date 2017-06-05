using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using Prism.Regions;
using Microsoft.Practices.Unity;
using NSS.HanbaiKanri.Common.Models;
using System.Windows.Controls;
using Prism.Events;

namespace NSS.HanbaiKanri.Common
{
    public abstract class BaseViewModel : BindableBase, IConfirmNavigationRequest
    {
        /// <summary>ウィンドウタイトル</summary>
        public abstract string Title { get; }

        [Dependency]
        public IEventAggregator EventAggregator { get; set; }

        [Dependency]
        public IRegionManager RegionManager { get; set; }

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public BaseViewModel() : base()
        {
        }
        #endregion

        protected void RequestNavigate(UserControl targetView)
        {
            this.RegionManager.RequestNavigate("main", nameof(targetView));
        }

        #region INavigationAwareインターフェースメンバ
        /// <summary>
        /// 一度生成された画面のインスタンスを再使用するかを判定します。
        /// </summary>
        /// <param name="navigationContext"></param>
        /// <returns>true:再利用する, false:再利用しない</returns>
        public virtual bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        /// <summary>
        /// 画面に遷移してきたときに呼び出されるメソッド
        /// </summary>
        /// <param name="navigationContext"></param>
        public virtual void OnNavigatedTo(NavigationContext navigationContext)
        {
        }

        /// <summary>
        /// 画面から遷移する前に呼び出されるメソッド
        /// </summary>
        /// <param name="navigationContext"></param>
        public virtual void OnNavigatedFrom(NavigationContext navigationContext)
        {
            PageInfoPubSubEvent.Publish(this.EventAggregator, this);
        }

        /// <summary>
        /// 画面遷移をキャンセルするか否かを判定するメソッド
        /// </summary>
        /// <param name="navigationContext"></param>
        /// <param name="continuationCallback"></param>
        public virtual void ConfirmNavigationRequest(NavigationContext navigationContext, Action<bool> continuationCallback)
        {
            // true :ナビゲーション実行
            // false:ナビゲーションキャンセル
            continuationCallback(true);
        }
        #endregion
    }
}
