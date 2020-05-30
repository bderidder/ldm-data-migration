using LaDanse.Source;
using LaDanse.Target;

namespace Migration.Migrations
{
    public abstract class BaseMigration : IMigration
    {
        protected readonly SourceDbContext SourceDbContext;
        protected readonly TargetDbContext TargetDbContext;

        protected BaseMigration(SourceDbContext sourceDbContext, TargetDbContext targetDbContext)
        {
            SourceDbContext = sourceDbContext;
            TargetDbContext = targetDbContext;
        }

        public abstract void Migrate();
    }
}