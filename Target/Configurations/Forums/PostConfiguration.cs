using LaDanse.Target.Entities.Forums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LaDanse.Target.Configurations.Forums
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("Post");

            builder.HasIndex(e => e.PosterId)
                .HasName("IDX_FAB8C3B3581A197");

            builder.HasIndex(e => e.TopicId)
                .HasName("IDX_FAB8C3B3E2E0EAFB");

            builder.HasGuidKey();

            builder.Property(e => e.Message)
                .IsRequired()
                .HasColumnName("message")
                .HasUtf8ColumnType(MySqlBuilderTypes.String(8192));

            builder.Property(e => e.PostDate)
                .IsRequired()
                .HasColumnName("postDate")
                .HasColumnType(MySqlBuilderTypes.DateTime);

            builder.Property(e => e.PosterId)
                .IsRequired()
                .HasColumnName("posterId")
                .HasComment(MySqlBuilderTypes.ForeignKey);
            builder.HasOne(d => d.Poster)
                .WithMany()
                .HasForeignKey(d => d.PosterId)
                .HasConstraintName("FK_FAB8C3B3581A197");

            builder.Property(e => e.TopicId)
                .IsRequired()
                .HasColumnName("topicId")
                .HasComment(MySqlBuilderTypes.ForeignKey);
            builder.HasOne(d => d.Topic)
                .WithMany()
                .HasForeignKey(d => d.TopicId)
                .HasConstraintName("FK_FAB8C3B3E2E0EAFB");
        }
    }
}