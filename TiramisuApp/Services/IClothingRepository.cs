using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiramisuApp.Models;

namespace TiramisuApp.Services
{
    public interface IClothingRepository
    {
        Task AddClothing(ClothingRequest clothing);

        Task<List<ClothingRequest>> GetClothings();
    }
}
