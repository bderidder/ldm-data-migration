using System.Linq;
using LaDanse.Migration.KeyMappers.GameData.Sync;
using LaDanse.Source;
using LaDanse.Source.MySql;
using LaDanse.Target;
using LaDanse.Target.Entities.GameData.Sync;
using Target.Shared;

namespace LaDanse.Migration.Migrations.GameData.Sync
{
    public class GameCharacterSyncSessionMigration : BaseMigration, IMigration
    {
        private readonly GameCharacterSyncSessionKeyMapper _gameCharacterSyncSessionKeyMapper;
        private readonly GameCharacterSourceKeyMapper _gameCharacterSourceKeyMapper;
        
        public GameCharacterSyncSessionMigration(
            SourceDbContext sourceDbContext, ITargetDbContext targetDbContext, 
            GameCharacterSyncSessionKeyMapper gameCharacterSyncSessionKeyMapper, 
            GameCharacterSourceKeyMapper gameCharacterSourceKeyMapper)
            : base(sourceDbContext, targetDbContext)
        {
            _gameCharacterSyncSessionKeyMapper = gameCharacterSyncSessionKeyMapper;
            _gameCharacterSourceKeyMapper = gameCharacterSourceKeyMapper;
        }
        
        public void Migrate()
        {
            var characterSyncSessions = SourceDbContext.CharacterSyncSessions.ToList();

            foreach (var characterSyncSession in characterSyncSessions)
            {
                var newEntity = new GameCharacterSyncSession()
                {
                    Id = _gameCharacterSyncSessionKeyMapper.MapKey(characterSyncSession.Id),
                    GameCharacterSourceId = _gameCharacterSourceKeyMapper.MapKey(characterSyncSession.CharacterSourceId),
                    FromTime = characterSyncSession.FromTime,
                    EndTime = characterSyncSession.EndTime,
                    Log = characterSyncSession.Log
                };

                TargetDbContext.GameCharacterSyncSessions.Add(newEntity);
            }

            TargetDbContext.SaveChanges();
        }
    }
}