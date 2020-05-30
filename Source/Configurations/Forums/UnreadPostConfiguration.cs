using LaDanse.Source.Entities.Forums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LaDanse.Source.Configurations.Forums
{
    public class UnreadPostConfiguration : IEntityTypeConfiguration<UnreadPost>
    {
        public void Configure(EntityTypeBuilder<UnreadPost> builder)
        {
            builder.ToTable("UnreadPost");

            builder.HasIndex(e => e.AccountId)
                .HasName("IDX_6B0B9B3E62DEB3E8");

            builder.HasIndex(e => e.PostId)
                .HasName("IDX_6B0B9B3EE094D20D");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("unreadId")
                .HasComment("(DC2Type:guid)")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_unicode_ci");

            builder.Property(e => e.AccountId)
                .HasColumnName("accountId")
                .HasColumnType("int(11)");

            builder.Property(e => e.PostId)
                .HasColumnName("postId")
                .HasComment("(DC2Type:guid)")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_unicode_ci");

            builder.HasOne(d => d.Account)
                .WithMany()
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_6B0B9B3E62DEB3E8");

            builder.HasOne(d => d.Post)
                .WithMany()
                .HasForeignKey(d => d.PostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_6B0B9B3EE094D20D");
        }
    }
}
