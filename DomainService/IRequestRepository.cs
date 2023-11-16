using Domain;

namespace DomainService
{
    public interface IRequestRepository
    {
        Task<IEnumerable<ClothingRequest>> GetOpenRequestsAsync();
        Task AddRequestAsync(ClothingRequest request);

    }
}
