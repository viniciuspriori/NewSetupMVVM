using MVVMEssentials.Stores;

namespace MVVMEssentials.Services
{
    public class CloseModalNavigationService : INavigationService
    {
        private readonly ModalNavigationStore _navigationStore;

        public CloseModalNavigationService(ModalNavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }

        public void Navigate(string windowName = null)
        {
            _navigationStore.Close();
        }
    }
}
