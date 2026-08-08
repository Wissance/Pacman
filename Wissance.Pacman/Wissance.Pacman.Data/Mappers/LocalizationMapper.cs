using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wissance.Pacman.Data.Entities;

namespace Wissance.Pacman.Data.Mappers
{
    internal static class LocalizationMapper
    {
        public static void Map(this EntityTypeBuilder<Localization> builder)
        {
            builder.ToTable("localizations");
            builder.HasKey(p => p.Id);
            builder.HasMany(p => p.Localizations).WithOne(p => p.Loc)
                   .HasForeignKey(p => p.LocalizationId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}