using MVVMEssentials.Services;
using MVVMEssentials.Stores;
using MVVMEssentials.ViewModels;
using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using NavigationSetup.Helpers;
using System.IO;
using System.Reflection;
using System.Windows.Shapes;
using System.Collections;
using System.Resources;
using SetupMVVM.Stores;

namespace SetupMVVM.NavigationServices
{
    public class WindowNavigationService<T> : INavigationService where T : ViewModelBase
    {
        private readonly WindowNavigationStore _windowNavigationStore;

        private readonly CreateViewModel<T> _createViewModel;

        public WindowNavigationService(WindowNavigationStore windowStore, CreateViewModel<T> createViewModel)
        {
            _windowNavigationStore = windowStore;
            _createViewModel = createViewModel;
        }

        public void Navigate(string windowName)
        {
            //if (!_windowNavigationStore.IsOpen()) //opens only a single time
            //{
            _windowNavigationStore.PrepareWindow(_createViewModel());
            Show((string)windowName);
            //}
        }

        private void Show(string userGivenWindowName)
        {
            bool foundWindow;
            string path;

            GetWindows(out foundWindow, out path, userGivenWindowName);

            //var isOpen = _windowNavigationStore.IsOpen();

            if (foundWindow)
            {
                OpenDialog(path);
            }
            else
            {
                throw new Exception("Window not found.");
            }
        }

        private void OpenDialog(string path)
        {
            var uri = new Uri(@$"\..\..\..\{path}", UriKind.RelativeOrAbsolute);
            var window = (Window)Application.LoadComponent(uri);
            window.DataContext = _windowNavigationStore.CurrentViewModel;
            window.ShowDialog(); //prevents user from clicking in the background window
        }

        private void GetWindows(out bool foundWindow, out string path, string userGivenWindowName)
        {
            foundWindow = false;
            path = "";

            var windowList = WindowHelpers.GetWindowList(_windowNavigationStore.Assembly);

            if (windowList != null)
            {
                foreach (var item in windowList)
                {
                    if (item.ToLower().Contains(userGivenWindowName.ToLower()))
                    {
                        foundWindow = true;
                        path = item;
                    }
                }
            }
        }
    }
    
}
