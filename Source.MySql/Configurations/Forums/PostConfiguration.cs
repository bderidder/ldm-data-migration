using LaDanse.Source.Entities.Forums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LaDanse.Source.MySql.Configurations.Forums
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("Post");

            builder.HasIndex(e => e.PosterId)
                .HasDatabaseName("IDX_FAB8C3B3581A197");

            builder.HasIndex(e => e.TopicId)
                .HasDatabaseName("IDX_FAB8C3B3E2E0EAFB");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("postId")
                .HasComment("(DC2Type:guid)")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_unicode_ci");

            builder.Property(e => e.Message)
                .IsRequired()
                .HasColumnName("message")
                .HasColumnType("longtext")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_unicode_ci");

            builder.Property(e => e.PostDate)
                .HasColumnName("postDate")
                .HasColumnType("datetime");

            builder.Property(e => e.PosterId)
                .HasColumnName("posterId")
                .HasColumnType("int(11)");

            builder.Property(e => e.TopicId)
                .HasColumnName("topicId")
                .HasComment("(DC2Type:guid)")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_unicode_ci");

            builder.HasOne(d => d.Poster)
                .WithMany()
                .HasForeignKey(d => d.PosterId)
                .HasConstraintName("FK_FAB8C3B3581A197");

            builder.HasOne(d => d.Topic)
                .WithMany()
                .HasForeignKey(d => d.TopicId)
                .HasConstraintName("FK_FAB8C3B3E2E0EAFB");
        }
    }
}
