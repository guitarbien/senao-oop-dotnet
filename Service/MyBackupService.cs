using System;

namespace Service
{
    public class MyBackupService
    {
        private readonly ConfigManager configManager;

        private readonly ScheduleManager scheduleManager;

        public MyBackupService(ConfigManager configManager, ScheduleManager scheduleManager)
        {
            this.configManager = configManager ?? throw new ArgumentNullException(nameof(configManager));
            this.scheduleManager = scheduleManager ?? throw new ArgumentNullException(nameof(scheduleManager));
        }

        public void ProcessConfig()
        {
            configManager.ProcessConfig();
            scheduleManager.ProcessConfig();
        }

        public void ConfigService()
        {

        }
    }
}