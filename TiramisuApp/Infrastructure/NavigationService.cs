using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiramisuApp.Services;

namespace TiramisuApp.Infrastructure
{
    public class NavigationService : INavigationService
    {
        public async Task NavigateAsync(string route)
        {
            await Shell.Current.GoToAsync(route);
        }
    }
}
