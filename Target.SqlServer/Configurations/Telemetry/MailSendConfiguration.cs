﻿using LaDanse.Target.Entities.Telemetry;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Target.SqlServer.Configurations.Telemetry
{
    public class MailSendConfiguration : IEntityTypeConfiguration<MailSend>
    {
        public void Configure(EntityTypeBuilder<MailSend> builder)
        {
            builder.ToTable("MailSend");

            builder.HasGuidKey();

            builder.Property(e => e.FromAddress)
                .IsRequired()
                .HasColumnName("fromAddress")
                .HasUtf8ColumnType(SqlServerBuilderTypes.String(255));

            builder.Property(e => e.SendOn)
                .IsRequired()
                .HasColumnName("sendOn")
                .HasColumnType(SqlServerBuilderTypes.DateTime);

            builder.Property(e => e.Subject)
                .IsRequired()
                .HasColumnName("subject")
                .HasUtf8ColumnType(SqlServerBuilderTypes.String(255));

            builder.Property(e => e.ToAddress)
                .IsRequired()
                .HasColumnName("toAddress")
                .HasUtf8ColumnType(SqlServerBuilderTypes.String(255));
        }
    }
}
