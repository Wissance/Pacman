using System.Net;
using Microsoft.EntityFrameworkCore;
using Wissance.Pacman.Data;
using Wissance.Pacman.Data.Entities;
using Wissance.Pacman.Dto;
using Wissance.Pacman.WebAPI.Factories;
using Wissance.WebApiToolkit.Dto;

namespace Wissance.Pacman.WebAPI.Managers
{
    public class ServiceIndexManager
    {
        public ServiceIndexManager(PacmanDbContext dbContext, ILoggerFactory loggerFactory)
        {
            _dbContext = dbContext;
            _logger = loggerFactory.CreateLogger<ServiceIndexManager>();
        }

        public async Task<OperationResultDto<ServiceIndexDto>> GetAsync()
        {
            try
            {
                IList<ResourceMetadata> resources = await _dbContext.Resources.ToListAsync();
                ServiceIndexDto data = ServiceIndexFactory.Create(NugetServiceVersion, resources);
                return new OperationResultDto<ServiceIndexDto>(true, (int)HttpStatusCode.OK, string.Empty, data);
            }
            catch (Exception e)
            {
                string msg = $"An error occurred during \"GetAsync\" of \"ServiceIndexManager\", error: {e.Message}";
                _logger.LogError(msg);
                _logger.LogError(e.ToString());
                return new OperationResultDto<ServiceIndexDto>(false, (int) HttpStatusCode.InternalServerError, msg, null);
            }
        }

        private const string NugetServiceVersion = "v3";

        private readonly PacmanDbContext _dbContext;
        private readonly ILogger<ServiceIndexManager> _logger;
    }
}