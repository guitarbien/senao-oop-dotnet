using Xunit;
using Service;

namespace ServiceTest
{
    public class MyBackupServiceTest
    {
        [Fact]
        public void 模擬使用端操作()
        {
            MyBackupService myBackupService = new MyBackupService();
            myBackupService.ProcessConfig();
            // myBackupService.DoBackup();
        }
    }
}