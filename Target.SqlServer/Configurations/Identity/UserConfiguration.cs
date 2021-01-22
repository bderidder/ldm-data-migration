using LaDanse.Target.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Target.SqlServer.Configurations.Identity
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder.HasIndex(e => e.DisplayName)
                .HasDatabaseName("UNIQ_B28B6F38A0D96FBF")
                .IsUnique();

            builder.HasIndex(e => e.Email)
                .HasDatabaseName("UNIQ_B28B6F3892FC23A8")
                .IsUnique();

            builder.HasGuidKey();

            builder.Property(e => e.DisplayName)
                .IsRequired()
                .HasColumnName("displayName")
                .HasUtf8ColumnType(SqlServerBuilderTypes.String(35));

            builder.Property(e => e.Email)
                .IsRequired()
                .HasColumnName("email")
                .HasUtf8ColumnType(SqlServerBuilderTypes.String(180));

            builder.Property(e => e.LastLogin)
                .HasColumnName("lastLogin")
                .HasColumnType(SqlServerBuilderTypes.DateTime);

            builder.Property(e => e.Salt)
                .HasColumnName("salt")
                .HasUtf8ColumnType(SqlServerBuilderTypes.String(255));

            builder.Property(e => e.Password)
                .IsRequired()
                .HasColumnName("password")
                .HasUtf8ColumnType(SqlServerBuilderTypes.String(2048));
        }
    }
}