using System.Linq;
using LaDanse.Source;
using LaDanse.Target;
using LaDanse.Target.Entities.Telemetry;
using Migration.KeyMappers.Telemetry;

namespace Migration.Migrations.Telemetry
{
    public class MailSendMigration : BaseMigration, IMigration
    {
        private readonly MailSendKeyMapper _mailSendKeyMapper;
    
        public MailSendMigration(
            SourceDbContext sourceDbContext, TargetDbContext targetDbContext,
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