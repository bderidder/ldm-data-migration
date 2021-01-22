using LaDanse.Target.Entities.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Target.SqlServer.Configurations.Settings
{
    public class SettingConfiguration : IEntityTypeConfiguration<Setting>
    {
        public void Configure(EntityTypeBuilder<Setting> builder)
        {
            builder.ToTable("Setting");

            builder.HasIndex(e => e.UserId)
                .HasDatabaseName("IDX_50C9810462DEB3E8");

            builder.HasGuidKey();
            
            builder.Property(e => e.Name)
                .IsRequired()
                .HasColumnName("name")
                .HasUtf8ColumnType(SqlServerBuilderTypes.String(255));

            builder.Property(e => e.Value)
                .IsRequired()
                .HasColumnName("value")
                .HasUtf8ColumnType(SqlServerBuilderTypes.String(2048));

            builder.Property(e => e.UserId)
                .HasColumnName("userId")
                .HasForeignKeyColumnType();
            builder.HasOne(d => d.User)
                .WithMany()
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_50C9810462DEB3E8");
        }
    }
}
