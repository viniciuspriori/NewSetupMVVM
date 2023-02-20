using MVVMEssentials.Commands;
using MVVMEssentials.Services;
using MVVMEssentials.ViewModels;
using NewSetupMVVM.Commands;
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
        public ICommand OCU2OW1OW2 { get; set; }
        public ICommand OW1 { get; set; }
        public ICommand OUC2 { get; set; }

        public UC1VM(INavigationService goW1, ICompositeWindowNavigationService openUC2thenOpenWindow1, INavigationService goUC2)
        {
            OW1 = new NavigateCommand(goW1, "Window1");

            //here we pass null because its not a window so the service navigates to the specific user control or modal service created in App.xaml
            //the current flow is: User control 2 => Window 1 => Window 2
            //this is used only for composite navigation with multiple windows opening sequentially
            var navigationFlow = new string[] { null, "Window1", "Window2" };

            OCU2OW1OW2 = new CompositeWindowNavigateCommand(openUC2thenOpenWindow1, navigationFlow);

            OUC2 = new NavigateCommand(goUC2);
        }

    }
}
