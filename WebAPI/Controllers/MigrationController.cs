using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Migration.Migrations;

namespace WebAPI.Controllers
{
    [Route("/api/migrate")]
    [ApiController]
    public class MigrationController : ControllerBase
    {
        private readonly ILogger<MigrationController> _logger;

        private readonly AllTargetMigrations _allTargetMigrations;

        public MigrationController(
            ILogger<MigrationController> logger,
            AllTargetMigrations allTargetMigrations)
        {
            _logger = logger;
            _allTargetMigrations = allTargetMigrations;
        }

        [HttpGet]
        public string Get()
        {
            _allTargetMigrations.Migrate();

            return "Success! All data has been migrated to new schema.";
        }
    }
}
