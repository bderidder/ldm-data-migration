﻿using LaDanse.Target.Entities.Forums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Target.SqlServer.Configurations.Forums
{
    public class ForumLastVisitConfiguration : IEntityTypeConfiguration<ForumLastVisit>
    {
        public void Configure(EntityTypeBuilder<ForumLastVisit> builder)
        {
            builder.ToTable("ForumLastVisit");

            builder.HasIndex(e => e.UserId)
                .HasDatabaseName("IDX_F17408662DEB3E8");

            builder.HasGuidKey();

            builder.Property(e => e.LastVisitDate)
                .HasColumnName("lastVisitDate")
                .HasColumnType(SqlServerBuilderTypes.DateTime);

            builder.Property(e => e.UserId)
                .HasColumnName("userId")
                .HasForeignKeyColumnType();
            builder.HasOne(d => d.User)
                .WithMany()
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_F17408662DEB3E8");
        }
    }
}