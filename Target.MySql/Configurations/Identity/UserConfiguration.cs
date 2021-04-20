﻿using LaDanse.Target.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LaDanse.Target.MySql.Configurations.Identity
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder.HasIndex(e => e.ExternalId)
                .HasDatabaseName("UNIQ_B28B6F38C05FB297")
                .IsUnique();

            builder.HasIndex(e => e.DisplayName)
                .HasDatabaseName("UNIQ_B28B6F38A0D96FBF")
                .IsUnique();

            builder.HasIndex(e => e.Email)
                .HasDatabaseName("UNIQ_B28B6F3892FC23A8")
                .IsUnique();

            builder.HasGuidKey();
            
            builder.Property(e => e.ExternalId)
                .HasColumnName("externalId")
                .HasUtf8ColumnType(MySqlBuilderTypes.String(127));

            builder.Property(e => e.DisplayName)
                .IsRequired()
                .HasColumnName("displayName")
                .HasUtf8ColumnType(MySqlBuilderTypes.String(35));

            builder.Property(e => e.Email)
                .IsRequired()
                .HasColumnName("email")
                .HasUtf8ColumnType(MySqlBuilderTypes.String(180));

            builder.Property(e => e.DisplayNameByUser)
                .IsRequired()
                .HasColumnName("displayNameByUser");
        }
    }
}