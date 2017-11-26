using MyBackupCandidate;

namespace Service.Handler
{
    public class DbAdapter : AbstractHandler
    {
        private readonly IDbHandler _backupHandler = new DbBackupHandler();
        private readonly IDbHandler _logHandler = new DbLogHandler();

        public override byte[] Perform(Candidate candidate, byte[] target)
        {
            base.Perform(candidate, target);

            SaveBackupToDb(candidate, target);
            SaveLogToDb(candidate, target);

            return target;
        }

        private void SaveLogToDb(Candidate candidate, byte[] target)
        {
            _backupHandler.Perform(candidate, target);
        }

        private void SaveBackupToDb(Candidate candidate, byte[] target)
        {
            _logHandler.Perform(candidate, target);
        }
    }
}