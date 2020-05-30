namespace Migration.Migrations.CharacterClaims
{
    public class AllCharacterClaimsMigration : IMigration
    {
        private readonly GameCharacterClaimMigration _gameCharacterClaimMigration;
        private readonly GameCharacterClaimVersionMigration _gameCharacterClaimVersionMigration;
        private readonly PlaysGameRoleMigration _playsGameRoleMigratio;
        
        public AllCharacterClaimsMigration(
            GameCharacterClaimMigration gameCharacterClaimMigration,
            GameCharacterClaimVersionMigration gameCharacterClaimVersionMigration,
            PlaysGameRoleMigration playsGameRoleMigration, PlaysGameRoleMigration playsGameRoleMigratio)
        {
            _gameCharacterClaimMigration = gameCharacterClaimMigration;
            _gameCharacterClaimVersionMigration = gameCharacterClaimVersionMigration;
            _playsGameRoleMigratio = playsGameRoleMigratio;
        }
        
        public void Migrate()
        {
            _gameCharacterClaimMigration.Migrate();
            _gameCharacterClaimVersionMigration.Migrate();
            _playsGameRoleMigratio.Migrate();
        }
    }
}