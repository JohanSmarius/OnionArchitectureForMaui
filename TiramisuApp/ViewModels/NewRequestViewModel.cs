using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using TiramisuApp.Services;

namespace TiramisuApp.ViewModels
{
    public partial class NewRequestViewModel : ObservableObject
    {
        private readonly INavigationService _navigationService;

        [ObservableProperty]
        int age;

        [ObservableProperty]
        string size;

        [ObservableProperty]
        string clothes;

        public NewRequestViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        [RelayCommand]
        async Task AddNewRequestAsync()
        {

            var ClothingReques = new ClothingRequest { DesiredSize = Size, Age = this.Age, RequestedClothes = Clothes };

            // In the future this request will be saved.

            await _navigationService.NavigateAsync("//OpenRequests");
        
        }
    }
}
