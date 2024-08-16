using Microsoft.AspNetCore.Mvc;

namespace LocationA.API.Controllers

{
    [Route("api[controller]")]
    [ApiController]
    public class DistrictsController : ControllerBase
    {
        [HttpGet("GetAll")]
        public IEnumerable<string> Index()
        {
            return new string[] { "Serivce:LocationA.API->", "Dhaka", "Chittagong", "Chandpur", "Barisal", "Noakhali" };
        }
    }
}
