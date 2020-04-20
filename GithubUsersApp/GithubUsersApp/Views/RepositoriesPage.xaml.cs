using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GithubUsersApp.Views
{
    public partial class RepositoriesPage : ContentPage
    {
        public ObservableCollection<string> Items { get; set; }

        public RepositoriesPage()
        {
            InitializeComponent();
        }
    }
}
