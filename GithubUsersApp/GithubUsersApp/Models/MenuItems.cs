using GithubUsersApp.Views;
using System.Collections.Generic;

namespace GithubUsersApp.Models
{
    public class MenuItems
    {
        public char Icon { get; set; }
        public string Title { get; set; }
        public string PageName { get; set; }

        public static List<MenuItems> GetMenuData()
        {
            return new List<MenuItems>()
            {
                new MenuItems { Icon = '\uf022' , Title = "Repositories" , PageName = nameof(HomePage) },
                new MenuItems { Icon = '\uf007' , Title = "User Detail", PageName = nameof(HomePage) },
                new MenuItems { Icon = '\uf2f5' , Title = "Logout" }
            };
        }
    }
}
