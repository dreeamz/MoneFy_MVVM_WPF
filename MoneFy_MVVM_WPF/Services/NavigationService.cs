using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using MoneFy_MVVM_WPF.Enums;
using MoneFy_MVVM_WPF.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneFy_MVVM_WPF.Services
{
    public class NavigationService : INavigationService
    {
        private IMessenger messenger;
        public NavigationService(IMessenger ms)
        {
            messenger = ms;
        }
        public void NavigateTo<T>(Token token) where T : ViewModelBase
        {
            messenger.Send<NavigationMessage>(new NavigationMessage() { ViewModelBase = typeof(T) },token);
        }

        
    }
}
