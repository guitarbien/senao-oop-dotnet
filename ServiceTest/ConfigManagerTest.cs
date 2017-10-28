using Xunit;
using Service;

namespace ServiceTest
{
    public class ConfigManagerTest
    {
        [Fact]
        public void ConfigManager有Count屬性可以使用操作array方式取得configs的內容()
        {
            ConfigManager configManager = new ConfigManager();
            configManager.ProcessConfig();

            Assert.IsType<Config>(configManager[0]);
            Assert.Equal(configManager.Count, 3);
        }
    }
}