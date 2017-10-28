using System.Collections.Generic;

namespace Service
{
    public class ConfigManager
    {
        private readonly List<Config> _configs = new List<Config>();

        // access object peroperty with index style
        public Config this[int index] => _configs[index];

        public int Count => _configs.Count;

        public void ProcessConfig()
        {
            _configs.Add(new Config(
                "ext",
                "location",
                true,
                "unit",
                false,
                "handler",
                "destination",
                "dir",
                "connectionString"
            ));
        }
    }
}