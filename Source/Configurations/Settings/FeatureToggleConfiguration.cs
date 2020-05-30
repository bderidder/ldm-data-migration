using LaDanse.Source.Entities.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LaDanse.Source.Configurations.Settings
{
    public class FeatureToggleConfiguration : IEntityTypeConfiguration<FeatureToggle>
    {
        public void Configure(EntityTypeBuilder<FeatureToggle> builder)
        {
            builder.ToTable("FeatureToggle");

            builder.HasIndex(e => e.ToggleForId)
                .HasName("IDX_D25E05DD612E729E");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .HasColumnType("int(11)");

            builder.Property(e => e.Feature)
                .IsRequired()
                .HasColumnName("feature")
                .HasColumnType("varchar(255)")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_unicode_ci");

            builder.Property(e => e.Toggle)
                .HasColumnName("toggle");

            builder.Property(e => e.ToggleForId)
                .HasColumnName("toggleFor")
                .HasColumnType("int(11)");

            builder.HasOne(d => d.ToggleFor)
                .WithMany()
                .HasForeignKey(d => d.ToggleForId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_D25E05DD612E729E");
        }
    }
}
