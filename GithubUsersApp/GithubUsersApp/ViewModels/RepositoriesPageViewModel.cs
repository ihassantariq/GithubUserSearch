using GithubUsersApp.APIClients.APIClients.Interfaces;
using GithubUsersApp.Data;
using GithubUsersApp.Data.Helpers;
using GithubUsersApp.Data.Models;
using GithubUsersApp.Views;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
namespace GithubUsersApp.ViewModels
{
    public class RepositoriesPageViewModel : ViewModelBase
    {
        #region Private Properties
        private Repository _selectedMenuItem;
        private User _user;
        private IUserApiClient _userApiClient;
        #endregion

        #region Command

        public ICommand NavigateCommand => new Command(NavigateTapped);

        #endregion

        #region Get Set

        public ObservableCollection<Repository> Repositories { get; set; } = new ObservableCollection<Repository>();


        public Repository SelectedMenuItem
        {
            get { return _selectedMenuItem; }
            set
            {
                SetProperty(ref _selectedMenuItem, value);
            }
        }
        #endregion

        public RepositoriesPageViewModel(INavigationService navigationService, 
            IUserApiClient userApiClient): base(navigationService)
        {
            _userApiClient = userApiClient;
            Title = "Repositories";
            
            try
            {
                _user = JsonConvert.DeserializeObject<User>(Preferences.Get(Constants.Keys.User, string.Empty));
            }
            catch (System.Exception ex)
            {
                Console.Write(ex.Message);
            }
            LoadRepositories();
        }
        private async void LoadRepositories()
        {
            IsBusy = true;
            if (_user != null && !string.IsNullOrWhiteSpace(_user.Login))
            {
                List<Repository> repos = await _userApiClient.GetUserRepos(_user.Login);
                if (repos != null && repos.Count > 0)
                {
                    foreach(var item in repos)
                    {
                        Repositories.Add(item);
                    }
                }
            }
            IsBusy = false;
        }

        #region Private Implementation

        private void NavigateTapped(object obj)
        {
            if (SelectedMenuItem != null )
            {
               // _navigationService.NavigateAsync($"{nameof(NavigationPage)}/{}");
            }
            SelectedMenuItem = null;
        }

        #endregion
    }
}
