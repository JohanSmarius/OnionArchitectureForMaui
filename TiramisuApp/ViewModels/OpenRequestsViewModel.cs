using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TiramisuApp.Models;
using TiramisuApp.Services;

namespace TiramisuApp.ViewModels
{
    public partial class OpenRequestsViewModel : ObservableObject
    {
        private readonly IRequestService requestService;

        public ObservableCollection<ClothingRequest> OpenRequests { get; } = new();

        public OpenRequestsViewModel(IRequestService requestService)
        {
            this.requestService = requestService;
        }

        [RelayCommand]
        public async Task GetOpenRequestsAsync()
        {
            OpenRequests.Clear();
            OpenRequests.Add(new ClothingRequest { Age = 6, Gender = Gender.Girl, DesiredSize = "M", RequestedClothes = "Shirt, Pants" });
            OpenRequests.Add(new ClothingRequest { Age = 10, Gender = Gender.Girl, DesiredSize = "L", RequestedClothes = "Coat" });

            await requestService.GetOpenRequests();
            foreach (var request in requestService.OpenRequests)
            {
                OpenRequests.Add(request);
            }
        }
    }
}
