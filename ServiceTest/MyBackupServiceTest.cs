using System.ComponentModel.Design;
using Xunit;
using Service;

namespace ServiceTest
{
    public class MyBackupServiceTest
    {
        [Fact]
        public void 模擬使用端操作()
        {
            ConfigManager configManager = new ConfigManager();
            ScheduleManager scheduleManager = new ScheduleManager();

            MyBackupService myBackupService = new MyBackupService(configManager, scheduleManager);
            myBackupService.ProcessConfig();
            // myBackupService.DoBackup();
        }
    }
}