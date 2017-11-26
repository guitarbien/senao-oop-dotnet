using MyBackupCandidate;

namespace Service.Handler
{
    public class AbstractDbHandler : IDbHandler
    {
        public virtual byte[] Perform(Candidate candidate, byte[] target)
        {
            return target;
        }
    }
}