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
        [Dependency]
        private IEventAggregator EventAggregator { get; set; }

        public void Publish(BaseViewModel me)
        {
            this.EventAggregator
                .GetEvent<PubSubEvent<BaseViewModel>>()
                .Publish(me);
        }
    }
}
