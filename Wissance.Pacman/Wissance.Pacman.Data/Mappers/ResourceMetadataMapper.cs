using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wissance.Pacman.Data.Entities;

namespace Wissance.Pacman.Data.Mappers
{
    internal static class ResourceMetadataMapper
    {
        public static void Map(this EntityTypeBuilder<ResourceMetadata> builder)
        {
            builder.ToTable("resources");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Path).IsRequired().HasMaxLength(128);
        }
    }
}