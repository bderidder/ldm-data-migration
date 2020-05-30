using LaDanse.Source.Entities.Forums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LaDanse.Source.Configurations.Forums
{
    public class TopicConfiguration : IEntityTypeConfiguration<Topic>
    {
        public void Configure(EntityTypeBuilder<Topic> builder)
        {
            builder.ToTable("Topic");

            builder.HasIndex(e => e.ForumId)
                .HasName("IDX_5C81F11F7830F151");

            builder.HasIndex(e => e.LastPostPosterId)
                .HasName("IDX_5C81F11F22F0147C");

            builder.HasIndex(e => e.PosterId)
                .HasName("IDX_5C81F11F581A197");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("topicId")
                .HasComment("(DC2Type:guid)")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_unicode_ci");

            builder.Property(e => e.ForumId)
                .HasColumnName("forumId")
                .HasComment("(DC2Type:guid)")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_unicode_ci");

            builder.Property(e => e.LastPostDate)
                .HasColumnName("lastPostDate")
                .HasColumnType("datetime");

            builder.Property(e => e.LastPostPosterId)
                .HasColumnName("lastPostPoster")
                .HasColumnType("int(11)");

            builder.Property(e => e.PostDate)
                .HasColumnName("postDate")
                .HasColumnType("datetime");

            builder.Property(e => e.PosterId)
                .HasColumnName("posterId")
                .HasColumnType("int(11)");

            builder.Property(e => e.Subject)
                .IsRequired()
                .HasColumnName("subject")
                .HasColumnType("varchar(255)")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_unicode_ci");

            builder.HasOne(d => d.Forum)
                .WithMany()
                .HasForeignKey(d => d.ForumId)
                .HasConstraintName("FK_5C81F11F7830F151");

            builder.HasOne(d => d.LastPostPoster)
                .WithMany()
                .HasForeignKey(d => d.LastPostPosterId)
                .HasConstraintName("FK_5C81F11F22F0147C");

            builder.HasOne(d => d.Poster)
                .WithMany()
                .HasForeignKey(d => d.PosterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_5C81F11F581A197");
        }
    }
}