using LaDanse.Source.Entities.GameData.Characters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LaDanse.Source.MySql.Configurations.GameData.Characters
{
    public class GuildCharacterConfiguration : IEntityTypeConfiguration<GuildCharacter>
    {
        public void Configure(EntityTypeBuilder<GuildCharacter> builder)
        {
            builder.ToTable("GuildCharacter");

            builder.HasIndex(e => e.RealmId)
                .HasDatabaseName("IDX_92AF3B34FA96DBDA");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .HasColumnType("int(11)");

            builder.Property(e => e.EndTime)
                .HasColumnName("endTime")
                .HasColumnType("datetime");

            builder.Property(e => e.FromTime)
                .HasColumnName("fromTime")
                .HasColumnType("datetime");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasColumnName("name")
                .HasColumnType("varchar(255)")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_unicode_ci");

            builder.Property(e => e.RealmId)
                .HasColumnName("realm")
                .HasComment("(DC2Type:guid)")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_unicode_ci");

            builder.HasOne(d => d.Realm)
                .WithMany()
                .HasForeignKey(d => d.RealmId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_92AF3B34FA96DBDA");
        }
    }
}
