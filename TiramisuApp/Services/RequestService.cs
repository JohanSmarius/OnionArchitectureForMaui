using TiramisuApp.Models;

namespace TiramisuApp.Services;

public class RequestService
{
    public List<ClothingRequest> OpenRequests { get; private set; }

    public async Task GetOpenRequests()
    {
        // Get open requests
    }
    
    public async Task AddRequest(ClothingRequest request)
    {
        OpenRequests.Add(request);
    }
}