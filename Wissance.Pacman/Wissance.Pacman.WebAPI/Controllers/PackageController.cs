using Microsoft.AspNetCore.Mvc;
using Wissance.Pacman.Dto;
using Wissance.Pacman.WebAPI.Data;
using Wissance.Pacman.WebAPI.Managers;
using Wissance.WebApiToolkit.Dto;

namespace Wissance.Pacman.WebAPI.Controllers
{
    public sealed class PackageController : ControllerBase
    {
        public PackageController(PackageManager manager)
        {
            _manager = manager;
        }

        [HttpPut($"{KnownNuGetResourceMethods.PublishMethodPath}/{{packageId}}/{{version}}")]
        public async Task<PackageDto> PushPackageAsync(string packageId, string version, IFormFile packageFile)
        {
            OperationResultDto<PackageDto> result = await _manager.PublishAsync();
            Response.StatusCode = result.Status;
            return result.Data;
        }

        private readonly PackageManager _manager;
    }
}