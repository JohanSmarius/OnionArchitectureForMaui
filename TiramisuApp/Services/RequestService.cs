using TiramisuApp.Models;

namespace TiramisuApp.Services;

public class RequestService : IRequestService
{
    private readonly IClothingRepository clothingRepository;
    private readonly IClothingCache clothingCache;

    public List<ClothingRequest> OpenRequests { get; private set; }

    public RequestService(IClothingRepository clothingRepository, IClothingCache clothingCache)
    {
        this.clothingRepository = clothingRepository;
        this.clothingCache = clothingCache;
    }

    public async Task GetOpenRequests()
    {
        // Check if we have network connection
        // If we do, get the requests from the server
        OpenRequests = await clothingRepository.GetClothings();

        // If we don't, get the requests from the cache
        if (OpenRequests == null)
        {
            OpenRequests = await clothingCache.GetClothings();
        }
    }
    
    public async Task AddRequest(ClothingRequest request)
    {
        // Check if we have network connection
        bool hasNetworkConnection = true;
        // If we do, add the request to the server
        OpenRequests.Add(request);

        // If we don't, add the request to the cache
        if (!hasNetworkConnection)
        {
            await clothingCache.AddClothing(request);
        }
    }
}