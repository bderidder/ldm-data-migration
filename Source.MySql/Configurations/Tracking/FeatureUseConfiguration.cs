using LaDanse.Source.Entities.Telemetry;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LaDanse.Source.MySql.Configurations.Tracking
{
    public class FeatureUseConfiguration : IEntityTypeConfiguration<FeatureUse>
    {
        public void Configure(EntityTypeBuilder<FeatureUse> builder)
        {
            builder.ToTable("FeatureUse");   

            builder.HasIndex(e => e.UsedById)
                .HasDatabaseName("IDX_E504F432FCEF271C");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .HasColumnType("int(11)");

            builder.Property(e => e.Feature)
                .IsRequired()
                .HasColumnName("feature")
                .HasColumnType("varchar(255)")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_unicode_ci");

            builder.Property(e => e.RawData)
                .HasColumnName("rawData")
                .HasColumnType("longtext")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_unicode_ci");

            builder.Property(e => e.UsedById)
                .HasColumnName("usedBy")
                .HasColumnType("int(11)");

            builder.Property(e => e.UsedOn)
                .HasColumnName("usedOn")
                .HasColumnType("datetime");

            builder.HasOne(d => d.UsedBy)
                .WithMany()
                .HasForeignKey(d => d.UsedById)
                .HasConstraintName("FK_E504F432FCEF271C");
        }
    }
}
