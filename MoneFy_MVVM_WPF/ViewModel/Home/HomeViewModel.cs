using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using MoneFy_MVVM_WPF.Enums;
using MoneFy_MVVM_WPF.Messages;
using MoneFy_MVVM_WPF.Model;
using MoneFy_MVVM_WPF.Services;
using MoneFy_MVVM_WPF.Services.Home;
using MoneFy_MVVM_WPF.View.Home;
using MoneFy_MVVM_WPF.ViewModel.Transfer;
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Color = System.Drawing.Color;

namespace MoneFy_MVVM_WPF.ViewModel.Home
{
    public class HomeViewModel : ViewModelBase
    {
        #region Fields and Properties

        public INavigationService NavigationService;
        public IMessenger Messenger;
        public IAccountingService accountingService;

        public Wallet wallet;
        public Transaction transaction;



        public SeriesCollection SeriesCollection { get; set; }

        private string _exepence = "0";
        public string Expenses
        {
            get => $"{_exepence} $";
            set
            {
                Set(ref _exepence, value);
            }
        }
        private string _balance = "0";
        public string Balance
        {
            get => $"{_balance} $";
            set
            {
                Set(ref _balance, value);
            }
        }

        #region Bars
        public ViewModelBase AppBar { get => App.Container.GetInstance<AppBarViewModel>(); }

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

        #endregion

        public HomeViewModel()
        {
            SeriesCollection = new SeriesCollection() {
               new PieSeries()
               {
                   FontSize=15,
                   Title = "Transport",
                    Fill= new SolidColorBrush(System.Windows.Media.Color.FromRgb(72, 61, 91)),
                   Values = new ChartValues<ObservableValue>() { new ObservableValue(50) },
                   DataLabels = true
               },
               new PieSeries()
               {
                   FontSize=15,
                   Title = "Sport",
                    Fill= new SolidColorBrush(System.Windows.Media.Color.FromRgb(0, 0, 0)),
                   Values = new ChartValues<ObservableValue>() { new ObservableValue(40) },
                   DataLabels = true
               },
               new PieSeries()
               {
                   FontSize=15,
                   Title = "Food",
                    Fill= new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 214, 107, 1)),
                   Values = new ChartValues<ObservableValue>() { new ObservableValue(70) },
                   DataLabels = true
               },
               new PieSeries()
               {
                   FontSize=15,
                   Title = "Hangout",
                    Fill= new SolidColorBrush(System.Windows.Media.Color.FromRgb(225,26,25)),
                   Values = new ChartValues<ObservableValue>() { new ObservableValue(30) },
                   DataLabels = true
               },
               new PieSeries()
               {
                   FontSize=15,
                   Title = "Aptek",
                    Fill= new SolidColorBrush(System.Windows.Media.Color.FromRgb(0,193,149)),
                   Values = new ChartValues<ObservableValue>() { new ObservableValue(30) },
                   DataLabels = true
               },
               new PieSeries()
               {
                   FontSize=15,
                    Fill= new SolidColorBrush(System.Windows.Media.Color.FromRgb(0,181,199)),
                   Title = "CellPhone",
                   Values = new ChartValues<ObservableValue>() { new ObservableValue(30) },
                   DataLabels = true
               },
               new PieSeries()
               {
                   FontSize=15,
                    Fill= new SolidColorBrush(System.Windows.Media.Color.FromRgb(202, 59, 255)),
                   Title = "Dress",
                   Values = new ChartValues<ObservableValue>() { new ObservableValue(90) },
                   DataLabels = true
               },
               new PieSeries()
               {
                  FontSize=15,
                    Fill= new SolidColorBrush(System.Windows.Media.Color.FromRgb(22, 36, 83)),
                  Title = "Pets",
                  Values = new ChartValues<ObservableValue>() { new ObservableValue(101) },
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
                NavigationService.NavigateTo<TransferViewModel>(NavToken.Main);
            });
        }

        private RelayCommand _toSubstract;
        public RelayCommand ToSubstract
        {
            get => _toSubstract ??= new RelayCommand(
                delegate
                {
                    NavigationService.NavigateTo<SubstractViewModel>(NavToken.Main);
                });
        }

        #endregion


    }
}
