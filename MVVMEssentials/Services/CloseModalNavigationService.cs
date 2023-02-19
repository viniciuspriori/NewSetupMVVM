using MVVMEssentials.Stores;

namespace MVVMEssentials.Services
{
    public class CloseModalNavigationService : INavigationService<object>
    {
        private readonly ModalNavigationStore _navigationStore;

        public CloseModalNavigationService(ModalNavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }

        public void Navigate(object o)
        {
            _navigationStore.Close();
        }
    }
}
