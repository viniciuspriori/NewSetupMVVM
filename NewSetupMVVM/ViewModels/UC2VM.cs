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
    public class UC2VM : ViewModelBase  
    {
        public ICommand OUC1 { get; }

        public UC2VM(INavigationService<object> backUC1)
        {
            OUC1 = new NavigateCommand(backUC1);
        }
    }
}
