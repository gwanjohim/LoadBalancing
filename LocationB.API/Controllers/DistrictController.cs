using Microsoft.AspNetCore.Mvc;

namespace LocationB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictController : ControllerBase
    {
        // GET: api/<DistrictController>
        [HttpGet("GetAll")]
        public IEnumerable<string> Get()
        {
            return new string[] { "Serivce:LocationB.API->", "Kumilla", "Bogura", "Natore", "Kurigram", "Natore" };
        }

    }
}
