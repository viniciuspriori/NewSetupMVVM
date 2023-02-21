using Microsoft.Extensions.DependencyInjection;
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
        private readonly IServiceProvider _serviceProvider;

        public App()
        {
            IServiceCollection services = new ServiceCollection();

            //STORES
            services.AddSingleton<NavigationStore>();
            services.AddSingleton<ModalNavigationStore>();
            services.AddSingleton<Assembly>(Assembly.GetExecutingAssembly());
            services.AddSingleton<WindowNavigationStore>();

            //FIRST VIEW
            services.AddSingleton<INavigationService>(s => CreateUC1Nav(s));

            //VIEW MODELS
            services.AddSingleton<UC1VM>(s => new UC1VM(CreateW1Nav(s), CreateGoUC2ThenGoToW1NavThenGoToW2(s), CreateUC2Nav(s)));
            services.AddTransient<UC2VM>(s => new UC2VM(CreateUC1Nav(s)));
            services.AddTransient<Window2VM>(s => new Window2VM(CreateUC2Nav(s)));
            services.AddTransient<MyModalViewModel>(s => new MyModalViewModel(CreateCloseModalThenGoToUC1Nav(s)));
            services.AddTransient<Window1VM>(s => new Window1VM(CreateW2Nav(s), CreateModalNav(s), CreateCloseModalThenGoToUC1Nav(s)));

            //MAIN WINDOW AND MAINVIEWMODEL
            services.AddSingleton<MainWindow>(s => new MainWindow()
            {
                DataContext = s.GetRequiredService<MainViewModel>()
            });

            services.AddSingleton<MainViewModel>();

            _serviceProvider = services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            INavigationService navigationService = _serviceProvider.GetRequiredService<INavigationService>();
            navigationService.Navigate();

            MainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            MainWindow.Show();
            MainWindow.Show();

            base.OnStartup(e);
        }

        private INavigationService CreateUC1Nav(IServiceProvider s) => new NavigationService<UC1VM>(s.GetRequiredService<NavigationStore>(), 
                                                                                                    () => s.GetRequiredService<UC1VM>());

        //MANDRAKE!: Opening to windows together doesn't work quite nice in CompositeNavigationService
        //NOT recommended!
        private ICompositeWindowNavigationService CreateGoUC2ThenGoToW1NavThenGoToW2(IServiceProvider s)
        {
            return new CompositeNavigationService(CreateUC2Nav(s), CreateW1Nav(s), CreateW2Nav(s));
        }

        private INavigationService CreateW1Nav(IServiceProvider s)
        {
            return new WindowNavigationService<Window1VM>(s.GetRequiredService<WindowNavigationStore>(), () => s.GetRequiredService<Window1VM>());
        }

        private INavigationService CreateCloseModalThenGoToUC1Nav(IServiceProvider s)
        {
            return new CompositeNavigationService(CreateCloseModalNav(s), CreateUC1Nav(s));
        }

        private INavigationService CreateModalNav(IServiceProvider s)
        {
            return new NavigationService<MyModalViewModel>(s.GetRequiredService<ModalNavigationStore>(), () => s.GetRequiredService<MyModalViewModel>());
        }

        private INavigationService CreateCloseModalNav(IServiceProvider s)
        {
            return new CloseModalNavigationService(s.GetRequiredService<ModalNavigationStore>());
        }

        private INavigationService CreateW2Nav(IServiceProvider s)
        {
            return new WindowNavigationService<Window2VM>(s.GetRequiredService<WindowNavigationStore>(), () => s.GetRequiredService<Window2VM>());
        }

        private INavigationService CreateUC2Nav(IServiceProvider s)
        {
            return new NavigationService<UC2VM>(s.GetRequiredService<NavigationStore>(), () => s.GetRequiredService<UC2VM>());

            //return new NavigationService<UC2VM>(s.GetRequiredService<NavigationStore>(), () => new UC2VM(CreateUC1Nav(s)));
        }
    }
}
