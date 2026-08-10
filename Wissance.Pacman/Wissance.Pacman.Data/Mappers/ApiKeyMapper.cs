using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wissance.Pacman.Data.Entities;

namespace Wissance.Pacman.Data.Mappers
{
    internal static class ApiKeyMapper
    {
        public static void Map(this EntityTypeBuilder<ApiKey> builder)
        {
            builder.ToTable("api_keys");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.KeyHash).IsRequired().HasMaxLength(4096);
            builder.Property(p => p.CreatedAt).IsRequired().HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder.Property(p => p.ExpiresAt).IsRequired(false);

            builder.HasOne(p => p.Owner).WithMany().HasForeignKey(p => p.OwnerId);
        }
    }
}