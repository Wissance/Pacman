using Wissance.Pacman.Data.Entities;
using Wissance.Pacman.Dto;

namespace Wissance.Pacman.WebAPI.Factories
{

    internal static class ResourceMetadataFactory
    {
        public static ResourceMetadataDto Create(ResourceMetadata entity)
        {
            return new ResourceMetadataDto()
            {
                //todo(UMV) combine a full path here
                Id = entity.Path,
                Comment = entity.Comment,
                Type = entity.Type
            };
        }
    }
}