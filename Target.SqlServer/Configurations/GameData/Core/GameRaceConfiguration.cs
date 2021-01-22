using LaDanse.Target.Entities.GameData.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Target.SqlServer.Configurations.GameData.Core
{
    public class GameRaceConfiguration : IEntityTypeConfiguration<GameRace>
    {
        public void Configure(EntityTypeBuilder<GameRace> builder)
        {
            builder.ToTable("GameRace");

            builder.HasIndex(e => e.GameFactionId)
                .HasDatabaseName("IDX_D51A7CF883048B90");

            builder.HasGuidKey();

            builder.Property(e => e.GameId)
                .IsRequired()
                .HasColumnName("gameId")
                .HasColumnType(SqlServerBuilderTypes.UnsignedInt);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasColumnName("name")
                .HasUtf8ColumnType((SqlServerBuilderTypes.String(20)));

            builder.Property(e => e.GameFactionId)
                .HasColumnName("gameFactionId")
                .HasForeignKeyColumnType();
            builder.HasOne(d => d.GameFaction)
                .WithMany()
                .HasForeignKey(d => d.GameFactionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_D51A7CF883048B90");
        }
    }
}