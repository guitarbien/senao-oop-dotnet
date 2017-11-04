using System.Collections.Generic;
using Xunit;
using Service;

namespace ServiceTest
{
    public class ConfigTest
    {
        [Fact]
        public void Config要有基本屬性()
        {
            List<string> handlers = new List<string>();
            handlers.Add("zip");

            Config config = new Config(
                "ext",
                "location",
                true,
                "unit",
                false,
                handlers,
                "destination",
                "dir",
                "connectionString"
            );

            Assert.Equal("ext", config.Ext);
            Assert.Equal("location", config.Location);
            Assert.True(config.SubDirectory);
            Assert.Equal("unit", config.Unit);
            Assert.False(config.Remove);
            Assert.Equal("zip", config.Handlers[0]);
            Assert.Equal("destination", config.Destination);
            Assert.Equal("dir", config.Dir);
            Assert.Equal("connectionString", config.ConnectionString);
        }
    }
}