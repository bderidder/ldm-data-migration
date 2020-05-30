using System;

namespace Migration.KeyMappers.CharacterClaims
{
    public class GameCharacterClaimVersionKeyMapper : GenericKeyMapper<int, Guid>
    {
        protected override Guid CreateTargetKey()
        {
            return Guid.NewGuid();
        }
    }
}