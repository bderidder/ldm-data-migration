using LaDanse.Source.Entities.Telemetry;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LaDanse.Source.Configurations.Tracking
{
    public class MailSendConfiguration : IEntityTypeConfiguration<MailSend>
    {
        public void Configure(EntityTypeBuilder<MailSend> builder)
        {
            builder.ToTable("MailSend");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .HasColumnType("int(11)");

            builder.Property(e => e.FromAddress)
                .IsRequired()
                .HasColumnName("fromAddress")
                .HasColumnType("varchar(255)")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_unicode_ci");

            builder.Property(e => e.SendOn)
                .HasColumnName("sendOn")
                .HasColumnType("datetime");

            builder.Property(e => e.Subject)
                .IsRequired()
                .HasColumnName("subject")
                .HasColumnType("varchar(255)")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_unicode_ci");

            builder.Property(e => e.ToAddress)
                .IsRequired()
                .HasColumnName("toAddress")
                .HasColumnType("varchar(255)")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_unicode_ci");
        }
    }
}
