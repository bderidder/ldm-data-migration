using LaDanse.Target.Entities.GameData.Sync.Profile;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LaDanse.Target.Configurations.GameData.Sync.Profile
{
    public class ProfileSyncConfiguration : IEntityTypeConfiguration<ProfileSync>
    {
        public void Configure(EntityTypeBuilder<ProfileSync> builder)
        {
            builder.HasIndex(e => e.UserId)
                .HasName("IDX_70D670C87D3656A4");

            builder.Property(e => e.UserId)
                .HasColumnName("userId")
                .HasForeignKeyColumnType();
            builder.HasOne(d => d.User)
                .WithMany()
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_70D670C87D3656A4");
        }
    }
}
