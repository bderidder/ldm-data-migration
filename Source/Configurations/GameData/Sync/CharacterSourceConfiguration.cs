using LaDanse.Source.Entities.GameData.Sync;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LaDanse.Source.Configurations.GameData.Sync
{
    public class CharacterSourceConfiguration : IEntityTypeConfiguration<CharacterSource>
    {
        public void Configure(EntityTypeBuilder<CharacterSource> builder)
        {
            builder.ToTable("CharacterSource");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .HasComment("(DC2Type:guid)")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_unicode_ci");

            /*
            builder.HasDiscriminator<string>("discr")
                .HasValue<GuildSync>("GuildSync")
                .HasValue<ProfileSync>("ProfileSync");

            builder.Property("discr")
                .IsRequired()
                .HasColumnName("discr")
                .HasColumnType("varchar(255)")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_unicode_ci");
            */
        }
    }
}
