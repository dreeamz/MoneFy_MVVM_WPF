using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using MoneFy_MVVM_WPF.Services;
using MoneFy_MVVM_WPF.ViewModel.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneFy_MVVM_WPF.ViewModel.Transfer
{
    public class TransferViewModel : ViewModelBase
    {
        private INavigationService NavigationService;
        public TransferViewModel(INavigationService NS)
        {
            NavigationService = NS;
        }

        private RelayCommand _toHome;
        public RelayCommand ToHome
        {
            get => _toHome ??= new RelayCommand(() =>
            {
                NavigationService.NavigateTo<HomeViewModel>(Enums.Token.Main);
            });
        }
    }
}
