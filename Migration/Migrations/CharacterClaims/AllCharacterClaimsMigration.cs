namespace Migration.Migrations.CharacterClaims
{
    public class AllCharacterClaimsMigration : IMigration
    {
        private readonly GameCharacterClaimMigration _gameCharacterClaimMigration;
        private readonly GameCharacterClaimVersionMigration _gameCharacterClaimVersionMigration;
        private readonly PlaysGameRoleMigration _playsGameRoleMigration;
        
        public AllCharacterClaimsMigration(
            GameCharacterClaimMigration gameCharacterClaimMigration,
            GameCharacterClaimVersionMigration gameCharacterClaimVersionMigration,
            PlaysGameRoleMigration playsGameRoleMigration)
        {
            _gameCharacterClaimMigration = gameCharacterClaimMigration;
            _gameCharacterClaimVersionMigration = gameCharacterClaimVersionMigration;
            _playsGameRoleMigration = playsGameRoleMigration;
        }
        
        public void Migrate()
        {
            _gameCharacterClaimMigration.Migrate();
            _gameCharacterClaimVersionMigration.Migrate();
            _playsGameRoleMigration.Migrate();
        }
    }
}