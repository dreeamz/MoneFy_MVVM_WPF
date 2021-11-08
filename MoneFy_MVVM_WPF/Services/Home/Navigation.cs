using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using MoneFy_MVVM_WPF.Enums;
using MoneFy_MVVM_WPF.Messages;
using MoneFy_MVVM_WPF.ViewModel.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneFy_MVVM_WPF.Services.Home
{
    //this class was created to separate services from HomeViewModel constructor 
    //and made it's registration in this class
    
    public class Navigation
    {
        #region Fields And Properties
        readonly HomeViewModel homeViewModel;

        bool _leftBar = true;
        bool _rightBar = true;
        #endregion 
        public Navigation(INavigationService NS, IMessenger IM,IAccountingService AS)
        {
           
            homeViewModel = App.Container.GetInstance<HomeViewModel>();

            homeViewModel.NavigationService = NS;
            homeViewModel.Messenger = IM;
            homeViewModel.accountingService = AS;

            #region HomeViewModel registrations

            homeViewModel.Messenger.Register<NavigationMessage>(homeViewModel, NavToken.LeftSideBar, message =>
            {
                ViewModelBase viewModel = App.Container.GetInstance(message.ViewModelBase) as ViewModelBase;
                CloseOpenLeftBar(_leftBar, viewModel);
            });
            homeViewModel.Messenger.Register<NavigationMessage>(homeViewModel, NavToken.RightSideBar, message =>
            {
                ViewModelBase viewModel = App.Container.GetInstance(message.ViewModelBase) as ViewModelBase;
                CloseOpenRightBar(_rightBar,viewModel);
            });
            homeViewModel.Messenger.Register<TransactionMessage>(homeViewModel,AccToken.Add,message =>
            {
                homeViewModel.accountingService.Transact(message.Transaction,AccToken.Add);
                homeViewModel.Balance = homeViewModel.accountingService.Balance();
            });
            homeViewModel.Messenger.Register<TransactionMessage>(homeViewModel,AccToken.Substract,message =>
            {
                homeViewModel.accountingService.Transact(message.Transaction,AccToken.Substract);
                homeViewModel.Balance = homeViewModel.accountingService.Balance();
            });

            #endregion
        }

        #region Functions for changing SideBars
        private void CloseOpenRightBar(bool check,ViewModelBase viewModel)
        {
            _rightBar = check;
            if (_rightBar)
            {
                homeViewModel.RightSideBar = viewModel;
                _rightBar = false;
            }
            else
            {
                homeViewModel.RightSideBar = null;
                _rightBar = true;
            }
        }
        private void CloseOpenLeftBar(bool check,ViewModelBase viewModel)
        {
            _leftBar = check;

            if (_leftBar)
            {
                homeViewModel.LeftSideBar = viewModel;
                _leftBar = false;
            }
            else
            {
                homeViewModel.LeftSideBar = null;
                _leftBar = true;
            }
        }
        #endregion
    }
}
