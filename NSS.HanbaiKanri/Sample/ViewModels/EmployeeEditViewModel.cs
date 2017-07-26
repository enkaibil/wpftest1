using NSS.HanbaiKanri.Common;
using NSS.HanbaiKanri.Sample.Models;
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

        #region Command定義

        /// <summary>保存ボタン押下</summary>
        public DelegateCommand CMD_btnSave_Click { get; }

        #endregion

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public EmployeeEditViewModel() : base()
        {
            CMD_btnSave_Click = new DelegateCommand(btnSave_Click);
        }
        #endregion

        /// <summary>
        /// 初期表示イベント
        /// </summary>
        /// <param name="sender">遷移元View</param>
        /// <param name="args">パラメータ</param>
        protected override void OnLoad(Type sender, NavigationParameters args)
        {
            // 画面間パラメータの取得
            string shainCode = args[EmployeeConst.ListSelectKey]?.ToString();

            // 初期化処理
            Model.InitAction(shainCode);
        }

        /// <summary>
        /// 保存ボタン押下イベント
        /// </summary>
        private void btnSave_Click()
        {

        }
    }
}
