﻿using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Essentials;

namespace GithubUsersApp.APIClients.APIClients
{
    public class HttpClientProvider
    {
        #region Private Properties

        private static readonly string BaseUrl = @"https://api.github.com/";

        #endregion

        #region Constructors

        public HttpClientProvider(){}

        #endregion

        #region Public Implementation

        public async Task<HttpClient> GetHttpClient()
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(BaseUrl);
            httpClient.Timeout = TimeSpan.FromMinutes(1); //Setting the API timeout 1 minute
            return httpClient;
        }

        #endregion
    }
}
