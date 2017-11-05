using System.Collections.Generic;
using Service.Handler;

namespace Service
{
    public class MyBackupService
    {
        private readonly List<JsonManager> _managers = new List<JsonManager>();

        public MyBackupService()
        {
            _managers.Add(new ConfigManager());
            _managers.Add(new ScheduleManager());
        }

        public void ProcessConfig()
        {
            foreach (var manager in _managers)
            {
                manager.ProcessConfig();
            }
        }

        public void DoBackup()
        {
            List<Candidate> candidates = FindFiles();

            foreach (Candidate candidate in candidates)
            {
                BroadcastToHandlers(candidate);
            }
        }

        private List<Candidate> FindFiles()
        {
            List<Candidate> fakeCandidates = new List<Candidate>();

            fakeCandidates.Add(new Candidate());

            return fakeCandidates;
        }

        private void BroadcastToHandlers(Candidate candidate)
        {
            List<IHandler> handlers = FindHandlers(candidate);

            byte[] target = null;
            foreach (IHandler handler in handlers)
            {
                target = handler.perform(candidate, target);
            }
        }

        private List<IHandler> FindHandlers(Candidate candidate)
        {
            List<IHandler> handlers = new List<IHandler>();

            handlers.Add(HandlerFactory.create("file"));

            foreach (string handler in candidate.config.handlers)
            {
                handlers.Add(HandlerFactory.create(handler));
            }

            handlers.Add(HandlerFactory.create(candidate.config.Destination));

            return handlers;
        }
    }
}