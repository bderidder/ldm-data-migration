using LaDanse.Source.Entities.Queues;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LaDanse.Source.MySql.Configurations.Queues
{
    public class NotificationQueueItemConfiguration : IEntityTypeConfiguration<NotificationQueueItem>
    {
        public void Configure(EntityTypeBuilder<NotificationQueueItem> builder)
        {
            builder.ToTable("NotificationQueueItem");

            builder.HasIndex(e => e.ActivityById)
                .HasDatabaseName("IDX_C656D44393C757EE");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .HasColumnType("int(11)");

            builder.Property(e => e.ActivityById)
                .HasColumnName("activityBy")
                .HasColumnType("int(11)");

            builder.Property(e => e.ActivityOn)
                .HasColumnName("activityOn")
                .HasColumnType("datetime");

            builder.Property(e => e.ActivityType)
                .IsRequired()
                .HasColumnName("activityType")
                .HasColumnType("varchar(255)")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_unicode_ci");

            builder.Property(e => e.ProcessedOn)
                .HasColumnName("processedOn")
                .HasColumnType("datetime");

            builder.Property(e => e.RawData)
                .HasColumnName("rawData")
                .HasColumnType("longtext")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_unicode_ci");

            builder.HasOne(d => d.ActivityBy)
                .WithMany()
                .HasForeignKey(d => d.ActivityById)
                .HasConstraintName("FK_C656D44393C757EE");
        }
    }
}
