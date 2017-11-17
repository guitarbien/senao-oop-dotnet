using System.Collections.Generic;
using MyBackupCandidate;
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
            ConfigManager configManager = GetConfigManager();

            for (int i = 0; i <= configManager.Count; i++)
            {
                IFileFinder fileFinder = FileFinderFactory.Create("file", configManager[i]);

                foreach (Candidate candidate in fileFinder)
                {
                    BroadcastToHandlers(candidate);
                }
            }
        }

        private ConfigManager GetConfigManager()
        {
            foreach (JsonManager manager in _managers)
            {
                if (manager.GetType() == typeof(ConfigManager))
                {
                    return (ConfigManager) manager;
                }
            }

            return null;
        }

        private void BroadcastToHandlers(Candidate candidate)
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