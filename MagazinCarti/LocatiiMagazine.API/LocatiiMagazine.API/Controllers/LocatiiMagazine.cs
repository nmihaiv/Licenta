using Microsoft.AspNetCore.Mvc;

namespace LocatiiMagazine.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocatiiMagazine : ControllerBase
    {

        [HttpGet("LocatiiMagazine")]
        public IEnumerable<string> AfiseazaLocatiiMagazine()
        {
            return new string[] { "Bucuresti", "Sibiu", "Cluj", "Iasi" };
        }

    }
}
