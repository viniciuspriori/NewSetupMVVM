using System.Collections.Generic;

namespace MVVMEssentials.Services
{
    public class CompositeNavigationService : INavigationService<object>
    {
        private readonly IEnumerable<INavigationService<object>> _navigationServices;

        public CompositeNavigationService(params INavigationService<object>[] navigationServices)
        {
            _navigationServices = navigationServices;
        }

        public void Navigate(object o)
        {
            foreach (INavigationService<object> navigationService in _navigationServices)
            {
                navigationService.Navigate(o);
            }
        }
    }
}
