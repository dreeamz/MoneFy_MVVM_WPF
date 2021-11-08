using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneFy_MVVM_WPF.Model
{
    public class Wallet
    {
        public double Balace;
        public double Expenses;

        private double _income;
        public double Income
        {
            get => _income;
            set
            {
                _income = value;
                Balace += Income;
            }
        }
        private double _outgoing;
        public double Outgoing
        {
            get => _outgoing;
            set
            {
                _outgoing = value;
                Expenses += _outgoing;
                Balace -= _outgoing;
            }
        }

       
    }
}
