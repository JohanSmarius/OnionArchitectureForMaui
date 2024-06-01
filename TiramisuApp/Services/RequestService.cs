using TiramisuApp.Models;

namespace TiramisuApp.Services;

public class RequestService : IRequestService
{
    private readonly IClothingRepository clothingRepository;
    private readonly IClothingCache clothingCache;
    private readonly IDeviceStatus deviceStatus;

    public List<ClothingRequest> OpenRequests { get; private set; }

    public RequestService(IClothingRepository clothingRepository, IClothingCache clothingCache, IDeviceStatus deviceStatus)
    {
        this.clothingRepository = clothingRepository;
        this.clothingCache = clothingCache;
        this.deviceStatus = deviceStatus;
    }

    public async Task GetOpenRequests()
    {
        // Only get the requests if we don't have them already

        if (OpenRequests == null)
        {
            // Check if we have network connection
            if (await deviceStatus.IsOnline())
            {
                // If we do, get the requests from the server
                OpenRequests = await clothingRepository.GetClothings();
            }
            else
            {
                // If we don't, get the requests from the cache
                OpenRequests = await clothingCache.GetClothings();
            }
        }
    }
    
    public async Task AddRequest(ClothingRequest request)
    {
        // The collection can be null, so we need to initialize it
        if (OpenRequests == null)
        {
               OpenRequests = new List<ClothingRequest>();
        }

        // Add the request to the in-memory cache
        OpenRequests.Add(request);

        // Check if we have network connection
        if (await deviceStatus.IsOnline())
        {
            // If we do, add the request to the server
            await clothingRepository.AddClothing(request);
        }
        else
        {
            // If we don't, add the request to the cache
            await clothingCache.AddClothing(request);
        }
    }
}