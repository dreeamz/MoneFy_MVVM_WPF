using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using MoneFy_MVVM_WPF.Enums;
using MoneFy_MVVM_WPF.Model;
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
        private readonly INavigationService NavigationService;
        private readonly ITransactionService TransactionService;
        private Transaction transaction;

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
        public TransferViewModel(INavigationService NS,ITransactionService TS,Transaction T)
        {
            NavigationService = NS;
            TransactionService = TS;
            transaction = T;
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

        private RelayCommand _accept;
        public RelayCommand Accept
        {
            get => _accept ??= new(delegate 
            {
                transaction.Summ = double.Parse(Money);
                Money = "";
                TransactionService.Transact(transaction,AccToken.Add);                
                NavigationService.NavigateTo<HomeViewModel>(NavToken.Main);                
            });
        }

        private RelayCommand _toHome;
        public RelayCommand ToHome
        {
            get => _toHome ??= new RelayCommand(() =>
            {
                if (Money != null)
                    Money = "";
                NavigationService.NavigateTo<HomeViewModel>(NavToken.Main);

            });
        }
        #endregion
    }
}
