using System;

namespace LaDanse.Migration.KeyMappers.GameData.Characters
{
    public class GameCharacterKeyMapper : GenericKeyMapper<int, Guid>
    {
        protected override Guid CreateTargetKey()
        {
            return Guid.NewGuid();
        }
    }
}