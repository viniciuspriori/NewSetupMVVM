using MVVMEssentials.Commands;
using MVVMEssentials.Services;
using MVVMEssentials.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NewSetupMVVM.ViewModels
{
    public class Window2VM : ViewModelBase
    {
        public ICommand OUC2 { get; set; }
        public Window2VM(INavigationService<object> gouc2main)
        {
            OUC2 = new NavigateCommand(gouc2main);
        }
    }
}
