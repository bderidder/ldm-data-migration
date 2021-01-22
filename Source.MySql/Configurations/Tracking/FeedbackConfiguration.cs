using LaDanse.Source.Entities.Telemetry;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LaDanse.Source.MySql.Configurations.Tracking
{
    public class FeedbackConfiguration : IEntityTypeConfiguration<Feedback>
    {
        public void Configure(EntityTypeBuilder<Feedback> builder)
        {
            builder.ToTable("Feedback");

            builder.HasIndex(e => e.PostedById)
                .HasDatabaseName("IDX_2B5F260E9DD8CB47");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .HasColumnType("int(11)");

            builder.Property(e => e.Content)
                .IsRequired()
                .HasColumnName("feedback")
                .HasColumnType("longtext")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_unicode_ci");

            builder.Property(e => e.PostedById)
                .HasColumnName("postedBy")
                .HasColumnType("int(11)");

            builder.Property(e => e.PostedOn)
                .HasColumnName("postedOn")
                .HasColumnType("datetime");

            builder.HasOne(d => d.PostedBy)
                .WithMany()
                .HasForeignKey(d => d.PostedById)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_2B5F260E9DD8CB47");
        }
    }
}
