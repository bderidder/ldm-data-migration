using LaDanse.Source.Entities.CharacterClaims;
using LaDanse.Source.Entities.Comments;
using LaDanse.Source.Entities.Events;
using LaDanse.Source.Entities.Forums;
using LaDanse.Source.Entities.GameData.Characters;
using LaDanse.Source.Entities.GameData.Core;
using LaDanse.Source.Entities.GameData.Sync;
using LaDanse.Source.Entities.GameData.Sync.Guild;
using LaDanse.Source.Entities.GameData.Sync.Profile;
using LaDanse.Source.Entities.Identity;
using LaDanse.Source.Entities.Queues;
using LaDanse.Source.Entities.Settings;
using LaDanse.Source.Entities.Telemetry;
using Microsoft.EntityFrameworkCore;

namespace LaDanse.Source
{
    public partial class SourceDbContext : DbContext
    {
        public SourceDbContext(DbContextOptions<SourceDbContext> options)
            : base(options)
        {
        }
        
        #region CharacterClaims
        
        public virtual DbSet<CharacterClaim> CharacterClaims { get; set; }
        public virtual DbSet<CharacterClaimVersion> CharacterClaimVersions { get; set; }
        public virtual DbSet<StringPlaysRole> PlaysRoles { get; set; }

        #endregion
        
        #region Comments
        
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<CommentGroup> CommentGroups { get; set; }

        #endregion
        
        #region Events
        
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<SignUp> SignUps { get; set; }
        public virtual DbSet<ForRole> ForRoles { get; set; }

        #endregion

        #region Forums
        
        public virtual DbSet<Forum> Forums { get; set; }
        public virtual DbSet<Topic> Topics { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<UnreadPost> UnreadPosts { get; set; }
        public virtual DbSet<ForumLastVisit> ForumLastVisits { get; set; }

        #endregion

        #region GameData
        
        public virtual DbSet<GameClass> GameClasss { get; set; }
        public virtual DbSet<GameFaction> GameFactions { get; set; }
        public virtual DbSet<GameRace> GameRaces { get; set; }
        public virtual DbSet<GameRealm> Realms { get; set; }
        
        public virtual DbSet<Guild> Guilds { get; set; }
        public virtual DbSet<GuildCharacter> GuildCharacters { get; set; }
        public virtual DbSet<GuildCharacterVersion> GuildCharacterVersions { get; set; }
        public virtual DbSet<InGuild> InGuilds { get; set; }
        
        public virtual DbSet<CharacterSource> CharacterSources { get; set; }
        public virtual DbSet<CharacterSyncSession> CharacterSyncSessions { get; set; }
        
        public virtual DbSet<TrackedBy> TrackedBys { get; set; }

        public virtual DbSet<ProfileSync> ProfileSyncs { get; set; }
        public virtual DbSet<GuildSync> GuildSyncs { get; set; }

        #endregion
        
        #region Identity
        
        public virtual DbSet<Account> Accounts { get; set; }

        #endregion
        
        #region Queues
        
        public virtual DbSet<ActivityQueueItem> ActivityQueueItems { get; set; }
        public virtual DbSet<NotificationQueueItem> NotificationQueueItems { get; set; }

        #endregion
        
        #region Settings
        
        public virtual DbSet<Setting> Settings { get; set; }
        public virtual DbSet<CalendarExport> CalendarExports { get; set; }
        public virtual DbSet<FeatureToggle> FeatureToggles { get; set; }

        #endregion
        
        #region Telemetry
        
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<FeatureUse> FeatureUses { get; set; }
        public virtual DbSet<MailSend> MailSends { get; set; }

        #endregion
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyAllSourceConfigurations();
        }
    }
}
