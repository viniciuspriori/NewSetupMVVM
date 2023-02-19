using MVVMEssentials.Services;
using MVVMEssentials.ViewModels;
using SetupMVVM.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NewSetupMVVM.ViewModels
{
    public class Window1VM : ViewModelBase
    {
        public ICommand OW2 { get; set; }
        public Window1VM(INavigationService<object> goW2)
        {
            OW2 = new WindowNavigateCommand(goW2, "Window2");
        }
    }
}
