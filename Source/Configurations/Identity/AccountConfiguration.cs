using LaDanse.Source.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LaDanse.Source.Configurations.Identity
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("Account");

            builder.HasIndex(e => e.ConfirmationToken)
                .HasName("UNIQ_B28B6F38C05FB297")
                .IsUnique();

            builder.HasIndex(e => e.EmailCanonical)
                .HasName("UNIQ_B28B6F38A0D96FBF")
                .IsUnique();

            builder.HasIndex(e => e.UsernameCanonical)
                .HasName("UNIQ_B28B6F3892FC23A8")
                .IsUnique();

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .HasColumnType("int(11)");

            builder.Property(e => e.ConfirmationToken)
                .HasColumnName("confirmation_token")
                .HasColumnType("varchar(180)")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_unicode_ci");

            builder.Property(e => e.DisplayName)
                .IsRequired()
                .HasColumnName("displayName")
                .HasColumnType("varchar(32)")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_unicode_ci");

            builder.Property(e => e.Email)
                .IsRequired()
                .HasColumnName("email")
                .HasColumnType("varchar(180)")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_unicode_ci");

            builder.Property(e => e.EmailCanonical)
                .IsRequired()
                .HasColumnName("email_canonical")
                .HasColumnType("varchar(180)")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_unicode_ci");

            builder.Property(e => e.Enabled).HasColumnName("enabled");

            builder.Property(e => e.LastLogin)
                .HasColumnName("last_login")
                .HasColumnType("datetime");

            builder.Property(e => e.Password)
                .IsRequired()
                .HasColumnName("password")
                .HasColumnType("varchar(255)")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_unicode_ci");

            builder.Property(e => e.PasswordRequestedAt)
                .HasColumnName("password_requested_at")
                .HasColumnType("datetime");

            builder.Property(e => e.Roles)
                .IsRequired()
                .HasColumnName("roles")
                .HasColumnType("longtext")
                .HasComment("(DC2Type:array)")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_unicode_ci");

            builder.Property(e => e.Salt)
                .HasColumnName("salt")
                .HasColumnType("varchar(255)")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_unicode_ci");

            builder.Property(e => e.Username)
                .IsRequired()
                .HasColumnName("username")
                .HasColumnType("varchar(180)")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_unicode_ci");

            builder.Property(e => e.UsernameCanonical)
                .IsRequired()
                .HasColumnName("username_canonical")
                .HasColumnType("varchar(180)")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_unicode_ci");
        }
    }
}