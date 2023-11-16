using Domain;
using DomainService;
using System.Text.Json;

namespace WebServiceInfrastructure
{
    public class RequestRepository : IRequestRepository
    {
        public Task AddRequestAsync(ClothingRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ClothingRequest>> GetOpenRequestsAsync()
        {
            using var client = new HttpClient();
            var response = await client.GetAsync("https://clothingrequestservice.azurewebsites.net/clothingrequest");
            if (response.IsSuccessStatusCode)
            {
                var rawReponse = await response.Content.ReadAsStringAsync();

                var list = JsonSerializer.Deserialize<List<ClothingRequest>>(rawReponse);
                return list;
            }
            else
            {
                return new List<ClothingRequest>();
            }
        }
    }
}
