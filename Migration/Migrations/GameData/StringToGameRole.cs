using System;
using LaDanse.Target.Entities.GameData;

namespace Migration.Migrations.GameData
{
    public static class StringToGameRole
    {
        public static GameRole Convert(string strGameRole)
        {
            return strGameRole switch
            {
                "Tank" => GameRole.Tank,
                "Healer" => GameRole.Healer,
                "DPS" => GameRole.Dps,
                _ => throw new Exception($"Unknown game role given: '{strGameRole}'")
            };
        }
    }
}