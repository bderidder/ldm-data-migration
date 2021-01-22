using LaDanse.Source.Entities.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LaDanse.Source.MySql.Configurations.Events
{
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.ToTable("Event");

            builder.HasIndex(e => e.OrganiserId)
                .HasDatabaseName("IDX_FA6F25A34BDD3C8");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .HasColumnType("int(11)");

            builder.Property(e => e.Description)
                .HasColumnName("description")
                .HasColumnType("longtext")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_unicode_ci");

            builder.Property(e => e.EndTime)
                .HasColumnName("endTime")
                .HasColumnType("datetime")
                .HasComment("(DC2Type:datetime)");

            builder.Property(e => e.InviteTime)
                .HasColumnName("inviteTime")
                .HasColumnType("datetime")
                .HasComment("(DC2Type:datetime)");

            builder.Property(e => e.LastModifiedTime)
                .HasColumnName("lastModifiedTime")
                .HasColumnType("datetime");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasColumnName("name")
                .HasColumnType("varchar(100)")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_unicode_ci");

            builder.Property(e => e.OrganiserId)
                .HasColumnName("organiserId")
                .HasColumnType("int(11)");

            builder.Property(e => e.StartTime)
                .HasColumnName("startTime")
                .HasColumnType("datetime")
                .HasComment("(DC2Type:datetime)");

            builder.Property(e => e.State)
                .IsRequired()
                .HasColumnName("state")
                .HasColumnType("varchar(100)")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_unicode_ci");

            builder.Property(e => e.CommentGroupId)
                .IsRequired()
                .HasColumnName("topicId")
                .HasColumnType("longtext")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_unicode_ci");

            builder.HasOne(d => d.Organiser)
                .WithMany()
                .HasForeignKey(d => d.OrganiserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FA6F25A34BDD3C8");

            builder.HasOne(d => d.CommentGroup)
                .WithMany()
                .HasForeignKey(d => d.CommentGroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FA6F25A34BDD4B9");
        }
    }
}