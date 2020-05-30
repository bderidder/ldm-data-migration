using LaDanse.Source.Entities.GameData.Characters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LaDanse.Source.Configurations.GameData.Characters
{
    public class GuildCharacterVersionConfiguration : IEntityTypeConfiguration<GuildCharacterVersion>
    {
        public void Configure(EntityTypeBuilder<GuildCharacterVersion> builder)
        {
            builder.ToTable("GuildCharacterVersion");

            builder.HasIndex(e => e.CharacterId)
                .HasName("IDX_A70EBD185AF690F3");

            builder.HasIndex(e => e.GameClassId)
                .HasName("IDX_A70EBD18F3B4E37B");

            builder.HasIndex(e => e.GameRaceId)
                .HasName("IDX_A70EBD18E036C39A");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .HasColumnType("int(11)");

            builder.Property(e => e.CharacterId)
                .HasColumnName("characterId")
                .HasColumnType("int(11)");

            builder.Property(e => e.EndTime)
                .HasColumnName("endTime")
                .HasColumnType("datetime");

            builder.Property(e => e.FromTime)
                .HasColumnName("fromTime")
                .HasColumnType("datetime");

            builder.Property(e => e.GameClassId)
                .HasColumnName("gameClassId")
                .HasComment("(DC2Type:guid)")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_unicode_ci");

            builder.Property(e => e.GameRaceId)
                .HasColumnName("gameRaceId")
                .HasComment("(DC2Type:guid)")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_unicode_ci");

            builder.Property(e => e.Level)
                .HasColumnName("level")
                .HasColumnType("smallint(6)");

            builder.HasOne(d => d.Character)
                .WithMany()
                .HasForeignKey(d => d.CharacterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_A70EBD185AF690F3");

            builder.HasOne(d => d.GameClass)
                .WithMany()
                .HasForeignKey(d => d.GameClassId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_A70EBD18F3B4E37B");

            builder.HasOne(d => d.GameRace)
                .WithMany()
                .HasForeignKey(d => d.GameRaceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_A70EBD18E036C39A");
        }
    }
}