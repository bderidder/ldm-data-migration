using LaDanse.Target.Entities.GameData.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Target.SqlServer.Configurations.GameData.Core
{
    public class GameClassConfiguration : IEntityTypeConfiguration<GameClass>
    {
        public void Configure(EntityTypeBuilder<GameClass> builder)
        {
            builder.ToTable("GameClass");

            builder.HasGuidKey();

            builder.Property(e => e.GameId)
                .HasColumnName("gameId")
                .HasColumnType(SqlServerBuilderTypes.UnsignedInt);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasColumnName("name")
                .HasUtf8ColumnType(SqlServerBuilderTypes.String(20));
        }
    }
}
