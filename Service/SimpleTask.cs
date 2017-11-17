using MyBackupCandidate;

namespace Service
{
    public class SimpleTask: AbstractTask
    {
        public override void Execute(Config config, Schedule schedule)
        {
            base.Execute(config, schedule);

            foreach (Candidate candidate in FileFinder)
            {
                BroadcastToHandlers(candidate);
            }
        }
    }
}