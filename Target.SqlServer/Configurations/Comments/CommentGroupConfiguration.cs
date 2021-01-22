﻿using LaDanse.Target.Entities.Comments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Target.SqlServer.Configurations.Comments
{
    public class CommentGroupConfiguration : IEntityTypeConfiguration<CommentGroup>
    {
        public void Configure(EntityTypeBuilder<CommentGroup> builder)
        {
            builder.ToTable("CommentGroup");

            builder.HasGuidKey();
            
            builder.Property(e => e.PostDate)
                .HasColumnName("postDate")
                .HasColumnType(SqlServerBuilderTypes.DateTime);
        }
    }
}
