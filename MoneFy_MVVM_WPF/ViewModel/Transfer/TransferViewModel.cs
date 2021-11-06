using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using MoneFy_MVVM_WPF.Services;
using MoneFy_MVVM_WPF.ViewModel.Home;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MoneFy_MVVM_WPF.ViewModel.Transfer
{
    public class TransferViewModel : ViewModelBase
    {
        #region Prop and fields
        private INavigationService NavigationService;

        string _money;
        public string Money
        {
            get => _money;
            set
            {
                Set(ref _money, value);
                MoneyChange();
            }
        }

        bool _acptButEnab;
        public bool AcptButEnab
        {
            get => _acptButEnab;
            set
            {
                Set(ref _acptButEnab, value);
            }
        }
        #endregion
        public TransferViewModel(INavigationService NS)
        {
            NavigationService = NS;
        }

        //Function to Enable Accept button
        public void MoneyChange()
        {

            if (_money != null && _money != "")
            {
                if (double.Parse(_money) > 0)
                    AcptButEnab = true;
            }
            else
                AcptButEnab = false;
        }

        #region Commands

        private RelayCommand _putMoney;
        public RelayCommand PutMoney
        {
            get => _putMoney ??= new(delegate 
            { 
                
            });
        }

        private RelayCommand _toHome;
        public RelayCommand ToHome
        {
            get => _toHome ??= new RelayCommand(() =>
            {
                NavigationService.NavigateTo<HomeViewModel>(Enums.Token.Main);
            });
        }
        #endregion
    }
}
