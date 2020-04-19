using GithubUsersApp.APIClients.APIClients;
using GithubUsersApp.APIClients.APIClients.Interfaces;
using Prism.Ioc;
using Prism.Modularity;
using System;
using System.Collections.Generic;
using System.Text;

namespace GithubUsersApp.APIClients
{
    public class APIClientsModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {}

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<HttpClientProvider>();
            containerRegistry.RegisterSingleton<IUserApiClient, UserApiClient>();
        }
    }
}
