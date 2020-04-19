using GithubUsersApp.APIClients.APIClients.Interfaces;
using GithubUsersApp.Data.Helpers;
using GithubUsersApp.Data.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace GithubUsersApp.ViewModels
{
    public class UserPageViewModel : ViewModelBase
    {

        #region Private Properties
        private IUserApiClient _userApiClient;
        private IPageDialogService _pageDialogService;
        public string UserName { set; get; }
        #endregion

        #region Commands

        public ICommand SeeUserDetailsCommand => new Command(GetUserDetails);

        #endregion
        public UserPageViewModel(INavigationService navigationService,
            IUserApiClient userApiClient,
            IPageDialogService pageDialogService)
            : base(navigationService)
        {

            _userApiClient = userApiClient;
            _pageDialogService = pageDialogService;

             Title = "User Page";
        }
        private async void GetUserDetails()
        {
            if (!string.IsNullOrWhiteSpace(UserName))
            {
                User user = await _userApiClient.GetUser(UserName);
            }
            else
            {
                UserDialogsHelper.ShowNotification("Username cannot be empty.", NotificationTypeEnum.Error);
            }
        }
    }
}
