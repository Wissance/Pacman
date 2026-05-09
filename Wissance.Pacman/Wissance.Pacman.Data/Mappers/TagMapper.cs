using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wissance.Pacman.Data.Entities;

namespace Wissance.Pacman.Data.Mappers
{
    internal static class TagMapper
    {
        public static void Map(this EntityTypeBuilder<Tag> builder)
        {
            builder.ToTable("tags");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(96);
            
            builder.HasIndex(p => p.Name).IsUnique();
        }
    }
}