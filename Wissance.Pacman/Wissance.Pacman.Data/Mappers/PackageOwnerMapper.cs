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
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Name).IsRequired().HasMaxLength(256);
            builder.Property(p => p.IsOrganization).IsRequired().HasDefaultValue(false);
            // target DB is Postgres and Sqlite    
            builder.Property(p => p.AdditionalInfo).HasColumnType("jsonb");
        
            builder.HasIndex(p => p.Name);
        }
    }
}