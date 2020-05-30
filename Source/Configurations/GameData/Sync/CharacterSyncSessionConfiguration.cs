using LaDanse.Source.Entities.GameData.Sync;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LaDanse.Source.Configurations.GameData.Sync
{
    public class CharacterSyncSessionConfiguration : IEntityTypeConfiguration<CharacterSyncSession>
    {
        public void Configure(EntityTypeBuilder<CharacterSyncSession> builder)
        {
            builder.ToTable("CharacterSyncSession");

            builder.HasIndex(e => e.CharacterSourceId)
                .HasName("IDX_EC73362CDD71BB");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .HasComment("(DC2Type:guid)")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_unicode_ci");

            builder.Property(e => e.CharacterSourceId)
                .HasColumnName("characterSource")
                .HasComment("(DC2Type:guid)")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_unicode_ci");

            builder.Property(e => e.EndTime)
                .HasColumnName("endTime")
                .HasColumnType("datetime");

            builder.Property(e => e.FromTime)
                .HasColumnName("fromTime")
                .HasColumnType("datetime");

            builder.Property(e => e.Log)
                .HasColumnName("log")
                .HasColumnType("longtext")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_unicode_ci");

            builder.HasOne(d => d.CharacterSource)
                .WithMany()
                .HasForeignKey(d => d.CharacterSourceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EC73362CDD71BB");
        }
    }
}
