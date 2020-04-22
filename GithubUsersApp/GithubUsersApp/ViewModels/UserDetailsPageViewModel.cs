using GithubUsersApp.Data;
using GithubUsersApp.Data.Models;
using Newtonsoft.Json;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace GithubUsersApp.ViewModels
{
    public class UserDetailsPageViewModel : ViewModelBase
    {
        #region Private Properties
        
        private User _user;
        
        #endregion
        
        #region Get Set

        public User User 
        { 
            get { return _user; } 
            set { SetProperty(ref _user, value); } 
        }

        #endregion
        public UserDetailsPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            try
            {
                User = JsonConvert.DeserializeObject<User>(Preferences.Get(Constants.Keys.User, string.Empty));
                
                if(User !=null && !String.IsNullOrWhiteSpace(User.Login))
                {
                    Title = User.Login;
                }
            }
            catch (System.Exception ex)
            {
                Console.Write(ex.Message);
            }
        }
    }
}
