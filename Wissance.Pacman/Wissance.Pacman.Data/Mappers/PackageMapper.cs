using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wissance.Pacman.Data.Entities;

namespace Wissance.Pacman.Data.Mappers
{
    internal static class PackageMapper
    {
        public static void Map(this EntityTypeBuilder<Package> builder)
        {
            builder.ToTable("packages");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(256);
            builder.Property(p => p.Description).HasMaxLength(4000);
            builder.Property(p => p.CreatedAt).IsRequired().HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder.Property(p => p.DeprecatedAt).IsRequired(false).HasDefaultValue(null);
            builder.Property(p => p.IsAvailable).IsRequired().HasDefaultValue(true);
            builder.Property(p => p.AdminUserId).IsRequired();
            
            builder.HasIndex(p => p.Name).IsUnique().HasDatabaseName("ix_packages_name");
            builder.HasIndex(p => p.IsAvailable).HasDatabaseName("ix_packages_is_available");
            builder.HasIndex(p => p.DeprecatedAt).HasDatabaseName("ix_packages_deprecated_at");
            
            builder.HasMany(p => p.Owners).WithMany().UsingEntity(j => j.ToTable("packages_package_owners"));
        }
    }
}