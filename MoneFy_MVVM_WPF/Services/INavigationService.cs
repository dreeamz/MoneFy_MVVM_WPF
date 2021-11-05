using GalaSoft.MvvmLight;
using MoneFy_MVVM_WPF.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneFy_MVVM_WPF.Services
{
    public interface INavigationService
    {
        public void NavigateTo<T>(Token token) where T : ViewModelBase;
      
    }
}
