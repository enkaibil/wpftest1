using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSS.HanbaiKanri.Common.Models
{
    class BackButtonClickPubSubEvent : PubSubEvent
    {
        public static void Publish(IEventAggregator eventAggregator)
        {
            eventAggregator
                .GetEvent<BackButtonClickPubSubEvent>()
                .Publish();
        }

        public static void Subscribe(IEventAggregator eventAggregator, Action kickMethod)
        {
            eventAggregator
                .GetEvent<BackButtonClickPubSubEvent>()
                .Subscribe(kickMethod, ThreadOption.UIThread);
        }
    }
}
