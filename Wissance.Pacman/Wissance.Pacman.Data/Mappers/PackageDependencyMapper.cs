using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wissance.Pacman.Data.Entities;

namespace Wissance.Pacman.Data.Mappers
{
    internal static class PackageDependencyMapper
    {
        public static void Map(this EntityTypeBuilder<PackageDependency> builder)
        {
            builder.ToTable("package_dependencies");
            builder.HasKey(d => d.Id);
            // builder.Property(d => d.PackageVersionId).IsRequired();
            builder.Property(d => d.PackageRepo).HasMaxLength(512);
            builder.Property(d => d.PackageId).IsRequired().HasMaxLength(256);
            builder.Property(d => d.MinVersion).HasMaxLength(64);
            builder.Property(d => d.MaxVersion).HasMaxLength(64);
            builder.Property(d => d.TargetFrameworkId).IsRequired();
            
            //builder.HasIndex(d => new { d.PackageVersionId, d.PackageId })
            //    .HasDatabaseName("IX_PackageDependencies_Version_Package");
        
            // Связь с TargetFramework
            builder.HasOne(d => d.Framework)
                .WithMany()
                .HasForeignKey(d => d.TargetFrameworkId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}