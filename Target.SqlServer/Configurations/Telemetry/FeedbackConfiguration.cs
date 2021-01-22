using LaDanse.Target.Entities.Telemetry;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Target.SqlServer.Configurations.Telemetry
{
    public class FeedbackConfiguration : IEntityTypeConfiguration<Feedback>
    {
        public void Configure(EntityTypeBuilder<Feedback> builder)
        {
            builder.ToTable("Feedback");

            builder.HasIndex(e => e.PostedById)
                .HasDatabaseName("IDX_2B5F260E9DD8CB47");

            builder.HasGuidKey();

            builder.Property(e => e.Content)
                .IsRequired()
                .HasColumnName("feedback")
                .HasUtf8ColumnType(SqlServerBuilderTypes.LongText);

            builder.Property(e => e.PostedOn)
                .IsRequired()
                .HasColumnName("postedOn")
                .HasColumnType(SqlServerBuilderTypes.DateTime);

            builder.Property(e => e.PostedById)
                .HasColumnName("postedById")
                .HasForeignKeyColumnType();
            builder.HasOne(d => d.PostedBy)
                .WithMany()
                .HasForeignKey(d => d.PostedById)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_2B5F260E9DD8CB47");
        }
    }
}
