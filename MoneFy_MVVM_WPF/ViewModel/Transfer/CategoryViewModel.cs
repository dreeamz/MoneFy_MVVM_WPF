using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using MoneFy_MVVM_WPF.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneFy_MVVM_WPF.ViewModel.Transfer
{
    public class CategoryViewModel:ViewModelBase
    {
        private readonly IMessenger messenger;
        private readonly INavigationService navigationService;
        public CategoryViewModel(IMessenger M,INavigationService N)
        {
            messenger = M;  
            navigationService = N;
        }

    }
}
