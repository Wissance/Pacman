using Microsoft.AspNetCore.Mvc;
using Wissance.Pacman.WebAPI.Data;

namespace Wissance.Pacman.WebAPI.Controllers
{
    public sealed class PackageController : ControllerBase
    {
        [HttpPut("{KnownNuGetResourceMethods.PublishMethodPath}/{packageId}/{version}")]
        public async Task<IActionResult> PushPackageAsync(string packageId, string version, IFormFile packageFile)
        {
            return null;
        }

    }
}