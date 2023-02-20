using SetupMVVM.ViewModels;
using System;
using System.Reflection;

namespace SetupMVVM.Stores
{
    public class WindowNavigationStore : INavigationStore
    {
        private ViewModelBase? _currentViewModel;
        public ViewModelBase? CurrentViewModel
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

        public event Action? CurrentViewModelChanged;

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
