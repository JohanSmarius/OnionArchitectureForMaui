using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiramisuApp.Models;

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

        public NewRequestViewModel()
        {
        }

        [RelayCommand]
        async Task AddNewRequestAsync()
        {
            var ClothingRequest = new ClothingRequest { DesiredSize = size, Age = age, RequestedClothes = clothes };
            await Shell.Current.GoToAsync("//OpenRequests");
        }
    }
}
