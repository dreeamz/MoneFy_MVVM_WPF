using GalaSoft.MvvmLight.Messaging;
using MoneFy_MVVM_WPF.Enums;
using MoneFy_MVVM_WPF.Messages;
using MoneFy_MVVM_WPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneFy_MVVM_WPF.Services
{
    public class TransactionService : ITransactionService
    {
        public IMessenger Messenger;
        public TransactionService(IMessenger M)
        {
            Messenger = M;
        }
        public void Transact(Transaction transaction,AccToken token) 
        {
            Messenger.Send<TransactionMessage>(new TransactionMessage { Transaction = transaction },token); ; ;
        }
    }
}
