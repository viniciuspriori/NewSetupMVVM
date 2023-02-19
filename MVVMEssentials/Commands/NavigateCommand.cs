using MVVMEssentials.Services;
using System;

namespace MVVMEssentials.Commands
{
    public class NavigateCommand : CommandBase
    {
        private readonly INavigationService<object> _navigationService;

        public NavigateCommand(INavigationService<object> navigationService)
        {
            _navigationService = navigationService;
        }

        public override void Execute(object parameter)
        {
            _navigationService.Navigate(parameter);
        }
    }
}
