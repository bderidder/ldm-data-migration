using LaDanse.Target.Entities.GameData.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Target.SqlServer.Configurations.GameData.Core
{
    public class GameFactionConfiguration : IEntityTypeConfiguration<GameFaction>
    {
        public void Configure(EntityTypeBuilder<GameFaction> builder)
        {
            builder.ToTable("GameFaction");

            builder.HasGuidKey();

            builder.Property(e => e.GameId)
                .IsRequired()
                .HasColumnName("gameId")
                .HasColumnType(SqlServerBuilderTypes.UnsignedInt);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasColumnName("name")
                .HasUtf8ColumnType(SqlServerBuilderTypes.String(20));
        }
    }
}
