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

namespace NSS.HanbaiKanri.Common
{
    public abstract class BaseViewModel : BindableBase, IConfirmNavigationRequest
    {
        /// <summary>ウィンドウタイトル</summary>
        public abstract string Title { get; }

        [Dependency]
        /// <summary>イベントアグリゲーターオブジェクト</summary>
        public IEventAggregator EventAggregator { get; set; }

        [Dependency]
        /// <summary>リージョンマネージャ</summary>
        public IRegionManager RegionManager { get; set; }

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
        /// <param name="targetView">遷移先VIEW</param>
        protected void RequestNavigate(UserControl targetView)
        {
            this.RegionManager.RequestNavigate("main", nameof(targetView));
        }

        /// <summary>
        /// 戻るボタン押下処理
        /// </summary>
        protected virtual void OnBackButtonClick()
        {
            Debug.WriteLine("OnBackButtonClick");
        }

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

        #region INavigationAwareインターフェースメンバ
        /// <summary>
        /// 一度生成された画面のインスタンスを再使用するかを判定します。
        /// </summary>
        /// <param name="navigationContext"></param>
        /// <returns>true:再利用する, false:再利用しない</returns>
        public virtual bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return false;
        }

        /// <summary>
        /// 画面に遷移してきたときに呼び出されるメソッド
        /// </summary>
        /// <param name="navigationContext"></param>
        public virtual void OnNavigatedTo(NavigationContext navigationContext)
        {
            // シェル画面以外であればページ情報イベントを発行する。
            if (!(this is ShellViewModel))
            {
                PageInfoPubSubEvent.Publish(this.EventAggregator, this);
            }

            // バックボタン押下イベントを購読する。
            BackButtonClickPubSubEvent.Subscribe(this.EventAggregator, OnBackButtonClick);
        }

        /// <summary>
        /// 画面から遷移する前に呼び出されるメソッド
        /// </summary>
        /// <param name="navigationContext"></param>
        public virtual void OnNavigatedFrom(NavigationContext navigationContext)
        {
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
