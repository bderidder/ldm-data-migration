using LaDanse.Target.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LaDanse.Target.Configurations.Identity
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder.HasIndex(e => e.DisplayName)
                .HasName("UNIQ_B28B6F38A0D96FBF")
                .IsUnique();

            builder.HasIndex(e => e.Email)
                .HasName("UNIQ_B28B6F3892FC23A8")
                .IsUnique();

            builder.HasGuidKey();

            builder.Property(e => e.DisplayName)
                .IsRequired()
                .HasColumnName("displayName")
                .HasUtf8ColumnType(MySqlBuilderTypes.String(35));

            builder.Property(e => e.Email)
                .IsRequired()
                .HasColumnName("email")
                .HasUtf8ColumnType(MySqlBuilderTypes.String(180));

            builder.Property(e => e.LastLogin)
                .HasColumnName("lastLogin")
                .HasColumnType(MySqlBuilderTypes.DateTime);

            builder.Property(e => e.Salt)
                .HasColumnName("salt")
                .HasUtf8ColumnType(MySqlBuilderTypes.String(255));

            builder.Property(e => e.Password)
                .IsRequired()
                .HasColumnName("password")
                .HasUtf8ColumnType(MySqlBuilderTypes.String(255));
        }
    }
}