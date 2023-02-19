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
        private readonly INavigationService<object> windowNavigationService;
        string windowName = string.Empty;

        public WindowNavigateCommand(INavigationService<object> windowNavigationService, string windowUserWants)
        {
            this.windowNavigationService = windowNavigationService;
            windowName = windowUserWants;
        }

        public override void Execute(object parameter)
        {
            windowNavigationService.Navigate(windowName);
        }
    }
}
