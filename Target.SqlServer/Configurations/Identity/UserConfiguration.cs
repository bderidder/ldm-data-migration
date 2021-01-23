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

            builder.HasIndex(e => e.NormalizedEmail)
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
                .HasUtf8ColumnType(SqlServerBuilderTypes.String(255));
            
            builder.Property(e => e.NormalizedEmail)
                .IsRequired()
                .HasColumnName("normalizedEmail")
                .HasUtf8ColumnType(SqlServerBuilderTypes.String(255));

            builder.Property(e => e.LastLogin)
                .HasColumnName("lastLogin")
                .HasColumnType(SqlServerBuilderTypes.DateTime);

            builder.Property(e => e.PasswordSalt)
                .HasColumnName("passwordSalt")
                .HasUtf8ColumnType(SqlServerBuilderTypes.String(255));

            builder.Property(e => e.PasswordHash)
                .IsRequired()
                .HasColumnName("passwordHash")
                .HasUtf8ColumnType(SqlServerBuilderTypes.String(2048));
            
            builder.Property(e => e.UserName)
                .HasColumnName("userName")
                .HasUtf8ColumnType(SqlServerBuilderTypes.String(40));
            
            builder.Property(e => e.NormalizedUserName)
                .HasColumnName("normalizedUserName")
                .HasUtf8ColumnType(SqlServerBuilderTypes.String(40));

            builder.Property(e => e.EmailConfirmed)
                .HasColumnName("emailConfirmed")
                .HasColumnType(SqlServerBuilderTypes.Boolean);
            
            builder.Property(e => e.SecurityStamp)
                .HasColumnName("securityStamp")
                .HasUtf8ColumnType(SqlServerBuilderTypes.String(2048));
            
            builder.Property(e => e.ConcurrencyStamp)
                .HasColumnName("concurrencyStamp")
                .HasUtf8ColumnType(SqlServerBuilderTypes.String(2048));
            
            builder.Property(e => e.PhoneNumber)
                .HasColumnName("phoneNumber")
                .HasUtf8ColumnType(SqlServerBuilderTypes.String(255));
            
            builder.Property(e => e.PhoneNumberConfirmed)
                .IsRequired()
                .HasColumnName("phoneNumberConfirmed")
                .HasColumnType(SqlServerBuilderTypes.Boolean);
            
            builder.Property(e => e.TwoFactorEnabled)
                .IsRequired()
                .HasColumnName("twoFactorEnabled")
                .HasColumnType(SqlServerBuilderTypes.Boolean);
            
            builder.Property(e => e.LockoutEnd)
                .HasColumnName("lockoutEnd")
                .HasColumnType(SqlServerBuilderTypes.DateTime);
            
            builder.Property(e => e.LockoutEnabled)
                .IsRequired()
                .HasColumnName("lockoutEnabled")
                .HasColumnType(SqlServerBuilderTypes.Boolean);
            
            builder.Property(e => e.AccessFailedCount)
                .IsRequired()
                .HasColumnName("accessFailedCount")
                .HasColumnType(SqlServerBuilderTypes.UnsignedInt);
        }
    }
}