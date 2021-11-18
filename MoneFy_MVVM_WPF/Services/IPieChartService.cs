using LiveCharts;
using MoneFy_MVVM_WPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneFy_MVVM_WPF.Services
{
    public interface IPieChartService
    {
        public SeriesCollection Collection { get; set; }
        public void InitCollection(string test);
        public void ChangeCollectonItem(string CategoryName, Transaction value);
    }
}
