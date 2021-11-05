using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using MoneFy_MVVM_WPF.Enums;
using MoneFy_MVVM_WPF.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MoneFy_MVVM_WPF.ViewModel.Home
{
    public class AppBarViewModel:ViewModelBase
    {

        private readonly INavigationService NavigationService;
        public AppBarViewModel(INavigationService NS)
        {
            NavigationService = NS;
        }

        #region RelayCommands for HomeViewModel Left and Right Bars

        private RelayCommand _toLeftSideBar;      
        public RelayCommand ToLeftSideBar
        {
            get => _toLeftSideBar ??= new RelayCommand(delegate
            {
                NavigationService.NavigateTo<LeftSideBarViewModel>(Token.LeftSideBar);                    
               
            });
        }        
        
        private RelayCommand _toRightSideBar;      
        public RelayCommand ToRightSideBar
        {
            get => _toRightSideBar ??= new RelayCommand(delegate
            {
                NavigationService.NavigateTo<RightSideBarViewModel>(Token.RightSideBar);                    
               
            });
        }
        #endregion

    }
}
