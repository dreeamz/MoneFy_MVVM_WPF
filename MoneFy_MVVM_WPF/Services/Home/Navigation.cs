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
    //for separate services for HomeViewModel constructor
    public class Navigation
    {
        readonly HomeViewModel homeViewModel;

        bool _leftBar = true;
        bool _rightBar = true;

        public Navigation(INavigationService NS, IMessenger IM)
        {
           
            homeViewModel = App.Container.GetInstance<HomeViewModel>();

            homeViewModel.NavigationService = NS;
            homeViewModel.Messenger = IM;

            #region HomeViewModel registrations

            homeViewModel.Messenger.Register<NavigationMessage>(homeViewModel, Token.LeftSideBar, message =>
            {
                ViewModelBase viewModel = App.Container.GetInstance(message.ViewModelBase) as ViewModelBase;
                CloseOpenLeftBar(_leftBar, viewModel);
            });
            homeViewModel.Messenger.Register<NavigationMessage>(this, Token.RightSideBar, message =>
            {
                ViewModelBase viewModel = App.Container.GetInstance(message.ViewModelBase) as ViewModelBase;
                CloseOpenRightBar(_rightBar,viewModel);
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
