using LaDanse.Source.Entities.GameData.Sync.Profile;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LaDanse.Source.Configurations.GameData.Sync.Profile
{
    public class ProfileSyncConfiguration : IEntityTypeConfiguration<ProfileSync>
    {
        public void Configure(EntityTypeBuilder<ProfileSync> builder)
        {
            builder.ToTable("WoWProfileSync");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .HasComment("(DC2Type:guid)")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_unicode_ci");

            builder.HasIndex(e => e.AccountId)
                .HasName("IDX_70D670C87D3656A4");

            builder.Property(e => e.AccountId)
                .HasColumnName("account")
                .HasColumnType("int(11)");

            builder.HasOne(d => d.Account)
                .WithMany()
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_70D670C87D3656A4");
        }
    }
}
