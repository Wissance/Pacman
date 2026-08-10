using Wissance.Pacman.Data;
using Wissance.Pacman.Dto;
using Wissance.WebApiToolkit.Core.Managers;
using Wissance.WebApiToolkit.Dto;

namespace Wissance.Pacman.WebAPI.Managers
{
    public class PackageManager
    {
        public PackageManager(PacmanDbContext dbContext, IFileManager fileManager, ILoggerFactory loggerFactory)
        {
            _dbContext = dbContext;
            _fileManager = fileManager;
            _logger = loggerFactory.CreateLogger<PackageManager>();
        }

        public async Task<OperationResultDto<PackageDto>> PublishAsync()
        {
            try
            {
                return new OperationResultDto<PackageDto>(true, 200, "", new PackageDto());
            }
            catch (Exception e)
            {
                return new OperationResultDto<PackageDto>(true, 500, "error", new PackageDto());
            }
        }

        private readonly PacmanDbContext _dbContext;
        private readonly IFileManager _fileManager;
        private readonly ILogger<PackageManager> _logger;
    }
}