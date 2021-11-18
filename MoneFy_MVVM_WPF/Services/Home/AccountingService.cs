using MoneFy_MVVM_WPF.Enums;
using MoneFy_MVVM_WPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneFy_MVVM_WPF.Services.Home
{
    public class AccountingService : IAccountingService
    {
        public Wallet wallet;
        public AccountingService(Wallet W)
        {
            wallet = W;
        }
        public void Count(Transaction transaction, AccToken token)
        {
            if (token == AccToken.Add)
                wallet.Balace += transaction.Summ;
            else
            {                
                wallet.Outgoing = transaction.Summ;
            }
        }
        public string Balance()=> wallet.Balace.ToString();
        public string Expenses()=> wallet.Expenses.ToString();
        
    }
}
