using System.Collections.Generic;
using System.Linq;
using LaDanse.Source;
using LaDanse.Source.Entities.GameData.Characters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Migration.Migrations;

namespace WebAPI.Controllers
{
    [Route("/api/test")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ILogger<TestController> _logger;

        private readonly SourceDbContext _dbContext;

        private readonly AllTargetMigrations _allTargetMigrations;

        public TestController(
            ILogger<TestController> logger,
            SourceDbContext dbContext,
            AllTargetMigrations allTargetMigrations)
        {
            _logger = logger;
            _dbContext = dbContext;
            _allTargetMigrations = allTargetMigrations;
        }

        [HttpGet]
        public IEnumerable<Guild> Get()
        {
            var queueCount = _dbContext.NotificationQueueItems.ToList().Count;
            
            _allTargetMigrations.Migrate();
            
            _logger.LogInformation($"There are {queueCount} entries in NotificationQueueItems");
            
            return _dbContext.Guilds
                .Include(e => e.Realm)
                .ToList();
        }
    }
}
