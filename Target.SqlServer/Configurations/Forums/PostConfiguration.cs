using LaDanse.Target.Entities.Forums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Target.SqlServer.Configurations.Forums
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

            builder.HasGuidKey();

            builder.Property(e => e.Content)
                .IsRequired()
                .HasColumnName("content")
                .HasUtf8ColumnType(SqlServerBuilderTypes.LongText);

            builder.Property(e => e.PostDate)
                .IsRequired()
                .HasColumnName("postDate")
                .HasColumnType(SqlServerBuilderTypes.DateTime);

            builder.Property(e => e.PosterId)
                .IsRequired()
                .HasColumnName("posterId")
                .HasComment(SqlServerBuilderTypes.ForeignKey);
            builder.HasOne(d => d.Poster)
                .WithMany()
                .HasForeignKey(d => d.PosterId)
                .HasConstraintName("FK_FAB8C3B3581A197");

            builder.Property(e => e.TopicId)
                .IsRequired()
                .HasColumnName("topicId")
                .HasComment(SqlServerBuilderTypes.ForeignKey);
            builder.HasOne(d => d.Topic)
                .WithMany()
                .HasForeignKey(d => d.TopicId)
                .HasConstraintName("FK_FAB8C3B3E2E0EAFB");
        }
    }
}