using LaDanse.Source.Entities.Forums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LaDanse.Source.Configurations.Forums
{
    public class ForumConfiguration : IEntityTypeConfiguration<Forum>
    {
        public void Configure(EntityTypeBuilder<Forum> builder)
        {
            builder.ToTable("Forum");

                builder.HasIndex(e => e.LastPostPosterId)
                    .HasName("IDX_44EA91C922F0147C");

                builder.HasIndex(e => e.LastPostTopicId)
                    .HasName("IDX_44EA91C91CA16452");

                builder.HasKey(e => e.Id);

                builder.Property(e => e.Id)
                    .HasColumnName("forumId")
                    .HasComment("(DC2Type:guid)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                builder.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasColumnType("longtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                builder.Property(e => e.LastPostDate)
                    .HasColumnName("lastPostDate")
                    .HasColumnType("datetime");

                builder.Property(e => e.LastPostPosterId)
                    .HasColumnName("lastPostPoster")
                    .HasColumnType("int(11)");

                builder.Property(e => e.LastPostTopicId)
                    .HasColumnName("lastPostTopic")
                    .HasComment("(DC2Type:guid)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                builder.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("longtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                builder.HasOne(d => d.LastPostPoster)
                    .WithMany()
                    .HasForeignKey(d => d.LastPostPosterId)
                    .HasConstraintName("FK_44EA91C922F0147C");

                builder.HasOne(d => d.LastPostTopic)
                    .WithMany()
                    .HasForeignKey(d => d.LastPostTopicId)
                    .HasConstraintName("FK_44EA91C91CA16452");
        }
    }
}
