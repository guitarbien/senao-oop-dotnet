using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace Service
{
    public class ConfigManager
    {
        private readonly List<Config> _configs = new List<Config>();

        // access object peroperty with index style
        public Config this[int index] => _configs[index];

        public int Count => _configs.Count;

        // Config.json file path
        const string ConcigJsonPath = @"/Users/bien/Documents/Codes/senao_oop_laravel/storage/app/config.json";

        public void ProcessConfig()
        {
            string json = readJsonConfig();

            JObject jsonObjects = JObject.Parse(json);
            List<JToken> allConfigs = jsonObjects["configs"].Children().ToList();

            foreach (JToken eachConfig in allConfigs)
            {
                _configs.Add(eachConfig.ToObject<Config>());
            }
        }

        private string readJsonConfig()
        {
            return File.ReadAllText(ConcigJsonPath);
        }
    }
}