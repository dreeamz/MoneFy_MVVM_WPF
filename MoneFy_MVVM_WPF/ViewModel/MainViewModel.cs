using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using MoneFy_MVVM_WPF.Enums;
using MoneFy_MVVM_WPF.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneFy_MVVM_WPF.ViewModel
{
    public class MainViewModel : ViewModelBase
    { 
        private IMessenger Messenger;

        public MainViewModel(IMessenger ms)
        {
            Messenger = ms;
            Messenger.Register<NavigationMessage>(this,Token.Main, message =>
            {
                ViewModelBase viewModel = App.Container.GetInstance(message.ViewModelBase) as ViewModelBase;
                CurrentView = viewModel;
            });
        }

        private ViewModelBase _currentView;
        public ViewModelBase CurrentView
        {
            get { return _currentView; }
            set { Set(ref _currentView, value); }
        }


    }
}
