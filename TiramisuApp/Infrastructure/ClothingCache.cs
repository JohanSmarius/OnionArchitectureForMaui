using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiramisuApp.Models;
using TiramisuApp.Services;

namespace TiramisuApp.Infrastructure
{
    public class ClothingCache : IClothingCache
    {
        public Task AddClothing(ClothingRequest clothing)
        {
            //TODO: Add to local db
            throw new NotImplementedException();
        }

        public Task<List<ClothingRequest>> GetClothings()
        {
            //TODO: Get from local db
            throw new NotImplementedException();
        }
    }
}
