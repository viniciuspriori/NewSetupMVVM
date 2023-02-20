using SetupMVVM.ViewModels;

namespace SetupMVVM.Stores
{
    public interface INavigationStore
    {
        ViewModelBase CurrentViewModel { set; }
    }
}