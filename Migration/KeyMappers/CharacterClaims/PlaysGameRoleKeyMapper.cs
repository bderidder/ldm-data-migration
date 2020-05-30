using System;

namespace Migration.KeyMappers.CharacterClaims
{
    public class PlaysGameRoleKeyMapper : GenericKeyMapper<int, Guid>
    {
        private readonly GameCharacterClaimKeyMapper _gameCharacterClaimKeyMapper;
        
        public PlaysGameRoleKeyMapper(
            GameCharacterClaimKeyMapper gameCharacterClaimKeyMapper)
        {
            _gameCharacterClaimKeyMapper = gameCharacterClaimKeyMapper;
        }
        
        protected override Guid CreateTargetKey()
        {
            return Guid.NewGuid();
        }
    }
}