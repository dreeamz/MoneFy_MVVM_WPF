using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using MoneFy_MVVM_WPF.Enums;
using MoneFy_MVVM_WPF.Messages;
using MoneFy_MVVM_WPF.Services;
using MoneFy_MVVM_WPF.Services.Home;
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
        public INavigationService NavigationService;
        public IMessenger Messenger;

        public string Balance { get; set; } = "Balance:";

        #region Bars
        public ViewModelBase AppBar { get=> App.Container.GetInstance<AppBarViewModel>(); }

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
        #endregion
        public SeriesCollection SeriesCollection { get; set; }

        public HomeViewModel()
        {            
            
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


        #region Commands

        private RelayCommand _toTransfer;
        public RelayCommand ToTransfer
        {
            get => _toTransfer ??= new RelayCommand(() =>
            {
                NavigationService.NavigateTo<TransferViewModel>(Token.Main);
            });
        }  
        
        #endregion
    }
}
