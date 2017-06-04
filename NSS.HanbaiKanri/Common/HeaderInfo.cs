using Microsoft.Practices.Unity;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSS.HanbaiKanri.Common
{
    public class HeaderInfoPublisher
    {
        [Dependency]
        private IEventAggregator EventAggregator { get; set; }

        public void Publish(BaseViewModel curViewModel)
        {
            this.EventAggregator
                .GetEvent<PubSubEvent<BaseViewModel>>()
                .Publish(curViewModel);
        }
    }

    public class HeaderInfoSubscriber
    {
        [Dependency]
        private IEventAggregator EventAggregator { get; set; }


    }
}
