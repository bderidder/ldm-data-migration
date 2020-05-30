using LaDanse.Target.Entities.CharacterClaims;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LaDanse.Target.Configurations.CharacterClaims
{
    public class CharacterClaimConfiguration : IEntityTypeConfiguration<GameCharacterClaim>
    {
        public void Configure(EntityTypeBuilder<GameCharacterClaim> builder)
        {
            builder.ToTable("GameCharacterClaim");

            builder.HasIndex(e => e.UserId)
                .HasName("IDX_E115ED7862DEB3E8");
            builder.HasIndex(e => e.GameCharacterId)
                .HasName("IDX_E115ED785AF690F3");
            
            builder.HasGuidKey();
            
            builder.TimeVersioned();

            builder.Property(e => e.UserId)
                .HasColumnName("userId")
                .HasForeignKeyColumnType();
            builder.HasOne(d => d.User)
                .WithMany()
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_E115ED7862DEB3E8");

            builder.Property(e => e.GameCharacterId)
                .HasColumnName("gameCharacterId")
                .HasForeignKeyColumnType();
            builder.HasOne(d => d.GameCharacter)
                .WithMany()
                .HasForeignKey(d => d.GameCharacterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_E115ED785AF690F3");
        }
    }
}
