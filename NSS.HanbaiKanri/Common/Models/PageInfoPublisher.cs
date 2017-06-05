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
    public class PageInfoPublisher : BindableBase
    {
        public void Publish(IEventAggregator eventAggregator, BaseViewModel me)
        {
            eventAggregator
                .GetEvent<PageInfoPubSubEvent>()
                .Publish(me);
        }
    }
}
