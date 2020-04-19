using Prism;
using Prism.Ioc;
using GithubUsersApp.ViewModels;
using GithubUsersApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prism.Modularity;
using GithubUsersApp.APIClients;
using System;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace GithubUsersApp
{
    public partial class App
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync($"{nameof(NavigationPage)}/{nameof(UserPage)}");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<UserPage, UserPageViewModel>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            Type apiClientModuleType = typeof(APIClientsModule);
            moduleCatalog.AddModule(
            new ModuleInfo()
            {
                ModuleName = apiClientModuleType.Name,
                ModuleType = apiClientModuleType,
                InitializationMode = InitializationMode.WhenAvailable
            });
            base.ConfigureModuleCatalog(moduleCatalog);
        }
    }
}
