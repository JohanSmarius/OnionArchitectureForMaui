using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiramisuApp.Services
{
    public interface INavigationService
    {
        Task NavigateAsync(string route);
    }
}
