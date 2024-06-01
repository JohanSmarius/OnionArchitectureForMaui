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

namespace TiramisuApp.ViewModels
{
    public partial class OpenRequestsViewModel : ObservableObject
    {

        public ObservableCollection<ClothingRequest> OpenRequests { get; } = new();

        public OpenRequestsViewModel()
        {
        }

        [RelayCommand]
        public async Task GetOpenRequestsAsync()
        {
            OpenRequests.Clear();
            OpenRequests.Add(new ClothingRequest { Age = 6, Gender = Gender.Girl, DesiredSize = "M", RequestedClothes = "Shirt, Pants" });
            OpenRequests.Add(new ClothingRequest { Age = 10, Gender = Gender.Girl, DesiredSize = "L", RequestedClothes = "Coat" });

            using var client = new HttpClient();
            var response = await client.GetAsync("https://clothingrequestservice.azurewebsites.net/clothingrequest");
            if (response.IsSuccessStatusCode)
            {
                var rawReponse = await response.Content.ReadAsStringAsync();

                var list = JsonSerializer.Deserialize<List<ClothingRequest>>(rawReponse);
                foreach (var request in list)
                {
                    OpenRequests.Add(request);
                }
            }

        }
    }
}
