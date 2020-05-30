using LaDanse.Target.Entities.GameData.Sync;
using LaDanse.Target.Entities.GameData.Sync.Guild;
using LaDanse.Target.Entities.GameData.Sync.Profile;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LaDanse.Target.Configurations.GameData.Sync
{
    public class GameCharacterSourceConfiguration : IEntityTypeConfiguration<GameCharacterSource>
    {
        public void Configure(EntityTypeBuilder<GameCharacterSource> builder)
        {
            builder.ToTable("GameCharacterSource");

            builder.HasGuidKey();
            
            builder.HasDiscriminator<string>("discr")
                .HasValue<GameGuildSync>("GuildSync")
                .HasValue<ProfileSync>("ProfileSync");

            builder.Property("discr")
                .IsRequired()
                .HasColumnName("discr")
                .HasColumnType("char(15)");
        }
    }
}
