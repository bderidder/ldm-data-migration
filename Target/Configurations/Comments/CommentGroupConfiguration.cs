using LaDanse.Target.Entities.Comments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LaDanse.Target.Configurations.Comments
{
    public class CommentGroupConfiguration : IEntityTypeConfiguration<CommentGroup>
    {
        public void Configure(EntityTypeBuilder<CommentGroup> builder)
        {
            builder.ToTable("CommentGroup");

            builder.HasGuidKey();
            
            builder.Property(e => e.PostDate)
                .HasColumnName("postDate")
                .HasColumnType(MySqlBuilderTypes.DateTime);
        }
    }
}
