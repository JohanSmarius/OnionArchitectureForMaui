using Microsoft.AspNetCore.Mvc;
using TiramisuService.Database;
using TiramisuService.Models;

namespace TiramisuService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClothingRequestController : ControllerBase
    {
        private readonly ClothingContext _context;

        //public ClothingRequestController(ClothingContext context)
        //{
        //    _context = context;
        //}

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = new List<ClothingRequest>()
            {
                new ClothingRequest
                {
                    Id = 1,
                    Age = 10,
                    DesiredSize = "160",
                    Gender  = Gender.Girl,
                    RequestedClothes = "Shirt, Pants"
                },
                new ClothingRequest
                {
                    Id = 2,
                    Age = 6,
                    DesiredSize = "140",
                    Gender = Gender.Girl,
                    RequestedClothes = "Coat"
                }
            };

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddRequest(ClothingRequest request)
        {
            //await _context.ClothingRequests.AddAsync(request);
            //await _context.SaveChangesAsync();
            return Ok();
        }
    }
}