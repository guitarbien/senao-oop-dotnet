using MyBackupCandidate;
using Service.Models;

namespace Service.Handler
{
    public class DbLogHandler : AbstractDbHandler
    {
        public override byte[] Perform(Candidate candidate, byte[] target)
        {
            byte[] result = base.Perform(candidate, target);

            using (var context = new MyDbContext())
            {
                var log = new Log
                {
                    fileDateTime = candidate.FileDateTime
                };

                context.Logs.Add(log);
            }

            return result;
        }
    }
}