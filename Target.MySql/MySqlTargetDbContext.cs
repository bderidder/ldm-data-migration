using LaDanse.Target.Entities.CharacterClaims;
using LaDanse.Target.Entities.Comments;
using LaDanse.Target.Entities.Events;
using LaDanse.Target.Entities.Forums;
using LaDanse.Target.Entities.GameData.Characters;
using LaDanse.Target.Entities.GameData.Core;
using LaDanse.Target.Entities.GameData.Sync;
using LaDanse.Target.Entities.GameData.Sync.Guild;
using LaDanse.Target.Entities.GameData.Sync.Profile;
using LaDanse.Target.Entities.Identity;
using LaDanse.Target.Entities.Queues;
using LaDanse.Target.Entities.Settings;
using LaDanse.Target.Entities.Telemetry;
using Microsoft.EntityFrameworkCore;
using Target.Shared;

namespace LaDanse.Target.MySql
{
    public partial class MySqlTargetDbContext : DbContext, ITargetDbContext
    {
        public MySqlTargetDbContext(DbContextOptions<MySqlTargetDbContext> options)
            : base(options)
        {
        }
        
        #region CharacterClaims

        public virtual DbSet<GameCharacterClaim> GameCharacterClaims { get; set; }
        public virtual DbSet<GameCharacterClaimVersion> GameCharacterClaimVersions { get; set; }
        public virtual DbSet<PlaysGameRole> PlaysGameRoles { get; set; }

        #endregion
        
        #region Comments
        
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<CommentGroup> CommentGroups { get; set; }

        #endregion
        
        #region Events
        
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<SignUp> SignUps { get; set; }
        public virtual DbSet<SignedForGameRole> SignedForGameRoles { get; set; }

        #endregion
        
        #region Forums
        
        public virtual DbSet<Forum> Forums { get; set; }
        public virtual DbSet<Topic> Topics { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<UnreadPost> UnreadPosts { get; set; }
        public virtual DbSet<ForumLastVisit> ForumLastVisits { get; set; }

        #endregion
        
        #region GameData
        
        public virtual DbSet<GameClass> GameClasses { get; set; }
        public virtual DbSet<GameFaction> GameFactions { get; set; }
        public virtual DbSet<GameRace> GameRaces { get; set; }
        public virtual DbSet<GameRealm> GameRealms { get; set; }
        
        public virtual DbSet<GameGuild> GameGuilds { get; set; }
        public virtual DbSet<GameCharacter> GameCharacters { get; set; }
        public virtual DbSet<GameCharacterVersion> GameCharacterVersions { get; set; }
        public virtual DbSet<InGameGuild> InGameGuilds { get; set; }
        
        public virtual DbSet<GameCharacterSource> GameCharacterSources { get; set; }
        public virtual DbSet<GameCharacterSyncSession> GameCharacterSyncSessions { get; set; }
        
        public virtual DbSet<TrackedBy> TrackedBys { get; set; }
        
        public virtual DbSet<GameGuildSync> GameGuildSyncs { get; set; }
        public virtual DbSet<ProfileSync> ProfileSyncs { get; set; }

        #endregion
        
        #region Identity
        
        public virtual DbSet<User> Users { get; set; }

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
            modelBuilder.ApplyAllTargetConfigurations();
        }
    }
}
