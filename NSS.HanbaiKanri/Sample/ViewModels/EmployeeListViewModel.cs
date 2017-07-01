using NSS.HanbaiKanri.Common;
using NSS.HanbaiKanri.Sample.Models;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSS.HanbaiKanri.Sample.ViewModels
{
    public class EmployeeListViewModel : BaseViewModel
    {
        /// <summary>ウィンドウタイトル</summary>
        public override string Title { get { return "社員マスタ"; } }

        private EmployeeListModel _model = new EmployeeListModel();
        public EmployeeListModel Model
        {
            get { return _model; }
            set { SetProperty(ref _model, value); }
        }

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public EmployeeListViewModel() : base()
        {
        }
        #endregion

        /// <summary>
        /// 画面初期表示イベント
        /// <param name="navigationContext">ナビゲーション情報</param>
        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            // 基底クラスの処理＜＜必須＞＞
            base.OnNavigatedTo(navigationContext);

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


    }
}
