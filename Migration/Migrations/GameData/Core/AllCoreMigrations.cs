namespace LaDanse.Migration.Migrations.GameData.Core
{
    public class AllCoreMigrations : IMigration
    {
        private readonly GameFactionMigration _gameFactionMigration;
        private readonly GameClassMigration _gameClassMigration;
        private readonly GameRealmMigration _gameRealmMigration;
        private readonly GameRaceMigration _gameRaceMigration;
        
        public AllCoreMigrations(
            GameFactionMigration gameFactionMigration, 
            GameClassMigration gameClassMigration, 
            GameRealmMigration gameRealmMigration, 
            GameRaceMigration gameRaceMigration)
        {
            _gameFactionMigration = gameFactionMigration;
            _gameClassMigration = gameClassMigration;
            _gameRealmMigration = gameRealmMigration;
            _gameRaceMigration = gameRaceMigration;
        }
        
        public void Migrate()
        {
            _gameFactionMigration.Migrate();
            _gameClassMigration.Migrate();
            _gameRealmMigration.Migrate();
            _gameRaceMigration.Migrate();
        }
    }
}