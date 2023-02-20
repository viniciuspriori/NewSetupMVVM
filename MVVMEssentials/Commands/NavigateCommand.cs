using MVVMEssentials.Services;
using System;

namespace MVVMEssentials.Commands
{
    public class NavigateCommand : CommandBase
    {
        private readonly INavigationService _navigationService;
        private string _windowName;

        public NavigateCommand(INavigationService navigationService, string windowUserWants = null)
        {
            _navigationService = navigationService;
            _windowName = windowUserWants;
        }

        public override void Execute(object parameter)
        {
            if (_windowName == null)
            {
                _navigationService.Navigate();
            } 
            else
            {
                _navigationService.Navigate(_windowName);
            }
        }
    }
}
