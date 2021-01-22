using LaDanse.Source.Entities.Comments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LaDanse.Source.MySql.Configurations.Comments
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comment");

            builder.HasIndex(e => e.GroupId)
                .HasDatabaseName("IDX_5BC96BF0ED8188B0");

            builder.HasIndex(e => e.PosterId)
                .HasDatabaseName("IDX_5BC96BF0581A197");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("commentId")
                .HasColumnType("char(36)")
                .HasComment("(DC2Type:guid)")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_unicode_ci");

            builder.Property(e => e.GroupId)
                .HasColumnName("groupId")
                .HasColumnType("char(36)")
                //.HasComment("(DC2Type:guid)")
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

            builder.HasOne(d => d.Group)
                .WithMany()
                .HasForeignKey(d => d.GroupId)
                .HasConstraintName("FK_5BC96BF0ED8188B0");

            builder.HasOne(d => d.Poster)
                .WithMany()
                .HasForeignKey(d => d.PosterId)
                .HasConstraintName("FK_5BC96BF0581A197");
        }
    }
}
