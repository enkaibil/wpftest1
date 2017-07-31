using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NSS.HanbaiKanri.Common.Models
{
    public interface IDialogService
    {
        /// <summary>
        /// インフォメーションメッセージダイアログを表示します。
        /// </summary>
        /// <param name="messageID">メッセージID</param>
        /// <param name="parameter">メッセージパラメータ</param>
        /// <returns>ダイアログ結果</returns>
        MessageBoxResult ShowInformation(string messageID, params string[] parameter);

        /// <summary>
        /// ワーニングメッセージを表示します。
        /// </summary>
        /// <param name="messageID">メッセージID</param>
        /// <param name="parameter">メッセージパラメータ</param>
        /// <returns>ダイアログ結果</returns>
        MessageBoxResult ShowWarning(string messageID, params string[] parameter);

        /// <summary>
        /// エラーメッセージを表示します。
        /// </summary>
        /// <param name="messageID">メッセージID</param>
        /// <param name="parameter">メッセージパラメータ</param>
        /// <returns>ダイアログ結果</returns>
        MessageBoxResult ShowError(string messageID, params string[] parameter);

        /// <summary>
        /// 確認メッセージを表示します。
        /// </summary>
        /// <param name="messageID">メッセージID</param>
        /// <param name="parameter">メッセージパラメータ</param>
        /// <returns>ダイアログ結果</returns>
        MessageBoxResult ShowConfirm(string messageID, params string[] parameter);

        /// <summary>
        /// 警告確認メッセージを表示します。
        /// </summary>
        /// <param name="messageID">メッセージID</param>
        /// <param name="parameter">メッセージパラメータ</param>
        /// <returns>ダイアログ結果</returns>
        MessageBoxResult ShowWarningConfirm(string messageID, params string[] parameter);
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
        public MessageBoxResult ShowInformation(string messageID, params string[] parameter)
        {
            return MessageBox.Show(messageID, nameof(MessageBoxImage.Information), MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK);
        }

        /// <summary>
        /// ワーニングメッセージを表示します。
        /// </summary>
        /// <param name="messageID">メッセージID</param>
        /// <param name="parameter">メッセージパラメータ</param>
        /// <returns>ダイアログ結果</returns>
        public MessageBoxResult ShowWarning(string messageID, params string[] parameter)
        {
            return MessageBox.Show(messageID, nameof(MessageBoxImage.Warning), MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK);
        }

        /// <summary>
        /// エラーメッセージを表示します。
        /// </summary>
        /// <param name="messageID">メッセージID</param>
        /// <param name="parameter">メッセージパラメータ</param>
        /// <returns>ダイアログ結果</returns>
        public MessageBoxResult ShowError(string messageID, params string[] parameter)
        {
            return MessageBox.Show(messageID, nameof(MessageBoxImage.Error), MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
        }

        /// <summary>
        /// 確認メッセージを表示します。
        /// </summary>
        /// <param name="messageID">メッセージID</param>
        /// <param name="parameter">メッセージパラメータ</param>
        /// <returns>ダイアログ結果</returns>
        public MessageBoxResult ShowConfirm(string messageID, params string[] parameter)
        {
            return MessageBox.Show(messageID, nameof(MessageBoxImage.Question), MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.Yes);
        }

        /// <summary>
        /// 警告確認メッセージを表示します。
        /// </summary>
        /// <param name="messageID">メッセージID</param>
        /// <param name="parameter">メッセージパラメータ</param>
        /// <returns>ダイアログ結果</returns>
        public MessageBoxResult ShowWarningConfirm(string messageID, params string[] parameter)
        {
            return MessageBox.Show(messageID, nameof(MessageBoxImage.Warning), MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.No);
        }
    }

    public class TestDialogService : IDialogService
    {
        private int resultCnt = 0;

        public List<MessageBoxResult> DialogResults { get; set; }

        public TestDialogService()
        {
            DialogResults = new List<MessageBoxResult>();
        }

        public MessageBoxResult ShowInformation(string messageID, params string[] parameter)
        {
            MessageBoxResult result = GetResult();

            Console.WriteLine($"Message:{messageID}, Resut:{result}");

            return result;
        }

        public MessageBoxResult ShowWarning(string messageID, params string[] parameter)
        {
            return ShowInformation(messageID, parameter);
        }

        public MessageBoxResult ShowError(string messageID, params string[] parameter)
        {
            return ShowInformation(messageID, parameter);
        }

        public MessageBoxResult ShowConfirm(string messageID, params string[] parameter)
        {
            return ShowInformation(messageID, parameter);
        }

        public MessageBoxResult ShowWarningConfirm(string messageID, params string[] parameter)
        {
            return ShowInformation(messageID, parameter);
        }


        private MessageBoxResult GetResult()
        {
            MessageBoxResult result = MessageBoxResult.OK;

            if(DialogResults != null && DialogResults.Count > resultCnt)
            {
                result = DialogResults[resultCnt];
            }

            return result;
        }
    }
}
