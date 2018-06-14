using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;

namespace NSS.HanbaiKanri.WPF.Common.Models
{
    public interface IDialogService
    {
        /// <summary>
        /// インフォメーションメッセージダイアログを表示します。
        /// </summary>
        /// <param name="messageID">メッセージID</param>
        /// <param name="parameter">メッセージパラメータ</param>
        /// <returns>ダイアログ結果</returns>
        TaskDialogResult ShowInformation(string messageID, params string[] parameter);

        /// <summary>
        /// ワーニングメッセージを表示します。
        /// </summary>
        /// <param name="messageID">メッセージID</param>
        /// <param name="parameter">メッセージパラメータ</param>
        /// <returns>ダイアログ結果</returns>
        TaskDialogResult ShowWarning(string messageID, params string[] parameter);

        /// <summary>
        /// エラーメッセージを表示します。
        /// </summary>
        /// <param name="ex">エラー情報</param>
        /// <returns>ダイアログ結果</returns>
        TaskDialogResult ShowError(Exception ex);

        /// <summary>
        /// 確認メッセージを表示します。
        /// </summary>
        /// <param name="messageID">メッセージID</param>
        /// <param name="parameter">メッセージパラメータ</param>
        /// <returns>ダイアログ結果</returns>
        TaskDialogResult ShowConfirm(string messageID, params string[] parameter);

        /// <summary>
        /// 警告確認メッセージを表示します。
        /// </summary>
        /// <param name="messageID">メッセージID</param>
        /// <param name="parameter">メッセージパラメータ</param>
        /// <returns>ダイアログ結果</returns>
        TaskDialogResult ShowWarningConfirm(string messageID, params string[] parameter);
    }

    /// <summary>
    /// メッセージダイアログ表示サービス
    /// </summary>
    public class DialogService : IDialogService
    {
        /// <summary>
        /// インフォメーションメッセージを表示します。
        /// </summary>
        /// <param name="messageID">メッセージID</param>
        /// <param name="parameter">メッセージパラメータ</param>
        /// <returns>ダイアログ結果</returns>
        public TaskDialogResult ShowInformation(string messageID, params string[] parameter)
        {
            // ダイアログの生成
            TaskDialog dlg = new TaskDialog();
            dlg.Caption = SystemConst.SystemTitle;
            dlg.InstructionText = "情報";
            dlg.Icon = TaskDialogStandardIcon.Information;
            dlg.StandardButtons = TaskDialogStandardButtons.Ok;
            // オーナーウィンドウの設定
            if (SystemConst.Global.ActiveWindow != null)
            {
                dlg.OwnerWindowHandle = new WindowInteropHelper(SystemConst.Global.ActiveWindow).Handle;
                dlg.StartupLocation = TaskDialogStartupLocation.CenterOwner;
            }

            // メッセージ本文
            dlg.Text = messageID;

            return dlg.Show();
        }

        /// <summary>
        /// ワーニングメッセージを表示します。
        /// </summary>
        /// <param name="messageID">メッセージID</param>
        /// <param name="parameter">メッセージパラメータ</param>
        /// <returns>ダイアログ結果</returns>
        public TaskDialogResult ShowWarning(string messageID, params string[] parameter)
        {
            // ダイアログの生成
            TaskDialog dlg = new TaskDialog();
            dlg.Caption = SystemConst.SystemTitle;
            dlg.InstructionText = "警告";
            dlg.Icon = TaskDialogStandardIcon.Warning;
            dlg.StandardButtons = TaskDialogStandardButtons.Ok;
            // オーナーウィンドウの設定
            if (SystemConst.Global.ActiveWindow != null)
            {
                dlg.OwnerWindowHandle = new WindowInteropHelper(SystemConst.Global.ActiveWindow).Handle;
                dlg.StartupLocation = TaskDialogStartupLocation.CenterOwner;
            }

            // メッセージ本文
            dlg.Text = messageID;

            return dlg.Show();
        }

        /// <summary>
        /// エラーメッセージを表示します。
        /// </summary>
        /// <param name="ex">エラー情報</param>
        /// <returns>ダイアログ結果</returns>
        public TaskDialogResult ShowError(Exception ex)
        {
            // ダイアログの生成
            TaskDialog dlg = new TaskDialog();
            dlg.Opened += new EventHandler(taskDialog_Opened);
            dlg.Caption = SystemConst.SystemTitle;
            dlg.InstructionText = "エラー";
            dlg.Icon = TaskDialogStandardIcon.Error;
            dlg.StandardButtons = TaskDialogStandardButtons.Ok;
            // オーナーウィンドウの設定
            if (SystemConst.Global.ActiveWindow != null)
            {
                dlg.OwnerWindowHandle = new WindowInteropHelper(SystemConst.Global.ActiveWindow).Handle;
                dlg.StartupLocation = TaskDialogStartupLocation.CenterOwner;
            }

            // メッセージ本文
            dlg.Text = "予期せぬエラーが発生しました。";

            // エラー詳細
            dlg.DetailsCollapsedLabel = "エラー詳細を表示";
            dlg.DetailsExpandedLabel = "エラー詳細を非表示";
            
            StringBuilder errStr = new StringBuilder();
            errStr.AppendLine($"【Exception】 {ex.GetType().ToString()}");
            errStr.AppendLine("【Message】");
            errStr.AppendLine(ex.Message);

            if(ex.InnerException != null)
            {
                Exception innerEx = ex.InnerException;
                errStr.AppendLine();
                errStr.AppendLine($"【InnerException】 {innerEx.GetType().ToString()}");
                errStr.AppendLine("【Message】");
                errStr.AppendLine(innerEx.Message);
            }

            // 最初の10行だけスタックトレースを出力
            errStr.AppendLine();
            errStr.AppendLine("【StackTrace】");

            string[] spritValue = ex.StackTrace.Split(
                new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            int valueCnt = (spritValue.Length >= 10) ? 10 : spritValue.Length;
            for(int i = 0; i<valueCnt; i++)
            {
                errStr.AppendLine(spritValue[i]);
            }

            dlg.DetailsExpandedText = errStr.ToString();
            dlg.ExpansionMode = TaskDialogExpandedDetailsLocation.ExpandFooter;

            return dlg.Show();
        }

        /// <summary>
        /// 確認メッセージを表示します。
        /// </summary>
        /// <param name="messageID">メッセージID</param>
        /// <param name="parameter">メッセージパラメータ</param>
        /// <returns>ダイアログ結果</returns>
        public TaskDialogResult ShowConfirm(string messageID, params string[] parameter)
        {
            // ダイアログの生成
            TaskDialog dlg = new TaskDialog();
            dlg.Caption = SystemConst.SystemTitle;
            dlg.InstructionText = "確認";
            dlg.Icon = (TaskDialogStandardIcon)32514;
            // オーナーウィンドウの設定
            if (SystemConst.Global.ActiveWindow != null)
            {
                dlg.OwnerWindowHandle = new WindowInteropHelper(SystemConst.Global.ActiveWindow).Handle;
                dlg.StartupLocation = TaskDialogStartupLocation.CenterOwner;
            }

            var yesButton = new TaskDialogButton();
            yesButton.Text = "はい";
            yesButton.Default = true;
            yesButton.Click += (sender, e) => dlg.Close(TaskDialogResult.Yes);
            dlg.Controls.Add(yesButton);

            var noButton = new TaskDialogButton();
            noButton.Text = "いいえ";
            noButton.Click += (sender, e) => dlg.Close(TaskDialogResult.No);
            dlg.Controls.Add(noButton);

            // メッセージ本文
            dlg.Text = messageID;

            return dlg.Show();
        }

        /// <summary>
        /// 警告確認メッセージを表示します。
        /// </summary>
        /// <param name="messageID">メッセージID</param>
        /// <param name="parameter">メッセージパラメータ</param>
        /// <returns>ダイアログ結果</returns>
        public TaskDialogResult ShowWarningConfirm(string messageID, params string[] parameter)
        {
            // ダイアログの生成
            TaskDialog dlg = new TaskDialog();
            dlg.Caption = SystemConst.SystemTitle;
            dlg.InstructionText = "確認";
            dlg.Icon = TaskDialogStandardIcon.Warning;
            // オーナーウィンドウの設定
            if (SystemConst.Global.ActiveWindow != null)
            {
                dlg.OwnerWindowHandle = new WindowInteropHelper(SystemConst.Global.ActiveWindow).Handle;
                dlg.StartupLocation = TaskDialogStartupLocation.CenterOwner;
            }

            var yesButton = new TaskDialogButton();
            yesButton.Text = "はい";
            yesButton.Click += (sender, e) => dlg.Close(TaskDialogResult.Yes);
            dlg.Controls.Add(yesButton);

            var noButton = new TaskDialogButton();
            noButton.Text = "いいえ";
            noButton.Default = true;
            noButton.Click += (sender, e) => dlg.Close(TaskDialogResult.No);
            dlg.Controls.Add(noButton);

            // メッセージ本文
            dlg.Text = messageID;

            return dlg.Show();
        }

        /// <summary>
        /// ファイル選択ダイアログを表示します。
        /// </summary>
        /// <returns>選択ファイル名</returns>
        public string ShowOpenFile()
        {
            string result = string.Empty;

            // ファイル選択ダイアログ生成
            CommonOpenFileDialog dlg = new CommonOpenFileDialog("ファイルを開く");
            dlg.Filters.Add(new CommonFileDialogFilter("Excelファイル", "*.xlsx;*.xlsm"));
            dlg.DefaultExtension = "xlsx";
            //dlg.InitialDirectory = "";

            // ダイアログ表示
            if(dlg.ShowDialog() == CommonFileDialogResult.Ok)
            {
                result = dlg.FileName;
            }

            return result;
        }

        public void taskDialog_Opened(object sender, EventArgs e)
        {
            TaskDialog taskDialog = sender as TaskDialog;
            taskDialog.Icon = taskDialog.Icon;
            taskDialog.InstructionText = taskDialog.InstructionText;
        }
    }

    public class TestDialogService : IDialogService
    {
        private int resultCnt = 0;

        public List<TaskDialogResult> DialogResults { get; set; }

        public TestDialogService()
        {
            DialogResults = new List<TaskDialogResult>();
        }

        public TaskDialogResult ShowInformation(string messageID, params string[] parameter)
        {
            TaskDialogResult result = GetResult();

            Console.WriteLine($"Message:{messageID}, Resut:{result}");

            return result;
        }

        public TaskDialogResult ShowWarning(string messageID, params string[] parameter)
        {
            return ShowInformation(messageID, parameter);
        }

        public TaskDialogResult ShowError(Exception ex)
        {
            TaskDialogResult result = GetResult();

            Console.WriteLine($"Message:予期せぬエラーが発生しました。, Resut:{result}");
            Console.WriteLine($"Detail:{ex.StackTrace}");

            return result;
        }

        public TaskDialogResult ShowConfirm(string messageID, params string[] parameter)
        {
            return ShowInformation(messageID, parameter);
        }

        public TaskDialogResult ShowWarningConfirm(string messageID, params string[] parameter)
        {
            return ShowInformation(messageID, parameter);
        }


        private TaskDialogResult GetResult()
        {
            TaskDialogResult result = TaskDialogResult.Ok;

            if(DialogResults != null && DialogResults.Count > resultCnt)
            {
                result = DialogResults[resultCnt++];
            }

            return result;
        }
    }
}
