using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSS.HanbaiKanri.Common.Models
{
    public class BackButtonClickPubSubEvent : PubSubEvent
    {
        public static void Publish(IEventAggregator eventAggregator)
        {
            eventAggregator
                .GetEvent<BackButtonClickPubSubEvent>()
                .Publish();
        }

        public static SubscriptionToken Subscribe(IEventAggregator eventAggregator, Action kickMethod)
        {
             return eventAggregator
                .GetEvent<BackButtonClickPubSubEvent>()
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
