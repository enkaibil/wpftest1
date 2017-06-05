using NSS.HanbaiKanri.StartMenu;
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
        public string _fromtitle;
        public string FormTitle
        {
            get { return _fromtitle; }
            set { SetProperty(ref _fromtitle, value); }
        }

        public HeaderInfoModel(IEventAggregator eventAggregator)
        {
            PageInfoPubSubEvent.Subscribe(eventAggregator, SetHeader);
        }

        public void SetHeader(BaseViewModel targetViewModel)
        {
            FormTitle = targetViewModel.Title;

            if (targetViewModel is StartMenuViewModel)
            {
            }
        }
    }
}
