using Wissance.Pacman.Data.Entities;
using Wissance.Pacman.Dto;

namespace Wissance.Pacman.WebAPI.Factories
{

    internal static class ServiceIndexFactory
    {
        public static ServiceIndexDto Create(string version, IList<ResourceMetadata> resources, string language="en")
        {
            return new ServiceIndexDto()
            {
                Version = version,
                Resources = resources != null
                          ? resources.Select(r => ResourceMetadataFactory.Create(r, language)).ToList()
                          : new List<ResourceMetadataDto>()
            };
        }
    }
}