using LaDanse.Target.Entities.Telemetry;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Target.SqlServer.Configurations.Telemetry
{
    public class FeatureUseConfiguration : IEntityTypeConfiguration<FeatureUse>
    {
        public void Configure(EntityTypeBuilder<FeatureUse> builder)
        {
            builder.ToTable("FeatureUse");   

            builder.HasIndex(e => e.UsedById)
                .HasDatabaseName("IDX_E504F432FCEF271C");

            builder.HasGuidKey();

            builder.Property(e => e.Feature)
                .IsRequired()
                .HasColumnName("feature")
                .HasUtf8ColumnType(SqlServerBuilderTypes.String(255));

            builder.Property(e => e.RawData)
                .HasColumnName("rawData")
                .HasUtf8ColumnType(SqlServerBuilderTypes.LongText);

            builder.Property(e => e.UsedOn)
                .HasColumnName("usedOn")
                .HasColumnType(SqlServerBuilderTypes.DateTime);

            builder.Property(e => e.UsedById)
                .HasColumnName("usedById")
                .HasForeignKeyColumnType();
            builder.HasOne(d => d.UsedBy)
                .WithMany()
                .HasForeignKey(d => d.UsedById)
                .HasConstraintName("FK_E504F432FCEF271C");
        }
    }
}
