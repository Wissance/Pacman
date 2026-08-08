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
            builder.Property(p => p.Version).IsRequired().HasMaxLength(16);
            builder.Property(p => p.Type).IsRequired().HasMaxLength(128);
            builder.HasOne<Localization>(p => p.Comment).WithMany()
                   .HasForeignKey(p => p.CommentId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}