using LaDanse.Source.Entities.GameData.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LaDanse.Source.Configurations.GameData.Core
{
    public class GameRaceConfiguration : IEntityTypeConfiguration<GameRace>
    {
        public void Configure(EntityTypeBuilder<GameRace> builder)
        {
            builder.ToTable("GameRace");

            builder.HasIndex(e => e.FactionId)
                .HasName("IDX_D51A7CF883048B90");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .HasComment("(DC2Type:guid)")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_unicode_ci");

            builder.Property(e => e.GameId)
                .HasColumnName("armoryId")
                .HasColumnType("int(11)");

            builder.Property(e => e.FactionId)
                .HasColumnName("faction")
                .HasComment("(DC2Type:guid)")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_unicode_ci");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasColumnName("name")
                .HasColumnType("varchar(20)")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_unicode_ci");

            builder.HasOne(d => d.Faction)
                .WithMany()
                .HasForeignKey(d => d.FactionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_D51A7CF883048B90");
        }
    }
}
