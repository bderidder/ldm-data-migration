using System;

namespace LaDanse.Migration.KeyMappers.GameData.Characters
{
    public class GameCharacterVersionKeyMapper : GenericKeyMapper<int, Guid>
    {
        protected override Guid CreateTargetKey()
        {
            return Guid.NewGuid();
        }
    }
}