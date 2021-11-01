using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using MoneFy_MVVM_WPF.Messages;
using MoneFy_MVVM_WPF.Services;
using MoneFy_MVVM_WPF.ViewModel.Transfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneFy_MVVM_WPF.ViewModel.Home
{
    public class HomeViewModel : ViewModelBase
    {
        private INavigationService NavigationService;

        public HomeViewModel(INavigationService NS)
        {
            NavigationService = NS;
        }
        private RelayCommand _toTransfer;        
        public RelayCommand ToTransfer
        {
            get => _toTransfer ??= new RelayCommand(() =>
            {
                NavigationService.NavigateTo<TransferViewModel>();
            });
        }


    }
}
