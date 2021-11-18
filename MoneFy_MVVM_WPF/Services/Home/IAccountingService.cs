using MoneFy_MVVM_WPF.Enums;
using MoneFy_MVVM_WPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneFy_MVVM_WPF.Services.Home
{
    public interface IAccountingService
    {
        public string Balance();
        public string Expenses();
        public void Count(Transaction transaction, AccToken token);

    }
}
