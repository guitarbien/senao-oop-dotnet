using System.Collections.Generic;
using MyBackupCandidate;
using Service.Handler;

namespace Service
{
    public class MyBackupService
    {
        private readonly List<JsonManager> _managers = new List<JsonManager>();
        private TaskDispatcher _taskDispatcher;

        public MyBackupService()
        {
            _managers.Add(new ConfigManager());
            _managers.Add(new ScheduleManager());
            _taskDispatcher = new TaskDispatcher();

            Init();
        }

        private void Init()
        {
            ProcessConfig();
        }

        private void ProcessConfig()
        {
            foreach (var manager in _managers)
            {
                manager.ProcessConfig();
            }
        }

        public void SimpleBackup()
        {
            _taskDispatcher.SimpleTask(_managers);
        }

        public void ScheduledBackup()
        {
            _taskDispatcher.ScheduledTask(_managers);
        }
    }
}