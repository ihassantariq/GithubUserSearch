using GithubUsersApp.Data;
using GithubUsersApp.Data.Models;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Essentials;

namespace GithubUsersApp.ViewModels
{
    public class RepoDetailsPageViewModel : ViewModelBase
    {
        #region Private Properties

        private Repository _repository;

        #endregion

        #region Get Set

        public Repository Repository
        {
            get { return _repository; }
            set { SetProperty(ref _repository, value); }
        }

        #endregion
        public RepoDetailsPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            try
            {
                Repository = JsonConvert.DeserializeObject<Repository>(Preferences.Get(Constants.Keys.Repo, string.Empty));

                if (Repository != null && !String.IsNullOrWhiteSpace(Repository.Name))
                {
                    Title = Repository.Name;
                }
            }
            catch (System.Exception ex)
            {
                Console.Write(ex.Message);
            }
        }
    }
}
