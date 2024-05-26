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
        private readonly IRequestService requestService;
        [ObservableProperty]
        int age;

        [ObservableProperty]
        string size;

        [ObservableProperty]
        string clothes;

        public NewRequestViewModel(INavigationService navigationService, IRequestService requestService)
        {
            _navigationService = navigationService;
            this.requestService = requestService;
        }

        [RelayCommand]
        async Task AddNewRequestAsync()
        {

            var ClothingRequest = new ClothingRequest { DesiredSize = size, Age = age, RequestedClothes = clothes };

            await requestService.AddRequest(ClothingRequest);

            await _navigationService.NavigateAsync("//OpenRequests");
        
        }
    }
}
