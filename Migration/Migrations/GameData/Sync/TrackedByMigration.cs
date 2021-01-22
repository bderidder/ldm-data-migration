using System.Linq;
using LaDanse.Migration.KeyMappers.GameData.Characters;
using LaDanse.Migration.KeyMappers.GameData.Sync;
using LaDanse.Source;
using LaDanse.Source.MySql;
using LaDanse.Target;
using LaDanse.Target.Entities.GameData.Sync;
using Target.Shared;

namespace LaDanse.Migration.Migrations.GameData.Sync
{
    public class TrackedByMigration : BaseMigration, IMigration
    {
        private readonly TrackedByKeyMapper _trackedByKeyMapper;
        private readonly GameCharacterKeyMapper _gameCharacterKeyMapper;
        private readonly GameCharacterSourceKeyMapper _gameCharacterSourceKeyMapper;
        
        public TrackedByMigration(
            SourceDbContext sourceDbContext, ITargetDbContext targetDbContext, 
            TrackedByKeyMapper trackedByKeyMapper, 
            GameCharacterSourceKeyMapper gameCharacterSourceKeyMapper, 
            GameCharacterKeyMapper gameCharacterKeyMapper)
            : base(sourceDbContext, targetDbContext)
        {
            _trackedByKeyMapper = trackedByKeyMapper;
            _gameCharacterSourceKeyMapper = gameCharacterSourceKeyMapper;
            _gameCharacterKeyMapper = gameCharacterKeyMapper;
        }
        
        public void Migrate()
        {
            var trackedBys = SourceDbContext.TrackedBys.ToList();

            foreach (var trackedBy in trackedBys)
            {
                var newEntity = new TrackedBy()
                {
                    Id = _trackedByKeyMapper.MapKey(trackedBy.Id),
                    FromTime = trackedBy.FromTime,
                    EndTime = trackedBy.EndTime,
                    GameCharacterId = _gameCharacterKeyMapper.MapKey(trackedBy.CharacterId), 
                    GameCharacterSourceId = _gameCharacterSourceKeyMapper.MapKey(trackedBy.CharacterSourceId)
                };

                TargetDbContext.TrackedBys.Add(newEntity);
            }

            TargetDbContext.SaveChanges();
        }
    }
}