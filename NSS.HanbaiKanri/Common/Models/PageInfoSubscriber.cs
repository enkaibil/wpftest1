using Microsoft.Practices.Unity;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSS.HanbaiKanri.Common.Models
{
    public class PageInfoSubscriber : BindableBase
    {
        public void Subscribe(IEventAggregator eventAggregator, Action<BaseViewModel> kickMethod)
        {
            eventAggregator
                .GetEvent<PageInfoPubSubEvent>()
                .Subscribe(kickMethod, ThreadOption.UIThread);
        }
    }
}
