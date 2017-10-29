using System.Collections.Generic;

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
    }
}