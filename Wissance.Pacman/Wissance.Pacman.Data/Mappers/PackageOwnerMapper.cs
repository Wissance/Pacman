using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wissance.Pacman.Data.Entities;

namespace Wissance.Pacman.Data.Mappers
{
    internal static class PackageOwnerMapper
    {
        public static void Map(this EntityTypeBuilder<PackageOwner> builder)
        {
            builder.ToTable("package_owners");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(256);
            builder.Property(p => p.IsOrganization).IsRequired();
            builder.Property(p => p.AdditionalInfo).HasColumnType("jsonb"); // Для PostgreSQL, для SQLite → "text"
        
            builder.HasIndex(p => p.Name);
        }
    }
}