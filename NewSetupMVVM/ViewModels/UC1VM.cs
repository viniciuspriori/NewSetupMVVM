using MVVMEssentials.Commands;
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
    public class UC1VM : ViewModelBase
    {
        public ICommand OW1 { get; set; }
        public UC1VM(INavigationService<object> goW1)
        {
            OW1 = new WindowNavigateCommand(goW1, "Window1");
        }
    }
}
