using SetupMVVM.Commands;
using SetupMVVM.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewSetupMVVM.Commands
{
    public class CompositeWindowNavigateCommand : CommandBase
    {
        private readonly ICompositeWindowNavigationService _navigationService;
        private string[] _windowName;

        public CompositeWindowNavigateCommand(ICompositeWindowNavigationService navigationService, params string[] windowsUserWants)
        {
            _navigationService = navigationService;
            _windowName = windowsUserWants;
        }

        public override void Execute(object parameter)
        {
            _navigationService.Navigate(_windowName);
        }
    }
}
