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
using System.Diagnostics;
using System.Windows;
using System.Windows.Media;
using NSS.HanbaiKanri.Common.Controls;
using NSS.HanbaiKanri.Common.Controls.ViewModels;

namespace NSS.HanbaiKanri.Common
{
    public abstract class BaseViewModel : BindableBase, IConfirmNavigationRequest, IRegionMemberLifetime
    {
        /// <summary>ウィンドウタイトル</summary>
        public abstract string Title { get; }

        private IRegionNavigationJournal _journal;

        private SubscriptionToken _backButtonClickToken;

        [Dependency]
        /// <summary>イベントアグリゲーターオブジェクト</summary>
        public IEventAggregator EventAggregator { get; set; }

        [Dependency]
        /// <summary>リージョンマネージャ</summary>
        public IRegionManager RegionManager { get; set; }

        public bool KeepAlive { get { return false; } }


        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public BaseViewModel() : base()
        {
        }
        #endregion

        /// <summary>
        /// 指定したページに遷移します。
        /// </summary>
        /// <typeparam name="targetView">遷移先VIEW</typeparam>
        protected void RequestNavigate<TargetView>()
        where TargetView : UserControl
        {
            this.RequestNavigate<TargetView>(null);
        }

        /// <summary>
        /// 指定したページに遷移します。
        /// </summary>
        /// <typeparam name="targetView">遷移先VIEW</typeparam>
        protected void RequestNavigate<TargetView>(NavigationParameters param)
        where TargetView : UserControl
        {
            this.RegionManager.RequestNavigate("main", typeof(TargetView).Name, param);
        }

        /// <summary>
        /// 戻るボタン押下処理
        /// </summary>
        protected virtual void OnBackButtonClick()
        {
            // ひとつ前の画面に戻る
            if (_journal != null) _journal.GoBack();
        }


        #region INavigationAwareインターフェースメンバ
#warning 呼ばれてない？？
        /// <summary>
        /// 一度生成された画面のインスタンスを再使用するかを判定します。
        /// 基本は再利用せず都度インスタンスを生成します。
        /// </summary>
        /// <param name="navigationContext">ナビゲーション情報</param>
        /// <returns>true:再利用する, false:再利用しない</returns>
        public virtual bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return false;
        }

        /// <summary>
        /// 画面に遷移してきたときに呼び出されるメソッド。
        /// overrideする場合、基底クラスの処理を必ず呼び出すこと。
        /// </summary>
        /// <param name="navigationContext">ナビゲーション情報</param>
        public virtual void OnNavigatedTo(NavigationContext navigationContext)
        {
            _journal = navigationContext.NavigationService.Journal;

            // シェル画面以外であればページ情報イベントを発行する。
            if (!(this is ShellViewModel))
            {
                PageInfoPubSubEvent.Publish(this.EventAggregator, this);
            }

            // バックボタン押下イベントを購読する。
            _backButtonClickToken = BackButtonClickPubSubEvent.Subscribe(this.EventAggregator, OnBackButtonClick);
        }

        /// <summary>
        /// 画面から遷移する前に呼び出されるメソッド。
        /// overrideする場合、基底クラスの処理を必ず呼び出すこと。
        /// </summary>
        /// <param name="navigationContext">ナビゲーション情報</param>
        public virtual void OnNavigatedFrom(NavigationContext navigationContext)
        {
            // バックボタン押下イベントの購読停止。
            BackButtonClickPubSubEvent.UnSubscribe(_backButtonClickToken);
        }

        /// <summary>
        /// 画面遷移をキャンセルするか否かを判定するメソッド。
        /// </summary>
        /// <param name="navigationContext">ナビゲーション情報</param>
        /// <param name="continuationCallback"></param>
        public virtual void ConfirmNavigationRequest(NavigationContext navigationContext, Action<bool> continuationCallback)
        {
            // true :ナビゲーション実行
            // false:ナビゲーションキャンセル
            continuationCallback(true);
        }
        #endregion

        #region FindVisualChild
        /// <summary>
        /// ビジュアルツリー内のノードから指定の要素を取得します。
        /// </summary>
        /// <typeparam name="T">取得対象要素の型</typeparam>
        /// <param name="obj">検索対象</param>
        /// <returns>取得結果</returns>
        private T FindVisualChild<T>(DependencyObject obj)
        where T : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(obj, i);
                if (child != null && child is T)
                {
                    return (T)child;
                }
                else
                {
                    T childOfChild = FindVisualChild<T>(child);
                    if (childOfChild != null) return childOfChild;
                }
            }
            return null;
        }
        #endregion
    }
}
