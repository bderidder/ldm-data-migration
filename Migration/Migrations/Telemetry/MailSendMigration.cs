using System.Linq;
using LaDanse.Migration.KeyMappers.Telemetry;
using LaDanse.Source;
using LaDanse.Source.MySql;
using LaDanse.Target;
using LaDanse.Target.Entities.Telemetry;
using Target.Shared;

namespace LaDanse.Migration.Migrations.Telemetry
{
    public class MailSendMigration : BaseMigration, IMigration
    {
        private readonly MailSendKeyMapper _mailSendKeyMapper;
    
        public MailSendMigration(
            SourceDbContext sourceDbContext, ITargetDbContext targetDbContext,
            MailSendKeyMapper mailSendKeyMapper)
            :base(sourceDbContext, targetDbContext)
        {
            _mailSendKeyMapper = mailSendKeyMapper;
        }

        public void Migrate()
        {
            var oldMailSends = SourceDbContext.MailSends.ToList();

            foreach (var oldMailSend in oldMailSends)
            {
                var newEntity = new MailSend()
                {
                    Id = _mailSendKeyMapper.MapKey(oldMailSend.Id), 
                    SendOn = oldMailSend.SendOn, 
                    FromAddress = oldMailSend.FromAddress, 
                    ToAddress = oldMailSend.ToAddress,
                    Subject = oldMailSend.Subject,
                };

                TargetDbContext.MailSends.Add(newEntity);
            }

            TargetDbContext.SaveChanges();
        }
    }
}