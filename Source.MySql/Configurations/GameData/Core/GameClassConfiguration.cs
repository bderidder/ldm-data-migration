using LaDanse.Source.Entities.GameData.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LaDanse.Source.MySql.Configurations.GameData.Core
{
    public class GameClassConfiguration : IEntityTypeConfiguration<GameClass>
    {
        public void Configure(EntityTypeBuilder<GameClass> builder)
        {
            builder.ToTable("GameClass");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .HasComment("(DC2Type:guid)")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_unicode_ci");

            builder.Property(e => e.GameId)
                .HasColumnName("armoryId")
                .HasColumnType("int(11)");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasColumnName("name")
                .HasColumnType("varchar(20)")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_unicode_ci");
        }
    }
}
