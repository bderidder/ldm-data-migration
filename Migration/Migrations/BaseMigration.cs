using LaDanse.Source.MySql;
using Target.Shared;

namespace LaDanse.Migration.Migrations
{
    public abstract class BaseMigration
    {
        protected readonly SourceDbContext SourceDbContext;
        protected readonly ITargetDbContext TargetDbContext;

        protected BaseMigration(SourceDbContext sourceDbContext, ITargetDbContext targetDbContext)
        {
            SourceDbContext = sourceDbContext;
            TargetDbContext = targetDbContext;
        }
    }
}