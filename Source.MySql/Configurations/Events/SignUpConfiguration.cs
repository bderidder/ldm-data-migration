using LaDanse.Source.Entities.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LaDanse.Source.MySql.Configurations.Events
{
    public class SignUpConfiguration : IEntityTypeConfiguration<SignUp>
    {
        public void Configure(EntityTypeBuilder<SignUp> builder)
        {
            builder.ToTable("SignUp");

            builder.HasIndex(e => e.AccountId)
                .HasDatabaseName("IDX_DC8B3F7B62DEB3E8");

            builder.HasIndex(e => e.EventId)
                .HasDatabaseName("IDX_DC8B3F7B2B2EBB6C");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .HasColumnType("int(11)");

            builder.Property(e => e.AccountId)
                .HasColumnName("accountId")
                .HasColumnType("int(11)");

            builder.Property(e => e.EventId)
                .HasColumnName("eventId")
                .HasColumnType("int(11)");

            builder.Property(e => e.Type)
                .IsRequired()
                .HasColumnName("type")
                .HasColumnType("varchar(15)")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_unicode_ci");

            builder.HasOne(d => d.Account)
                .WithMany()
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DC8B3F7B62DEB3E8");

            builder.HasOne(d => d.Event)
                .WithMany()
                .HasForeignKey(d => d.EventId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DC8B3F7B2B2EBB6C");
        }
    }
}
