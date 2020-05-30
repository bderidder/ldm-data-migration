using LaDanse.Source.Entities.GameData.Sync.Guild;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LaDanse.Source.Configurations.GameData.Sync.Guild
{
    public class GuildSyncConfiguration : IEntityTypeConfiguration<GuildSync>
    {
        public void Configure(EntityTypeBuilder<GuildSync> builder)
        {
            builder.ToTable("GuildSync");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .HasComment("(DC2Type:guid)")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_unicode_ci");

            builder.HasIndex(e => e.GuildId)
                .HasName("IDX_18BD775675407DAB");

            builder.Property(e => e.GuildId)
                .HasColumnName("guild")
                .HasComment("(DC2Type:guid)")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_unicode_ci");

            builder.HasOne(d => d.Guild)
                .WithMany()
                .HasForeignKey(d => d.GuildId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_18BD775675407DAB");
        }
    }
}