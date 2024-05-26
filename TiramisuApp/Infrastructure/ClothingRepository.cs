using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TiramisuApp.Models;
using TiramisuApp.Services;

namespace TiramisuApp.Infrastructure
{
    public class ClothingRepository : IClothingRepository
    {
        public async Task AddClothing(ClothingRequest clothing)
        {
            // Serialize clothing into JSON
            var clothingJson = new StringContent(JsonSerializer.Serialize(clothing));

            using var client = new HttpClient();
            await client.PostAsync("https://clothingrequestservice.azurewebsites.net/clothingrequest", clothingJson);
        }

        public async Task<List<ClothingRequest>> GetClothings()
        {
            using var client = new HttpClient();
            var response = await client.GetAsync("https://clothingrequestservice.azurewebsites.net/clothingrequest");
            if (response.IsSuccessStatusCode)
            {
                var rawReponse = await response.Content.ReadAsStringAsync();

                var list = JsonSerializer.Deserialize<List<ClothingRequest>>(rawReponse);
                return list;
            }

            return new List<ClothingRequest>();
        }
    }
}
