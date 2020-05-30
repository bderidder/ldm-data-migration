using LaDanse.Source.Entities.CharacterClaims;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LaDanse.Source.Configurations.CharacterClaims
{
    public class CharacterClaimConfiguration : IEntityTypeConfiguration<CharacterClaim>
    {
        public void Configure(EntityTypeBuilder<CharacterClaim> builder)
        {
            builder.ToTable("CharacterClaim");

            builder.HasIndex(e => e.AccountId)
                .HasName("IDX_E115ED7862DEB3E8");

            builder.HasIndex(e => e.CharacterId)
                .HasName("IDX_E115ED785AF690F3");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .HasColumnType("int(11)");

            builder.Property(e => e.AccountId)
                .HasColumnName("accountId")
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

            builder.HasOne(d => d.Account)
                .WithMany()
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_E115ED7862DEB3E8");

            builder.HasOne(d => d.Character)
                .WithMany()
                .HasForeignKey(d => d.CharacterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_E115ED785AF690F3");
        }
    }
}
