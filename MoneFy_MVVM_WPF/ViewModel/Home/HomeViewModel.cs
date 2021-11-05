using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using MoneFy_MVVM_WPF.Enums;
using MoneFy_MVVM_WPF.Messages;
using MoneFy_MVVM_WPF.Services;
using MoneFy_MVVM_WPF.View.Home;
using MoneFy_MVVM_WPF.ViewModel.Transfer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneFy_MVVM_WPF.ViewModel.Home
{
    public class HomeViewModel : ViewModelBase
    {
        private readonly INavigationService NavigationService;
        private readonly IMessenger messenger;

        public string Balance { get; set; } = "Balance:";

        //Bar on top
        public ViewModelBase AppBar { get=> App.Container.GetInstance<AppBarViewModel>(); } 
        public SeriesCollection SeriesCollection { get; set; }
        public HomeViewModel(INavigationService NS, IMessenger ms)
        {
            NavigationService = NS;
            ms.Register<NavigationMessage>(this, Token.LeftSideBar, message =>
            {
                ViewModelBase viewModel = App.Container.GetInstance(message.ViewModelBase) as ViewModelBase;
                if (_leftBar)
                {
                    LeftSideBar = viewModel;
                    _leftBar = false;
                }
                else
                {
                    LeftSideBar = null;
                    _leftBar = true;
                }
            });
            ms.Register<NavigationMessage>(this, Token.RightSideBar, message =>
            {
                ViewModelBase viewModel = App.Container.GetInstance(message.ViewModelBase) as ViewModelBase;
                if (_rightBar)
                {
                    RightSideBar = viewModel;
                    _rightBar = false;
                }
                else
                {
                    RightSideBar = null;
                    _rightBar = true;
                }
            });

            SeriesCollection = new SeriesCollection() {
               new PieSeries()
               {
                   Title = "Transport",
                   Values = new ChartValues<ObservableValue>() { new ObservableValue(50) },
                   DataLabels = true
               },
               new PieSeries()
               {
                   Title = "Sport",
                   Values = new ChartValues<ObservableValue>() { new ObservableValue(40) },
                   DataLabels = true
               },
               new PieSeries()
               {
                   Title = "Food",
                   Values = new ChartValues<ObservableValue>() { new ObservableValue(70) },
                   DataLabels = true
               },
               new PieSeries()
               {
                   Title = "Hangout",
                   Values = new ChartValues<ObservableValue>() { new ObservableValue(30) },
                   DataLabels = true
               }
            };
        }


        #region commands

        private RelayCommand _toTransfer;
        public RelayCommand ToTransfer
        {
            get => _toTransfer ??= new RelayCommand(() =>
            {
                NavigationService.NavigateTo<TransferViewModel>(Token.Main);
            });
        }

        private ViewModelBase _leftSideBar;
        public ViewModelBase LeftSideBar
        {
            get => _leftSideBar;
            set => Set(ref _leftSideBar, value);
        }


        private ViewModelBase _rightSideBar;
        public ViewModelBase RightSideBar
        {
            get => _rightSideBar;
            set => Set(ref _rightSideBar, value);
        }

        public RelayCommand ToLeftSideBar
        {
            get => _toLeftSideBar ??= new RelayCommand(delegate
            {
                if (_leftBar)
                {
                    NavigationService.NavigateTo<LeftSideBarViewModel>(Token.LeftSideBar);
                    _leftBar = false;
                }
                else
                {
                    LeftSideBar = null;
                    _leftBar = true;
                }
            });
        }

        private RelayCommand _toLeftSideBar;
        bool _leftBar = true;
        bool _rightBar = true;
        public RelayCommand ToRightSideBar
        {
            get => _toLeftSideBar ??= new RelayCommand(delegate
             {
                 if (_leftBar)
                 {
                     NavigationService.NavigateTo<RightSideBarViewModel>(Token.RightSideBar);
                     _rightBar = false;
                 }
                 else
                 {
                     LeftSideBar = null;
                     _rightBar = true;
                 }
             });
        }
        #endregion
    }
}
