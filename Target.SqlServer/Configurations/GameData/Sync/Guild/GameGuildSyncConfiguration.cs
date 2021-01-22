using LaDanse.Target.Entities.GameData.Sync.Guild;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Target.SqlServer.Configurations.GameData.Sync.Guild
{
    public class GameGuildSyncConfiguration : IEntityTypeConfiguration<GameGuildSync>
    {
        public void Configure(EntityTypeBuilder<GameGuildSync> builder)
        {
            builder.HasIndex(e => e.GameGuildId)
                .HasDatabaseName("IDX_18BD775675407DAB");

            builder.Property(e => e.GameGuildId)
                .HasColumnName("gameGuildId")
                .HasColumnType((SqlServerBuilderTypes.ForeignKey));
            builder.HasOne(d => d.GameGuild)
                .WithMany()
                .HasForeignKey(d => d.GameGuildId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_18BD775675407DAB");
        }
    }
}