using Wissance.Pacman.Data.Entities;
using Wissance.Pacman.Dto;

namespace Wissance.Pacman.WebAPI.Factories
{

    internal static class ResourceMetadataFactory
    {
        public static ResourceMetadataDto Create(ResourceMetadata entity, string language)
        {
            return new ResourceMetadataDto()
            {
                //todo(UMV) combine a full path here
                Id = entity.Path,
                Type = $"{entity.Type}/{entity.Version}",
                Comment = entity.Comment.Localizations.FirstOrDefault(l => string.Equals(l.LanguageCode.ToLower(), language.ToLower()))?.Text ??
                          "no localization string in db"
            };
        }
    }
}