using LaDanse.Target.Entities.CharacterClaims;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Target.SqlServer.Configurations.CharacterClaims
{
    public class CharacterClaimVersionConfiguration : IEntityTypeConfiguration<GameCharacterClaimVersion>
    {
        public void Configure(EntityTypeBuilder<GameCharacterClaimVersion> builder)
        {
            builder.ToTable("GameCharacterClaimVersion");

            builder.HasIndex(e => e.GameCharacterClaimId)
                .HasDatabaseName("IDX_C33F42E09113A92D");
            
            builder.HasGuidKey();
            
            builder.TimeVersioned();

            builder.Property(e => e.Comment)
                .HasColumnName("comment")
                .HasUtf8ColumnType(SqlServerBuilderTypes.Text);

            builder.Property(e => e.IsRaider)
                .IsRequired()
                .HasColumnName("isRaider");

            builder.Property(e => e.GameCharacterClaimId)
                .HasColumnName("gameCharacterClaimId")
                .HasForeignKeyColumnType();
            builder.HasOne(d => d.GameCharacterClaim)
                .WithMany()
                .HasForeignKey(d => d.GameCharacterClaimId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_C33F42E09113A92D");
        }
    }
}
