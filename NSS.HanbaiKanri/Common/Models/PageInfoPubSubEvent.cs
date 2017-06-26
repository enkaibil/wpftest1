using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSS.HanbaiKanri.Common.Models
{
    class PageInfoPubSubEvent : PubSubEvent<BaseViewModel>
    {
        public static void Publish(IEventAggregator eventAggregator, BaseViewModel payload)
        {
            eventAggregator
                .GetEvent<PageInfoPubSubEvent>()
                .Publish(payload);
        }

        public static SubscriptionToken Subscribe(IEventAggregator eventAggregator, Action<BaseViewModel> kickMethod)
        {
            return eventAggregator
                .GetEvent<PageInfoPubSubEvent>()
                .Subscribe(kickMethod, ThreadOption.UIThread);
        }

        public static void UnSubscribe(SubscriptionToken token)
        {
            if (token != null)
            {
                token.Dispose();
                token = null;
            }
        }
    }
}
