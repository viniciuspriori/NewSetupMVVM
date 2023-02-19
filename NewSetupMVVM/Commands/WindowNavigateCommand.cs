using MVVMEssentials.Commands;
using MVVMEssentials.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetupMVVM.Commands
{
    public class WindowNavigateCommand : CommandBase
    {
        private readonly INavigationService windowNavigationService;

        public WindowNavigateCommand(INavigationService windowNavigationService)
        {
            this.windowNavigationService = windowNavigationService;
        }

        public override void Execute(object parameter)
        {
            windowNavigationService.Navigate();
        }
    }
}
