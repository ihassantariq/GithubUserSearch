using GithubUsersApp.Data;
using GithubUsersApp.Data.Models;
using GithubUsersApp.Models;
using GithubUsersApp.Views;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace GithubUsersApp.ViewModels
{
    public class HomePageViewModel : ViewModelBase
    {
        #region Private Properties

        private MenuItems _selectedMenuItem;
        private string _appVersion;
        private User _user;

        #endregion

        #region Command

        public ICommand NavigateCommand => new Command(NavigateTapped);

        #endregion

        #region Get Set

        public ObservableCollection<MenuItems> MenuItemsList { get; set; } = new ObservableCollection<MenuItems>(MenuItems.GetMenuData());

        public User User { get { return _user; } set { SetProperty(ref _user, value); } }

        public MenuItems SelectedMenuItem
        {
            get { return _selectedMenuItem; }
            set
            {
                SetProperty(ref _selectedMenuItem, value);
            }
        }

        public string AppVersion
        {
            get { return _appVersion; }
            set
            {
                SetProperty(ref _appVersion, value);
            }
        }

        #endregion

        #region Constructor
        public HomePageViewModel(INavigationService navigationService) : base(navigationService)
        {
            _appVersion = "1.0.0"; //For now just for UI don't have to make it dynamic
            try
            {
                User = JsonConvert.DeserializeObject<User>(Preferences.Get(Constants.Keys.User, string.Empty));
            }
            catch (System.Exception ex)
            {
                Console.Write(ex.Message);
            }
        }
        #endregion

        #region Private Implementation

        private void NavigateTapped(object obj)
        {
            if (SelectedMenuItem.Title.Equals("Go Out"))
            {
                Preferences.Clear();
                NavigationService.NavigateAsync($"/{nameof(NavigationPage)}/{nameof(UserPage)}");
            }
            else
            {
                NavigationService.NavigateAsync($"{nameof(NavigationPage)}/{SelectedMenuItem.PageName}");
            }
            SelectedMenuItem = null;
        }

        #endregion
    }
}
