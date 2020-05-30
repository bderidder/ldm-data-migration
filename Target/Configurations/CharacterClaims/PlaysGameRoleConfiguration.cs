using LaDanse.Target.Entities.CharacterClaims;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LaDanse.Target.Configurations.CharacterClaims
{
    public class PlaysGameRoleConfiguration : IEntityTypeConfiguration<PlaysGameRole>
    {
        public void Configure(EntityTypeBuilder<PlaysGameRole> builder)
        {
            builder.ToTable("PlaysGameRole");

            builder.HasIndex(e => e.GameCharacterClaimId)
                .HasName("IDX_7A9E9B239113A92D");

            builder.HasGuidKey();
            
            builder.TimeVersioned();

            builder.Property(e => e.GameRole)
                .IsRequired()
                .HasColumnName("gameRole")
                .HasColumnType(MySqlBuilderTypes.Enum);

            builder.Property(e => e.GameCharacterClaimId)
                .HasColumnName("gameCharacterClaimId")
                .HasForeignKeyColumnType();
            builder.HasOne(d => d.GameCharacterClaim)
                .WithMany()
                .HasForeignKey(d => d.GameCharacterClaimId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_7A9E9B239113A92D");
        }
    }
}