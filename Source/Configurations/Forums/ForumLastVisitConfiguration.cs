using LaDanse.Source.Entities.Forums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LaDanse.Source.Configurations.Forums
{
    public class ForumLastVisitConfiguration : IEntityTypeConfiguration<ForumLastVisit>
    {
        public void Configure(EntityTypeBuilder<ForumLastVisit> builder)
        {
            builder.ToTable("ForumLastVisit");

            builder.HasIndex(e => e.AccountId)
                .HasName("IDX_F17408662DEB3E8");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("visitId")
                .HasComment("(DC2Type:guid)")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_unicode_ci");

            builder.Property(e => e.AccountId)
                .HasColumnName("accountId")
                .HasColumnType("int(11)");

            builder.Property(e => e.LastVisitDate)
                .HasColumnName("lastVisitDate")
                .HasColumnType("datetime");

            builder.HasOne(d => d.Account)
                .WithMany()
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_F17408662DEB3E8");
        }
    }
}
