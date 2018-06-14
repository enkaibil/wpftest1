using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Events;
using NSS.HanbaiKanri.WPF.Common.Models;
using NSS.HanbaiKanri.WPF.Common.Controls.ViewModels;
using Microsoft.Practices.Unity;

namespace NSS.HanbaiKanri.WPF.Common
{
    public abstract class BaseViewModel : BindableBase, IConfirmNavigationRequest, IRegionMemberLifetime
    {
        #region 変数定義

        /// <summary>リージョンナビゲーションジャーナル</summary>
        private IRegionNavigationJournal _journal;

        /// <summary>戻るボタン押下イベントトークン</summary>
        private SubscriptionToken _backButtonClickToken;

        /// <summary>リージョンマネージャ</summary>
        private IRegionManager _regionManager;

        #endregion

        #region プロパティ定義

        /// <summary>ウィンドウタイトル</summary>
        public abstract string Title { get; }

        /// <summary>ダイアログサービス</summary>
        [Dependency]
        public IDialogService DialogService { get; set; }

        /// <summary>イベントアグリゲーターオブジェクト</summary>
        [Dependency]
        public IEventAggregator EventAggregator { get; set; }

        /// <summary>リージョンマネージャ</summary>
        [Dependency]
        [Obsolete("リージョンマネージャは直接使用せず、画面遷移にはBaseViewModelのRequestNavigateメソッドを使用してください。")]
        public IRegionManager RegionManager
        {
            get { return _regionManager; }
            set { _regionManager = value; }
        }

        /// <summary>初期表示フラグ</summary>
        public bool IsInit { get; private set; }

        #endregion

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public BaseViewModel() : base()
        {
            KeepAlive = true;
            IsInit = true;
        }
        #endregion

        #region RequestNavigate
        /// <summary>
        /// 指定したページに遷移します。
        /// </summary>
        /// <typeparam name="targetView">遷移先VIEW</typeparam>
        protected void RequestNavigate<TargetView>()
        where TargetView : UserControl
        {
            this.RequestNavigate<TargetView>(new NavigationParameters());
        }

        /// <summary>
        /// 指定したページに遷移します。
        /// </summary>
        /// <typeparam name="targetView">遷移先VIEW</typeparam>
        /// <param name="param">画面間パラメータ</param>
        protected void RequestNavigate<TargetView>(NavigationParameters param)
        where TargetView : UserControl
        {
            _regionManager.RequestNavigate("main", typeof(TargetView).Name, param);
        }
        #endregion
        
        #region OnLoad
        /// <summary>
        /// 画面が読み込まれた時の処理を実装するための仮想関数
        /// </summary>
        /// <param name="args">パラメータ</param>
        public virtual void OnLoad(NavigationParameters args)
        {
        }
        #endregion

        #region OnLeave
        /// <summary>
        /// 画面から離れる時の処理を実装するための仮想関数
        /// </summary>
        /// <param name="args">パラメータ</param>
        public virtual void OnLeave(NavigationParameters args)
        {
        }
        #endregion

        #region OnBackButtonClick
        /// <summary>
        /// 戻るボタン押下処理用仮想関数
        /// </summary>
        /// <remarks>
        /// 処理をカスタマイズしたい場合、このメソッドをオーバーライドしてください。
        /// </remarks>
        protected virtual void OnBackButtonClick()
        {
            // 戻るボタンが押された場合、Viewのインスタンスを破棄するよう設定。
            this.KeepAlive = false;

            // ひとつ前の画面に戻る
            if (_journal != null) _journal.GoBack();
        }
        #endregion

        #region IRegionMemberLifetimeインターフェースメンバ

        /// <summary>画面遷移時にViewのインスタンスを維持するかどうか</summary>
        public bool KeepAlive { get; set; }

        #endregion

        #region IConfirmNavigationRequest(INavigationAware)インターフェースメンバ
        /// <summary>
        /// 一度生成された画面のインスタンスを再使用するかを判定します。
        /// （基本は「true:再利用する」）
        /// 変更する場合、オーバーライドしてください。
        /// </summary>
        /// <param name="navigationContext">ナビゲーション情報</param>
        /// <returns>true:再利用する, false:再利用しない</returns>
        public virtual bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        /// <summary>
        /// 画面遷移をキャンセルするか否かを判定するメソッド。
        /// 判定を実装する場合、オーバーライドしてください。
        /// </summary>
        /// <param name="navigationContext">ナビゲーション情報</param>
        /// <param name="continuationCallback"></param>
        public virtual void ConfirmNavigationRequest(NavigationContext navigationContext, Action<bool> continuationCallback)
        {
            // true :ナビゲーション実行
            // false:ナビゲーションキャンセル
            continuationCallback(true);
        }

        /// <summary>
        /// 画面に遷移してきたときに呼び出されるメソッド。
        /// </summary>
        /// <param name="navigationContext">ナビゲーション情報</param>
        [Obsolete("INavigationAwareインターフェース実装用のメソッドです。画面遷移時の処理を実行する場合、OnLoadメソッドをオーバーライドしてください。")]
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

            this.OnLoad(navigationContext.Parameters);

            // 初期起動フラグを解除する。
            this.IsInit = false;
        }

        /// <summary>
        /// 画面から離れる前に呼び出されるメソッド。
        /// </summary>
        /// <param name="navigationContext">ナビゲーション情報</param>
        [Obsolete("INavigationAwareインターフェース実装用のメソッドです。画面から離れる際の処理を実行する場合、OnLeaveメソッドをオーバーライドしてください。")]
        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            // バックボタン押下イベントの購読停止。
            BackButtonClickPubSubEvent.UnSubscribe(_backButtonClickToken);

            this.OnLeave(navigationContext.Parameters);
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
