using LaDanse.Target.Entities.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Target.SqlServer.Configurations.Events
{
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.ToTable("Event");

            builder.HasIndex(e => e.OrganiserId)
                .HasDatabaseName("IDX_FA6F25A34BDD3C8");

            builder.HasGuidKey();

            builder.Property(e => e.Name)
                .IsRequired()
                .HasColumnName("name")
                .HasUtf8ColumnType(SqlServerBuilderTypes.String(100));

            builder.Property(e => e.Description)
                .HasColumnName("description")
                .HasUtf8ColumnType(SqlServerBuilderTypes.String(4000));

            builder.Property(e => e.StartTime)
                .IsRequired()
                .HasColumnName("startTime")
                .HasColumnType(SqlServerBuilderTypes.DateTime);

            builder.Property(e => e.InviteTime)
                .IsRequired()
                .HasColumnName("inviteTime")
                .HasColumnType(SqlServerBuilderTypes.DateTime);

            builder.Property(e => e.EndTime)
                .IsRequired()
                .HasColumnName("endTime")
                .HasColumnType(SqlServerBuilderTypes.DateTime);

            builder.Property(e => e.LastModifiedTime)
                .IsRequired()
                .HasColumnName("lastModifiedTime")
                .HasColumnType(SqlServerBuilderTypes.DateTime);

            builder.Property(e => e.State)
                .IsRequired()
                .HasColumnName("state")
                .HasColumnType(SqlServerBuilderTypes.Enum);

            builder.Property(e => e.OrganiserId)
                .HasColumnName("organiserId")
                .HasForeignKeyColumnType();
            builder.HasOne(d => d.Organiser)
                .WithMany()
                .HasForeignKey(d => d.OrganiserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FA6F25A34BDD3C8");

            builder.Property(e => e.CommentGroupId)
                .HasColumnName("commentGroupId")
                .HasForeignKeyColumnType();
            builder.HasOne(d => d.CommentGroup)
                .WithMany()
                .HasForeignKey(d => d.CommentGroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FA6F25A34BDD4B9");
        }
    }
}