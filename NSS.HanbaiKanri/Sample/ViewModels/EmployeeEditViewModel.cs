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
    /// <summary>
    /// 社員マスタ登録画面用ViewModelクラス
    /// </summary>
    public class EmployeeEditViewModel : BaseViewModel
    {
        /// <summary>ウィンドウタイトル</summary>
        public override string Title { get { return "社員マスタ登録"; } }

        /// <summary>Modelクラス</summary>
        public EmployeeEditModel Model
        {
            get { return _model; }
            set { SetProperty(ref _model, value); }
        }
        private EmployeeEditModel _model = new EmployeeEditModel();

        /// <summary>
        /// 画面初期表示イベント
        /// <param name="navigationContext">ナビゲーション情報</param>
        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            // 基底クラスの処理＜＜必須＞＞
            base.OnNavigatedTo(navigationContext);

            // 画面間パラメータの取得
            string shainCode = navigationContext.Parameters[EmployeeConst.ListSelectKey].ToString();

            // 初期化処理
            Model.InitAction(shainCode);

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
