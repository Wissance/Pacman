using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wissance.Pacman.Data.Entities;

namespace Wissance.Pacman.Data.Mappers
{
    internal static class TargetFrameworkMapper
    {
        public static void Map(this EntityTypeBuilder<TargetFramework> builder)
        {
            builder.ToTable("target_frameworks");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(64);
        
            builder.HasIndex(p => p.Name).IsUnique();
        }
    }
}