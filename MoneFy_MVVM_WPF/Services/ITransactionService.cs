using MoneFy_MVVM_WPF.Enums;
using MoneFy_MVVM_WPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneFy_MVVM_WPF.Services
{
    public interface ITransactionService
    {
        public void Transact(Transaction transaction,AccToken token);
    }
}
