using MVVMEssentials.Stores;
using MVVMEssentials.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using NavigationSetup.Helpers;
using System.Reflection;

namespace SetupMVVM.Stores
{
    public class WindowNavigationStore : INavigationStore
    {
        private ViewModelBase _currentViewModel;
        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel?.Dispose();
                _currentViewModel = value;
                OnCurrentViewModelChanged();
            }
        }

        public Assembly Assembly { get; }

        public WindowNavigationStore(Assembly applicationAssembly)
        {
            Assembly = applicationAssembly;
        }

        public string WindowName { get; set; } = "";

        public bool IsOpen() 
        {
            //if(CurrentViewModel != null && WindowHelpers.IsWindowOpen<Window>(WindowName))
            if (WindowHelpers.IsWindowOpen<Window>(WindowName))
                return true;

            return false;
        }

        public event Action CurrentViewModelChanged;

        public void Close()
        {
            CurrentViewModel = null;
        }

        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }

        public void PrepareWindow(ViewModelBase viewModel)
        {
            CurrentViewModel = viewModel;
        }
    }
}
