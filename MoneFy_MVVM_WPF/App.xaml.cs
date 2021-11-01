using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using MoneFy_MVVM_WPF.Services;
using MoneFy_MVVM_WPF.View;
using MoneFy_MVVM_WPF.ViewModel;
using MoneFy_MVVM_WPF.ViewModel.Home;
using MoneFy_MVVM_WPF.ViewModel.Transfer;
using SimpleInjector;
using System;
using System.Collections.Generic;

using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MoneFy_MVVM_WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Container Container { get; private set; }
        protected override void OnStartup(StartupEventArgs e)
        {
            Register();
            Start<HomeViewModel>();
            base.OnStartup(e);
        }

        private void Register()
        {
            Container = new Container();

            Container.RegisterSingleton<INavigationService, NavigationService>();
            Container.RegisterSingleton<IMessenger, Messenger>();


            Container.RegisterSingleton<MainViewModel>();
            Container.RegisterSingleton<HomeViewModel>();
            Container.RegisterSingleton<TransferViewModel>();
            Container.RegisterSingleton<AppBarViewModel>();
            Container.RegisterSingleton<FilterSideBarViewModel>();
            Container.RegisterSingleton<OptionSideBarViewModel>();
        }   
        private void Start<T>()where T : ViewModelBase
        {
            MainViewModel viewModel = Container.GetInstance<MainViewModel>();
            viewModel.CurrentView = Container.GetInstance<T>();
            MainView mainView = new();
            mainView.DataContext = viewModel;
            mainView.Show();
        }

    }
}
