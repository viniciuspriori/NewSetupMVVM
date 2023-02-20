using System.Collections.Generic;
using System.Diagnostics.Metrics;

namespace SetupMVVM.Services
{
    public class CompositeNavigationService : ICompositeWindowNavigationService, INavigationService
    {
        private readonly IEnumerable<INavigationService> _navigationServices;

        public CompositeNavigationService(params INavigationService[] navigationServices)
        {
            _navigationServices = navigationServices;
        }

        public void Navigate(string windowName = null)
        {
            foreach (INavigationService navigationService in _navigationServices)
            {
                navigationService.Navigate();
            }
        }

        //multiple window sequential navigation use only
        public void Navigate(params string[] windowName)
        {
            int count = 0;

            foreach (INavigationService navigationService in _navigationServices)
            {
                if (count < windowName.Length)
                {
                    navigationService.Navigate(windowName[count]);
                    count++;
                }
            }
        }
    }
}
