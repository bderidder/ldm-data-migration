using LaDanse.Source.Entities.Comments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LaDanse.Source.MySql.Configurations.Comments
{
    public class CommentGroupConfiguration : IEntityTypeConfiguration<CommentGroup>
    {
        public void Configure(EntityTypeBuilder<CommentGroup> builder)
        {
            builder.ToTable("CommentGroup");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("groupId")
                .HasColumnType("char(36)")
                .HasComment("(DC2Type:guid)")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_unicode_ci");

            builder.Property(e => e.PostDate)
                .HasColumnName("postDate")
                .HasColumnType("datetime");
        }
    }
}
