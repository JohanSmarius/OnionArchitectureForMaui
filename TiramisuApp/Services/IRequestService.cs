using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiramisuApp.Models;

namespace TiramisuApp.Services
{
    public interface IRequestService
    {
        List<ClothingRequest> OpenRequests { get; }

        Task AddRequest(ClothingRequest request);
        Task GetOpenRequests();
    }
}
