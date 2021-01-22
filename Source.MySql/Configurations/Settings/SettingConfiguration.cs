using LaDanse.Source.Entities.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LaDanse.Source.MySql.Configurations.Settings
{
    public class SettingConfiguration : IEntityTypeConfiguration<Setting>
    {
        public void Configure(EntityTypeBuilder<Setting> builder)
        {
            builder.ToTable("Setting");

            builder.HasIndex(e => e.AccountId)
                .HasDatabaseName("IDX_50C9810462DEB3E8");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .HasColumnType("int(11)");

            builder.Property(e => e.AccountId)
                .HasColumnName("accountId")
                .HasColumnType("int(11)");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasColumnName("name")
                .HasColumnType("varchar(255)")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_unicode_ci");

            builder.Property(e => e.Value)
                .IsRequired()
                .HasColumnName("value")
                .HasColumnType("varchar(2048)")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_unicode_ci");

            builder.HasOne(d => d.Account)
                .WithMany()
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_50C9810462DEB3E8");
        }
    }
}
