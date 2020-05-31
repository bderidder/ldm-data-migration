using LaDanse.Source.Entities.CharacterClaims;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LaDanse.Source.Configurations.CharacterClaims
{
    public class PlaysRoleConfiguration : IEntityTypeConfiguration<StringPlaysRole>
    {
        public void Configure(EntityTypeBuilder<StringPlaysRole> builder)
        {
            builder.ToTable("PlaysRole");

            builder.HasIndex(e => e.CharacterClaimId)
                .HasName("IDX_7A9E9B239113A92D");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .HasColumnType("int(11)");

            builder.Property(e => e.CharacterClaimId)
                .HasColumnName("claimId")
                .HasColumnType("int(11)");

            builder.Property(e => e.EndTime)
                .HasColumnName("endTime")
                .HasColumnType("datetime");

            builder.Property(e => e.FromTime)
                .HasColumnName("fromTime")
                .HasColumnType("datetime");

            builder.Property(e => e.Role)
                .IsRequired()
                .HasColumnName("role")
                .HasColumnType("varchar(15)")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_unicode_ci");

            builder.HasOne(d => d.CharacterClaim)
                .WithMany()
                .HasForeignKey(d => d.CharacterClaimId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_7A9E9B239113A92D");
        }
    }
}