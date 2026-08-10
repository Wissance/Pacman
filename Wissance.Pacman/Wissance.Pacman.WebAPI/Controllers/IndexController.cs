using Microsoft.AspNetCore.Mvc;
using Wissance.Pacman.Dto;
using Wissance.Pacman.WebAPI.Managers;
using Wissance.WebApiToolkit.Core.Controllers;
using Wissance.WebApiToolkit.Dto;

namespace Wissance.Pacman.WebAPI.Controllers
{
    public sealed class IndexController : ControllerBase
    {
        public IndexController(ServiceIndexManager manager)
        {
            _manager = manager;
        }

        [HttpGet("v3/index.json")]
        public async Task<ServiceIndexDto> GetServiceIndex()
        {
            OperationResultDto<ServiceIndexDto> result = await _manager.GetAsync();
            Response.StatusCode = result.Status;
            return result.Data;
        }

        private readonly ServiceIndexManager _manager;
    }
}