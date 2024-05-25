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

        public ClothingRequestController(ClothingContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var result = _context.ClothingRequests;

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddRequest(ClothingRequest request)
        {
            await _context.ClothingRequests.AddAsync(request);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}