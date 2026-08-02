using Microsoft.AspNetCore.Mvc;

namespace Wissance.Pacman.WebAPI.Controllers
{
    public class IndexController : ControllerBase
    {
        // todo ...
        [HttpGet("v3/index.json")]
        public IActionResult GetServiceIndex()
        {
            var serviceIndex = "";//new { ... };
            return Ok(serviceIndex); // Content-Type: application/json
        }
    }
}