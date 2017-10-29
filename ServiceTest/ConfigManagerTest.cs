﻿using Xunit;
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

            Assert.Equal("cs", configManager[0].Ext);
            Assert.Equal("c:\\\\Projects", configManager[0].Location);
            Assert.True(configManager[0].SubDirectory);
            Assert.Equal("file", configManager[0].Unit);
            Assert.False(configManager[0].Remove);
            Assert.Equal("zip", configManager[0].Handler);
            Assert.Equal("directory", configManager[0].Destination);
            Assert.Equal("c:\\\\MyArchieves", configManager[0].Dir);
            Assert.Equal("", configManager[0].ConnectionString);
        }
    }
}