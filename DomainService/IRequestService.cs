using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainService
{
    public interface IRequestService
    {
        Task AddRequest(ClothingRequest newRequest);
    }
}
