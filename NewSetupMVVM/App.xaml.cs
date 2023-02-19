using MVVMEssentials.Services;
using MVVMEssentials.Stores;
using MVVMEssentials.ViewModels;
using NewSetupMVVM.ViewModels;
using NewSetupMVVM.ViewModels.ModalViewModel;
using SetupMVVM.NavigationServices;
using SetupMVVM.Stores;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;

namespace NewSetupMVVM
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>

    public partial class App : Application
    {
        private readonly NavigationStore _navigationStore;
        private readonly ModalNavigationStore _modalNavigationStore;
        private readonly WindowNavigationStore _windowNavigationStore;

        public App()
        {
            _navigationStore = new NavigationStore();
            _modalNavigationStore = new ModalNavigationStore();
            _windowNavigationStore = new WindowNavigationStore(Assembly.GetExecutingAssembly());
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            INavigationService navigationService = CreateUC1Nav();
            navigationService.Navigate();

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore, _modalNavigationStore)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }

        private INavigationService CreateUC1Nav() => new NavigationService<UC1VM>(_navigationStore, UC1VM);
        private UC1VM UC1VM() => new UC1VM(CreateW1Nav());


        private INavigationService CreateW1Nav()
        {
            return new WindowNavigationService<Window1VM>(_windowNavigationStore, W1VM);
        }

        private Window1VM W1VM()
        {
           return new Window1VM(CreateW2Nav(), CreateModalNav(), CreateCloseModalThenGoToUC1Nav());
        }

        private INavigationService CreateCloseModalThenGoToUC1Nav()
        {
            return new CompositeNavigationService(CreateCloseModalNav(), CreateUC1Nav());
        }

        private INavigationService CreateModalNav()
        {

            return new NavigationService<MyModalViewModel>(_modalNavigationStore, () => new MyModalViewModel(CreateCloseModalThenGoToUC1Nav()));
        }

        private INavigationService CreateCloseModalNav()
        {
            return new CloseModalNavigationService(_modalNavigationStore);
        }

        private INavigationService CreateW2Nav()
        {
            return new WindowNavigationService<Window2VM>(_windowNavigationStore, W2VM);
        }

        private Window2VM W2VM() => new Window2VM(CreateUC2Nav());

        private INavigationService CreateUC2Nav()
        {
            return new NavigationService<UC2VM>(_navigationStore, () => new UC2VM(CreateUC1Nav()));
        }
    }
}
