using MyBackupCandidate;
using Service.Models;

namespace Service.Handler
{
    public class DbBackupHandler : AbstractDbHandler
    {
        public override byte[] Perform(Candidate candidate, byte[] target)
        {
            byte[] result = base.Perform(candidate, target);

            using (var context = new MyDbContext())
            {
                var backup = new Backup
                {
                    Name = candidate.Name,
                    FileDateTime = candidate.FileDateTime,
                    Size = candidate.Size,
                    Target = target
                };

                context.Backups.Add(backup);
            }

            return result;
        }
    }
}