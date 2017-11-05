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

            List<string> handlers = new List<string>();
            handlers.Add("file");
            handlers.Add("encode");

            fakeCandidates.Add(
                new Candidate(
                    new Config(
                        "cs",
                        "/Users/bien/Documents/Codes/senao-oop-dotnet/Service",
                        false,
                        "unit",
                        false,
                        handlers,
                        "directory",
                        "/Users/bien/Desktop",
                        ""
                    ),
                    "xxx.cs",
                    "2017-01-01 00:05:06",
                    "someProcess",
                    1024
                )
            );

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

            handlers.Add(HandlerFactory.Create("file"));

            foreach (string handler in candidate.GetConfig.Handlers)
            {
                handlers.Add(HandlerFactory.Create(handler));
            }

            handlers.Add(HandlerFactory.Create(candidate.GetConfig.Destination));

            return handlers;
        }
    }
}