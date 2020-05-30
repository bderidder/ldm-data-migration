using System;

namespace Migration.KeyMappers.CharacterClaims
{
    public class GameCharacterClaimKeyMapper : GenericKeyMapper<int, Guid>
    {
        protected override Guid CreateTargetKey()
        {
            return Guid.NewGuid();
        }
    }
}