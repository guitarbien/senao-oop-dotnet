using MyBackupCandidate;

namespace Service.Handler
{
    public interface IDbHandler
    {
        byte[] Perform(Candidate candidate, byte[] target);
    }
}