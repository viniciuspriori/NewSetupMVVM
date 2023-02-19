using MVVMEssentials.Commands;
using MVVMEssentials.Services;
using MVVMEssentials.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NewSetupMVVM.ViewModels.ModalViewModel
{
    public class MyModalViewModel : ViewModelBase
    {
        public ICommand OUC1 { get; set; }
        public MyModalViewModel(INavigationService openUC1)
        {
            OUC1 = new NavigateCommand(openUC1);
        }
    }
}
