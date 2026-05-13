using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wissance.Pacman.Data.Entities;

namespace Wissance.Pacman.Data.Mappers
{
    internal static class PackageVersionStatsMapper
    {
        public static void Map(this EntityTypeBuilder<PackageVersionStats> builder)
        {
            builder.ToTable("package_version_stats");
            builder.HasKey(s => s.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(s => s.PackageVersionId).IsRequired();
            builder.Property(s => s.Downloads).IsRequired().HasDefaultValue(0);
        
            // DeepSeek solution, however we should have materialized view for that
            //builder.HasIndex(s => s.Downloads)
            //    .HasDatabaseName("IX_PackageVersionStats_Downloads");
            
            builder.HasOne(s => s.PackageVersion)
                .WithOne(v => v.Stats)
                .HasForeignKey<PackageVersionStats>(s => s.PackageVersionId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}