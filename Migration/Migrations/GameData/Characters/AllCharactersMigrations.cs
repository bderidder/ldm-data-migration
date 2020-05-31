namespace LaDanse.Migration.Migrations.GameData.Characters
{
    public class AllCharactersMigrations : IMigration
    {
        private readonly GameGuildMigration _gameGuildMigration;
        private readonly GameCharacterMigration _gameCharacterMigration;
        private readonly GameCharacterVersionMigration _gameCharacterVersionMigration;
        private readonly InGameGuildMigration _inGameGuildMigration;
        
        public AllCharactersMigrations(
            GameGuildMigration gameGuildMigration, 
            GameCharacterMigration gameCharacterMigration, 
            GameCharacterVersionMigration gameCharacterVersionMigration, 
            InGameGuildMigration inGameGuildMigration)
        {
            _gameCharacterMigration = gameCharacterMigration;
            _gameCharacterVersionMigration = gameCharacterVersionMigration;
            _gameGuildMigration = gameGuildMigration;
            _inGameGuildMigration = inGameGuildMigration;
        }
        
        public void Migrate()
        {
            _gameGuildMigration.Migrate();
            _gameCharacterMigration.Migrate();
            _gameCharacterVersionMigration.Migrate();
            _inGameGuildMigration.Migrate();
        }
    }
}