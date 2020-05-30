using LaDanse.Source.Entities.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LaDanse.Source.Configurations.Events
{
    public class ForRoleConfiguration : IEntityTypeConfiguration<ForRole>
    {
        public void Configure(EntityTypeBuilder<ForRole> builder)
        {
            builder.ToTable("ForRole");

            builder.HasIndex(e => e.SignUpId)
                .HasName("IDX_16186B55A966702F");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .HasColumnType("int(11)");

            builder.Property(e => e.Role)
                .IsRequired()
                .HasColumnName("role")
                .HasColumnType("varchar(15)")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_unicode_ci");

            builder.Property(e => e.SignUpId)
                .HasColumnName("signUpId")
                .HasColumnType("int(11)");

            builder.HasOne(d => d.SignUp)
                .WithMany()
                .HasForeignKey(d => d.SignUpId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_16186B55A966702F");
        }
    }
}
