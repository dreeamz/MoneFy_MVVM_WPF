using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using MoneFy_MVVM_WPF.Enums;
using MoneFy_MVVM_WPF.Messages;
using MoneFy_MVVM_WPF.Model;
using MoneFy_MVVM_WPF.Services;
using MoneFy_MVVM_WPF.ViewModel.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MoneFy_MVVM_WPF.ViewModel.Transfer
{
    public class CategoryViewModel : ViewModelBase
    {
        private readonly IMessenger messenger;
        private readonly INavigationService navigationService;
        private readonly ITransactionService transactionService;
        private readonly IPieChartService pieChartService;

        private Transaction transaction = App.Container.GetInstance<Transaction>();
        
        public CategoryViewModel(IMessenger M, INavigationService NS, ITransactionService TS,IPieChartService PS)
        {
            messenger = M;
            navigationService = NS;
            transactionService = TS;
            pieChartService = PS;
            messenger.Register<TransactionMessage>(this, AccToken.Category, messenger =>
                transaction.Summ = messenger.Transaction.Summ
            ); 
        }

        #region Commands

        private RelayCommand<string> _accept;
        public RelayCommand<string> Accept
        {
            get => _accept ??= new RelayCommand<string>(Execute);
        }
        private void Execute(string category)
        {
            pieChartService.ChangeCollectonItem(category, transaction);
            transactionService.Transact(transaction, AccToken.Substract);
            navigationService.NavigateTo<HomeViewModel>(NavToken.Main);
        }
      
        #endregion

    }
}
