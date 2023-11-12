using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
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

        [RelayCommand]
        async Task AddNewRequetAsync()
        {

            var ClothingReques = new ClothingRequest { DesiredSize = size, Age = age, RequestedClothes = clothes };

            // In the future this request will be saved.
            await Shell.Current.DisplayAlert("Melding", "Aanvraag toegevoegd", "Cancel");

            await Shell.Current.GoToAsync("//OpenRequests");
        
        }
    }
}
