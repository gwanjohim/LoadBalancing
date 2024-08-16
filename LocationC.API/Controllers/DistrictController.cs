using Microsoft.AspNetCore.Mvc;

namespace LocationC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictController : ControllerBase
    {
        // GET: api/<DistrictController>
        [HttpGet("GetAll")]
        public IEnumerable<string> Get()
        {
            return new string[] { "Serivce:LocationC.API->", "Kustia", "Norail", "Kurigram", "Netrokona" };
        }
    }
}
