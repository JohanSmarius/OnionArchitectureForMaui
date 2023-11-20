using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiramisuApp.Models;
using TiramisuApp.Services;

namespace TiramisuApp.ViewModels
{
    public partial class NewRequestViewModel : ObservableObject
    {
        private readonly INavigationService _navigationService;
        private readonly IGeolocation _geolocation;

        [ObservableProperty]
        int age;

        [ObservableProperty]
        string size;

        [ObservableProperty]
        string clothes;

        public NewRequestViewModel(INavigationService navigationService, IGeolocation geolocation)
        {
            _navigationService = navigationService;
            _geolocation = geolocation;
        }

        [RelayCommand]
        async Task AddNewRequetAsync()
        {

            var ClothingReques = new ClothingRequest { DesiredSize = size, Age = age, RequestedClothes = clothes };

            // In the future this request will be saved.
            
            // check if the location is near enough.
            var location = await _geolocation.GetLocationAsync(
                new GeolocationRequest(GeolocationAccuracy.Best, TimeSpan.FromSeconds(60)));
            Console.WriteLine($"{location.Longitude}. {location.Latitude} {location.Accuracy}");

            await _navigationService.NavigateAsync("//OpenRequests");
        
        }
    }
}
