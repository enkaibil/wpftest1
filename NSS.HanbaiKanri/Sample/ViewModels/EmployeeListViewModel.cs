using NSS.HanbaiKanri.Common;
using NSS.HanbaiKanri.DataAccess.BusinessLogic.Sample;
using NSS.HanbaiKanri.Sample.Models;
using NSS.HanbaiKanri.Sample.Views;
using Prism.Commands;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSS.HanbaiKanri.Sample.ViewModels
{
    /// <summary>
    /// 社員マスタ一覧画面用ViewModelクラス
    /// </summary>
    public class EmployeeListViewModel : BaseViewModel
    {
        /// <summary>ウィンドウタイトル</summary>
        public override string Title { get { return "社員マスタ一覧"; } }

        /// <summary>Modelクラス</summary>
        public EmployeeListModel Model
        {
            get { return _model; }
            set { SetProperty(ref _model, value); }
        }
        private EmployeeListModel _model = new EmployeeListModel();

        #region Command定義

        /// <summary>検索ボタン押下</summary>
        public DelegateCommand CMD_btnSearch_Click { get; }

        /// <summary>選択処理</summary>
        public DelegateCommand CMD_List_Select { get; }
        #endregion

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public EmployeeListViewModel() : base()
        {
            CMD_btnSearch_Click = new DelegateCommand(btnSearch_Click);
            CMD_List_Select = new DelegateCommand(List_Select);
        }
        #endregion

        /// <summary>
        /// 画面初期表示イベント
        /// <param name="navigationContext">ナビゲーション情報</param>
        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            // 基底クラスの処理＜＜必須＞＞
            base.OnNavigatedTo(navigationContext);

            // 初期表示処理
            Model.InitAction();
        }

        /// <summary>
        /// 画面終了前イベント
        /// </summary>
        /// <param name="navigationContext">ナビゲーション情報</param>
        public override void OnNavigatedFrom(NavigationContext navigationContext)
        {
            // 基底クラスの処理＜＜必須＞＞
            base.OnNavigatedFrom(navigationContext);

        }

        /// <summary>
        /// 画面インスタンスの破棄確認
        /// </summary>
        /// <param name="navigationContext">ナビゲーション情報</param>
        public override bool IsNavigationTarget(NavigationContext navigationContext)
        {
            if(navigationContext.Parameters.Count() > 0)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 検索ボタン押下イベント
        /// </summary>
        public void btnSearch_Click()
        {
            Model.SearchAction();
        }

        /// <summary>
        /// 選択ボタン押下イベント
        /// </summary>
        public void List_Select()
        {
            // 選択処理
            string selectValue = Model.SelectAction();

            if (!string.IsNullOrEmpty(selectValue))
            {
                // パラメータの設定
                NavigationParameters param = new NavigationParameters();
                param.Add(EmployeeConst.ListSelectKey, selectValue);

                // 画面遷移
                this.RequestNavigate<EmployeeEditView>(param);
            }
        }
    }
}
