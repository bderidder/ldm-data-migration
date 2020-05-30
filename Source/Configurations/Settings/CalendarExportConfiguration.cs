using LaDanse.Source.Entities.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LaDanse.Source.Configurations.Settings
{
    public class CalendarExportConfiguration : IEntityTypeConfiguration<CalendarExport>
    {
        public void Configure(EntityTypeBuilder<CalendarExport> builder)
        {
            builder.ToTable("CalendarExport");

            builder.HasIndex(e => e.AccountId)
                .HasName("IDX_6E28848862DEB3E8");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .HasColumnType("int(11)");

            builder.Property(e => e.AccountId)
                .HasColumnName("accountId")
                .HasColumnType("int(11)");

            builder.Property(e => e.ExportAbsence).HasColumnName("exportAbsence");

            builder.Property(e => e.ExportNew).HasColumnName("exportNew");

            builder.Property(e => e.Secret)
                .IsRequired()
                .HasColumnName("secret")
                .HasColumnType("varchar(100)")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_unicode_ci");

            builder.HasOne(d => d.Account)
                .WithMany()
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_6E28848862DEB3E8");
        }
    }
}
