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

namespace Target.Shared
{
    public interface ITargetDbContext
    {
        #region CharacterClaims

        public DbSet<GameCharacterClaim> GameCharacterClaims { get; set; }
        public DbSet<GameCharacterClaimVersion> GameCharacterClaimVersions { get; set; }
        public DbSet<PlaysGameRole> PlaysGameRoles { get; set; }

        #endregion
        
        #region Comments
        
        public DbSet<Comment> Comments { get; set; }
        public DbSet<CommentGroup> CommentGroups { get; set; }

        #endregion
        
        #region Events
        
        public DbSet<Event> Events { get; set; }
        public DbSet<SignUp> SignUps { get; set; }
        public DbSet<SignedForGameRole> SignedForGameRoles { get; set; }

        #endregion
        
        #region Forums
        
        public DbSet<Forum> Forums { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<UnreadPost> UnreadPosts { get; set; }
        public DbSet<ForumLastVisit> ForumLastVisits { get; set; }

        #endregion
        
        #region GameData
        
        public DbSet<GameClass> GameClasses { get; set; }
        public DbSet<GameFaction> GameFactions { get; set; }
        public DbSet<GameRace> GameRaces { get; set; }
        public DbSet<GameRealm> GameRealms { get; set; }
        
        public DbSet<GameGuild> GameGuilds { get; set; }
        public DbSet<GameCharacter> GameCharacters { get; set; }
        public DbSet<GameCharacterVersion> GameCharacterVersions { get; set; }
        public DbSet<InGameGuild> InGameGuilds { get; set; }
        
        public DbSet<GameCharacterSource> GameCharacterSources { get; set; }
        public DbSet<GameCharacterSyncSession> GameCharacterSyncSessions { get; set; }
        
        public DbSet<TrackedBy> TrackedBys { get; set; }
        
        public DbSet<GameGuildSync> GameGuildSyncs { get; set; }
        public DbSet<ProfileSync> ProfileSyncs { get; set; }

        #endregion
        
        #region Identity
        
        public DbSet<User> Users { get; set; }

        #endregion

        #region Queues
        
        public DbSet<ActivityQueueItem> ActivityQueueItems { get; set; }
        public DbSet<NotificationQueueItem> NotificationQueueItems { get; set; }

        #endregion

        #region Settings
        
        public DbSet<Setting> Settings { get; set; }
        public DbSet<CalendarExport> CalendarExports { get; set; }
        public DbSet<FeatureToggle> FeatureToggles { get; set; }

        #endregion
        
        #region Telemetry
        
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<FeatureUse> FeatureUses { get; set; }
        public DbSet<MailSend> MailSends { get; set; }

        #endregion

        public int SaveChanges();
    }
}