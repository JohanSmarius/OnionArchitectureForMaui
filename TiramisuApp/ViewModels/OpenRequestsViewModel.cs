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
using Domain;
using DomainService;

namespace TiramisuApp.ViewModels
{
    public partial class OpenRequestsViewModel : ObservableObject
    {
        private readonly IRequestRepository _requestRepository;

        public ObservableCollection<ClothingRequest> OpenRequests { get; } = new();

        public OpenRequestsViewModel(IRequestRepository requestRepository)
        {
            this._requestRepository = requestRepository;
        }

        [RelayCommand]
        async Task GetOpenRequestsAsync()
        {
            OpenRequests.Clear();
            OpenRequests.Add(new ClothingRequest { Age = 6, Gender = Gender.Girl, DesiredSize = "M", RequestedClothes = "Shirt, Pants" });
            OpenRequests.Add(new ClothingRequest { Age = 10, Gender = Gender.Girl, DesiredSize = "L", RequestedClothes = "Coat" });

            var requestsFromServer = await _requestRepository.GetOpenRequestsAsync();
            foreach (var request in requestsFromServer)
            {
                OpenRequests.Add(request);
            }

        }
    }
}
