using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiramisuApp.ViewModels
{
    public partial class NewRequestViewModel : ObservableObject
    {
        [ObservableProperty]
        int age;

        [ObservableProperty]
        string size;

        [ObservableProperty]
        string clothes;
    }
}
