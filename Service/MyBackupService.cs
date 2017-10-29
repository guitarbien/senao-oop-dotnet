using System.Collections.Generic;

namespace Service
{
    public class MyBackupService
    {
        private readonly List<JsonManager> managers = new List<JsonManager>();

        public MyBackupService()
        {
            managers.Add(new ConfigManager());
            managers.Add(new ScheduleManager());
        }

        public void ProcessConfig()
        {
            foreach (JsonManager manager in managers)
            {
                manager.ProcessConfig();
            }
        }
    }
}