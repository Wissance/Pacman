using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wissance.Pacman.Data.Entities;

namespace Wissance.Pacman.Data.Mappers
{
    internal static class PackageVersionMapper
    {
        public static void Map(this EntityTypeBuilder<PackageVersion> builder)
        {
            builder.ToTable("package_versions");
            builder.HasKey(v => v.Id);
            builder.Property(v => v.PackageId).IsRequired();
            builder.Property(v => v.PackageVersionStatsId).IsRequired();
            builder.Property(v => v.Version).IsRequired().HasMaxLength(64);
            builder.Property(v => v.Summary).HasMaxLength(4000);
            builder.Property(v => v.ReleaseNotes).HasColumnType("text");
            builder.Property(v => v.Authors).HasMaxLength(1024);
            builder.Property(v => v.ProjectUrl).HasMaxLength(512);
            builder.Property(v => v.LicenseUrl).HasMaxLength(512);
            builder.Property(v => v.IconUrl).HasMaxLength(512);
            builder.Property(v => v.RepositoryUrl).HasMaxLength(512);
            builder.Property(v => v.RepositoryType).HasMaxLength(32);
            builder.Property(v => v.PackageSize).IsRequired();
            builder.Property(v => v.PackageHash).IsRequired().HasMaxLength(512);
            builder.Property(v => v.PackageHashAlgorithm).IsRequired().HasMaxLength(32);
            builder.Property(v => v.IsListed).IsRequired().HasDefaultValue(true);
            builder.Property(v => v.PublishedAt).IsRequired().HasDefaultValueSql("CURRENT_TIMESTAMP");

            // Unique pair package+version 
            builder.HasIndex(v => new {v.PackageId, v.Version})
                   .IsUnique()
                   .HasDatabaseName("ix_package_versions_package_id_version");

            // Listed packages
            builder.HasIndex(v => v.IsListed).HasDatabaseName("ix_package_versions_is_listed");
            
            builder.HasOne(v => v.Package)
                .WithMany(p => p.Versions)
                .HasForeignKey(v => v.PackageId)
                .OnDelete(DeleteBehavior.Cascade);
            
            builder.HasMany(v => v.Tags)
                .WithMany()
                .UsingEntity(j => j.ToTable("package_version_tags"));
            
            builder.HasMany(v => v.Dependencies)
                .WithOne()
                // .HasForeignKey(d => d.PackageVersionId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}