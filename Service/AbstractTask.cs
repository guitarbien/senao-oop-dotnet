using System.Collections.Generic;
using MyBackupCandidate;
using Service.Handler;

namespace Service
{
    public abstract class AbstractTask: ITask
    {
        protected IFileFinder FileFinder;

        public virtual void Execute(Config config, Schedule schedule)
        {
            FileFinder = FileFinderFactory.Create("file", config);
        }

        protected void BroadcastToHandlers(Candidate candidate)
        {
            List<IHandler> handlers = FindHandlers(candidate);

            byte[] target = null;
            foreach (IHandler handler in handlers)
            {
                target = handler.Perform(candidate, target);
            }
        }

        private List<IHandler> FindHandlers(Candidate candidate)
        {
            List<IHandler> handlers = new List<IHandler>();

            handlers.Add(HandlerFactory.Create("file"));

            foreach (string handler in candidate.Config.Handlers)
            {
                handlers.Add(HandlerFactory.Create(handler));
            }

            handlers.Add(HandlerFactory.Create(candidate.Config.Destination));

            return handlers;
        }
    }
}