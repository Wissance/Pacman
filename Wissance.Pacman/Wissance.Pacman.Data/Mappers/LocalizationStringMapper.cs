using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wissance.Pacman.Data.Entities;

namespace Wissance.Pacman.Data.Mappers
{
    internal static class LocalizationStringMapper
    {
        public static void Map(this EntityTypeBuilder<LocalizationString> builder)
        {
            builder.ToTable("localization_strings");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.LanguageCode).IsRequired().HasMaxLength(16);
            builder.Property(p => p.Text).IsRequired().HasMaxLength(4096);
        }
    }
}