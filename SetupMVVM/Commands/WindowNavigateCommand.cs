using SetupMVVM.Services;

namespace SetupMVVM.Commands
{
    public class WindowNavigateCommand : CommandBase
    {
        private readonly INavigationService windowNavigationService;
        string windowName = string.Empty;

        public WindowNavigateCommand(INavigationService windowNavigationService, string windowUserWants)
        {
            this.windowNavigationService = windowNavigationService;
            windowName = windowUserWants;
        }

        public override bool CanExecute(object parameter)
        {
            return windowName != string.Empty && windowName != null;
        }

        public override void Execute(object parameter)
        {
            windowNavigationService.Navigate(windowName);
        }
    }
}
