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
    public class Window1VM : ViewModelBase
    {
        public ICommand OW2 { get; set; }
        public ICommand OM { get; set; }
        public ICommand CMOUC1 { get; set; }


        public Window1VM(INavigationService goW2, INavigationService goModal, INavigationService closeModalGoToUC1)
        {
            OW2 = new NavigateCommand(goW2, "Window2");

            OM = new NavigateCommand(goModal);

            CMOUC1 = new NavigateCommand(closeModalGoToUC1);
        }
    }
}
