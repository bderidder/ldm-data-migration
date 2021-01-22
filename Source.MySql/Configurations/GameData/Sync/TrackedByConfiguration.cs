using LaDanse.Source.Entities.GameData.Sync;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LaDanse.Source.MySql.Configurations.GameData.Sync
{
    public class TrackedByConfiguration : IEntityTypeConfiguration<TrackedBy>
    {
        public void Configure(EntityTypeBuilder<TrackedBy> builder)
        {
            builder.ToTable("TrackedBy");

            builder.HasIndex(e => e.CharacterId)
                .HasDatabaseName("IDX_C2316E125AF690F3");

            builder.HasIndex(e => e.CharacterSourceId)
                .HasDatabaseName("IDX_C2316E122CDD71BB");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .HasComment("(DC2Type:guid)")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_unicode_ci");

            builder.Property(e => e.CharacterId)
                .HasColumnName("characterId")
                .HasColumnType("int(11)");

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

            builder.HasOne(d => d.Character)
                .WithMany()
                .HasForeignKey(d => d.CharacterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_C2316E125AF690F3");

            builder.HasOne(d => d.CharacterSource)
                .WithMany()
                .HasForeignKey(d => d.CharacterSourceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_C2316E122CDD71BB");
        }
    }
}
