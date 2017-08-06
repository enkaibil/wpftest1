using Microsoft.WindowsAPICodePack.Dialogs;
using NSS.HanbaiKanri.Common;
using NSS.HanbaiKanri.Sample.Models;
using Prism.Commands;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static NSS.HanbaiKanri.DataAccess.BusinessLogic.Common.BLConst;

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

        /// <summary>削除ボタン押下</summary>
        public DelegateCommand CMD_btnDel_Click { get; }

        #endregion

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public EmployeeEditViewModel() : base()
        {
            CMD_btnSave_Click = new DelegateCommand(btnSave_Click);
            CMD_btnDel_Click = new DelegateCommand(btnDel_Click);
        }
        #endregion

        /// <summary>
        /// 初期表示イベント
        /// </summary>
        /// <param name="args">パラメータ</param>
        public override void OnLoad(NavigationParameters args)
        {
            // 画面間パラメータの取得
            string shainCode = args[EmployeeConst.ListSelectKey]?.ToString();

            // 初期化処理
            Model.InitAction(shainCode);
        }

        /// <summary>
        /// 保存ボタン押下イベント
        /// </summary>
        public void btnSave_Click()
        {
            // 入力チェック
            if(!Model.ValidateInput())
            {
                DialogService.ShowWarning("画面に入力エラーがあります。");
                return;
            }

            // 確認メッセージ
            TaskDialogResult dr = DialogService.ShowConfirm("変更を保存しますか。");
            if (dr != TaskDialogResult.Yes) return;

            BusinessErrorCode errCode = Model.SaveAction(false);

            if (errCode == BusinessErrorCode.Sucsess)
            {
                // 完了メッセージの表示
                DialogService.ShowInformation("保存しました。");

                // 画面を閉じる。
                base.OnBackButtonClick();
            }
            else
            {
                // エラー処理
            }
        }

        /// <summary>
        /// 削除ボタン押下イベント
        /// </summary>
        private void btnDel_Click()
        {
            Model.SaveAction(true);
        }
    }
}
