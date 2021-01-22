using LaDanse.Target.Entities.Forums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Target.SqlServer.Configurations.Forums
{
    public class TopicConfiguration : IEntityTypeConfiguration<Topic>
    {
        public void Configure(EntityTypeBuilder<Topic> builder)
        {
            builder.ToTable("Topic");

            builder.HasIndex(e => e.ForumId)
                .HasDatabaseName("IDX_5C81F11F7830F151");

            builder.HasIndex(e => e.LastPostPosterId)
                .HasDatabaseName("IDX_5C81F11F22F0147C");

            builder.HasIndex(e => e.PosterId)
                .HasDatabaseName("IDX_5C81F11F581A197");

            builder.HasGuidKey();
            
            builder.Property(e => e.LastPostDate)
                .HasColumnName("lastPostDate")
                .HasColumnType(SqlServerBuilderTypes.DateTime);

            builder.Property(e => e.PostDate)
                .HasColumnName("postDate")
                .HasColumnType(SqlServerBuilderTypes.DateTime);

            builder.Property(e => e.Subject)
                .IsRequired()
                .HasColumnName("subject")
                .HasUtf8ColumnType(SqlServerBuilderTypes.String(255));

            builder.Property(e => e.ForumId)
                .HasColumnName("forumId")
                .HasForeignKeyColumnType();
            builder.HasOne(d => d.Forum)
                .WithMany()
                .HasForeignKey(d => d.ForumId)
                .HasConstraintName("FK_5C81F11F7830F151");

            builder.Property(e => e.LastPostPosterId)
                .HasColumnName("lastPostPosterId")
                .HasForeignKeyColumnType();
            builder.HasOne(d => d.LastPostPoster)
                .WithMany()
                .HasForeignKey(d => d.LastPostPosterId)
                .HasConstraintName("FK_5C81F11F22F0147C");

            builder.Property(e => e.PosterId)
                .HasColumnName("posterId")
                .HasForeignKeyColumnType();
            builder.HasOne(d => d.Poster)
                .WithMany()
                .HasForeignKey(d => d.PosterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_5C81F11F581A197");
        }
    }
}