using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using GithubUsersApp.Data.Helpers;
using GithubUsersApp.Data.Models;

namespace GithubUsersApp.APIClients.APIClients
{
    public abstract class BaseApiClient
    {
        #region Private Properties

        private HttpClientProvider _httpClientProvider;

        #endregion

        #region Constructors

        protected BaseApiClient(HttpClientProvider httpClientProvider)
        {
            _httpClientProvider = httpClientProvider;
        }

        #endregion

        #region Protected Implementation

        protected async Task<HttpClient> GetHttpClient()
        {
            return await _httpClientProvider.GetHttpClient();
        }

        public static async Task<bool> IsConnectionAvailable()
        {
            if (Xamarin.Essentials.Connectivity.NetworkAccess == Xamarin.Essentials.NetworkAccess.Internet)
            {
                return true;
            }
            else
            {
                UserDialogsHelper.ShowNotification("You are not connected to internet.", NotificationTypeEnum.Network, TimeSpan.FromSeconds(3));
                return false;
            }
        }

        #endregion
    }
}
