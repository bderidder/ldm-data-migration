using LaDanse.Source.Entities.GameData.Characters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LaDanse.Source.MySql.Configurations.GameData.Characters
{
    public class InGuildConfiguration : IEntityTypeConfiguration<InGuild>
    {
        public void Configure(EntityTypeBuilder<InGuild> builder)
        {
            builder.ToTable("InGuild");

            builder.HasIndex(e => e.CharacterId)
                .HasDatabaseName("IDX_CA2244C5AF690F3");

            builder.HasIndex(e => e.GuildId)
                .HasDatabaseName("IDX_CA2244C75407DAB");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .HasComment("(DC2Type:guid)")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_unicode_ci");

            builder.Property(e => e.CharacterId)
                .HasColumnName("characterId")
                .HasColumnType("int(11)");

            builder.Property(e => e.EndTime)
                .HasColumnName("endTime")
                .HasColumnType("datetime");

            builder.Property(e => e.FromTime)
                .HasColumnName("fromTime")
                .HasColumnType("datetime");

            builder.Property(e => e.GuildId)
                .HasColumnName("guild")
                .HasComment("(DC2Type:guid)")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_unicode_ci");

            builder.HasOne(d => d.Character)
                .WithMany()
                .HasForeignKey(d => d.CharacterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CA2244C5AF690F3");

            builder.HasOne(d => d.Guild)
                .WithMany()
                .HasForeignKey(d => d.GuildId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CA2244C75407DAB");
        }
    }
}
