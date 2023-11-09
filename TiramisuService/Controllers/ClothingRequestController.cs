using Microsoft.AspNetCore.Mvc;
using TiramisuService.Models;

namespace TiramisuService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClothingRequestController : ControllerBase
    {
        public IActionResult Index()
        {
            var requests = new List<ClothingRequest>() {
                new ClothingRequest { Age = 8, Gender = Gender.Girl, DesiredSize = "M", RequestedClothes = "Shirt, Pants" },
                new ClothingRequest { Age = 12, Gender = Gender.Girl, DesiredSize = "L", RequestedClothes = "Coat" } };
            
            return Ok(requests);
        }
    }
}
