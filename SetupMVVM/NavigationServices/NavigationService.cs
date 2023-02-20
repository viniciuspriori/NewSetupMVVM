
using SetupMVVM.Stores;
using SetupMVVM.ViewModels;

namespace SetupMVVM.Services
{
    public class NavigationService<TViewModel> : INavigationService where TViewModel : ViewModelBase
    {
        private readonly INavigationStore _navigationStore;
        private readonly CreateViewModel<TViewModel> _createViewModel;

        public NavigationService(INavigationStore navigationStore, CreateViewModel<TViewModel> createViewModel)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
        }

        public void Navigate(string windowName = null)
        {
            _navigationStore.CurrentViewModel = _createViewModel();
        }
    }
}
