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
        MessageBoxResult ShowInformation(string messageID, params string[] parameter);

        MessageBoxResult ShowConfirm(string messageID, params string[] parameter);
    }

    public class DialogService : IDialogService
    {
        public MessageBoxResult ShowConfirm(string messageID, params string[] parameter)
        {
            return MessageBox.Show("");
        }

        public MessageBoxResult ShowInformation(string messageID, params string[] parameter)
        {
            return MessageBox.Show(messageID, "Information", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK);
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

        public MessageBoxResult ShowConfirm(string messageID, params string[] parameter)
        {
            return ShowInformation(messageID, parameter);
        }

        public MessageBoxResult ShowInformation(string messageID, params string[] parameter)
        {
            MessageBoxResult result = GetResult();

            Console.WriteLine($"Message:{messageID}, Resut:{result}");

            return result;
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
