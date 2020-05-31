using System.Linq;
using LaDanse.Source;
using LaDanse.Target;
using LaDanse.Target.Entities.GameData.Sync;
using Migration.KeyMappers.GameData.Characters;
using Migration.KeyMappers.GameData.Core;
using Migration.KeyMappers.GameData.Sync;

namespace Migration.Migrations.Comments
{
    public class AllCommentsMigration : IMigration
    {
        private readonly CommentGroupMigration _commentGroupMigration;
        private readonly CommentMigration _commentMigration;
        
        public AllCommentsMigration(
            CommentGroupMigration commentGroupMigration, 
            CommentMigration commentMigration)
        {
            _commentGroupMigration = commentGroupMigration;
            _commentMigration = commentMigration;
        }
        
        public void Migrate()
        {
            _commentGroupMigration.Migrate();
            _commentMigration.Migrate();
        }
    }
}