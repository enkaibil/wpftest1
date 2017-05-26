using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSS.HanbaiKanri.StartMenu
{
    class StartMenuViewModel : BindableBase
    {
        public DelegateCommand btnMMEmpClick_Cmd { get; set; }

        public StartMenuViewModel()
        {
            btnMMEmpClick_Cmd = new DelegateCommand(bntMMEmpClick);
        }

        private void bntMMEmpClick()
        {
        }
    }
}
