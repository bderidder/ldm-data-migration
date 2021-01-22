using LaDanse.Target.Entities.GameData.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Target.SqlServer.Configurations.GameData.Core
{
    public class GameRealmConfiguration : IEntityTypeConfiguration<GameRealm>
    {
        public void Configure(EntityTypeBuilder<GameRealm> builder)
        {
            builder.ToTable("GameRealm");

            builder.HasGuidKey();

            builder.Property(e => e.GameId)
                .IsRequired()
                .HasColumnName("gameId")
                .HasColumnType(SqlServerBuilderTypes.UnsignedInt);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasColumnName("name")
                .HasUtf8ColumnType(SqlServerBuilderTypes.String(100));
        }
    }
}