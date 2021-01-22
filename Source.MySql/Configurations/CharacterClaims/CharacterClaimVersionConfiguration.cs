using LaDanse.Source.Entities.CharacterClaims;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LaDanse.Source.MySql.Configurations.CharacterClaims
{
    public class CharacterClaimVersionConfiguration : IEntityTypeConfiguration<CharacterClaimVersion>
    {
        public void Configure(EntityTypeBuilder<CharacterClaimVersion> builder)
        {
            builder.ToTable("CharacterClaimVersion");

            builder.HasIndex(e => e.CharacterClaimId)
                .HasDatabaseName("IDX_C33F42E09113A92D");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .HasColumnType("int(11)");

            builder.Property(e => e.CharacterClaimId)
                .HasColumnName("claimId")
                .HasColumnType("int(11)");

            builder.Property(e => e.Comment)
                .HasColumnName("comment")
                .HasColumnType("text")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_unicode_ci");

            builder.Property(e => e.EndTime)
                .HasColumnName("endTime")
                .HasColumnType("datetime");

            builder.Property(e => e.FromTime)
                .HasColumnName("fromTime")
                .HasColumnType("datetime");

            builder.Property(e => e.Raider).HasColumnName("raider");

            builder.HasOne(d => d.CharacterClaim)
                .WithMany()
                .HasForeignKey(d => d.CharacterClaimId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_C33F42E09113A92D");
        }
    }
}
