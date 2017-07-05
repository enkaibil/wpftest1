using NSS.HanbaiKanri.StartMenu.ViewModels;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSS.HanbaiKanri.Common.Models
{
    public class HeaderInfoModel : BindableBase
    {
        /// <summary>画面タイトル</summary>
        public string FormTitle
        {
            get { return _fromtitle; }
            set { SetProperty(ref _fromtitle, value); }
        }
        private string _fromtitle;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="eventAggregator">DIコンテナ</param>
        public HeaderInfoModel(IEventAggregator eventAggregator)
        {
            PageInfoPubSubEvent.Subscribe(eventAggregator, SetHeader);
        }

        /// <summary>
        /// ヘッダー情報を設定します。
        /// </summary>
        /// <param name="targetViewModel">対象ビューモデル</param>
        public void SetHeader(BaseViewModel targetViewModel)
        {
            FormTitle = targetViewModel.Title;
        }
    }
}
