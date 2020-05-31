using LaDanse.Source;
using LaDanse.Target;

namespace LaDanse.Migration.Migrations
{
    public abstract class BaseMigration
    {
        protected readonly SourceDbContext SourceDbContext;
        protected readonly TargetDbContext TargetDbContext;

        protected BaseMigration(SourceDbContext sourceDbContext, TargetDbContext targetDbContext)
        {
            SourceDbContext = sourceDbContext;
            TargetDbContext = targetDbContext;
        }
    }
}