using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Service
{
    public class ConfigManager : JsonManager
    {
        private readonly List<Config> _configs = new List<Config>();

        // access object peroperty with index style
        public Config this[int index] => _configs[index];

        public int Count => _configs.Count;

        // Config.json file path
        // todo 如何用 env 切換檔案位置 ? 測試如何 mock 掉此常數
        protected override string ConcigJsonPath => @"/Users/bien/Documents/Codes/senao_oop_laravel/storage/app/config.json";

        public override void ProcessConfig()
        {
            string json = ReadJsonConfig();

            // todo deserialize 後型態為 List<Config>，如何 mapping 到 constructor parameters ???
            Dictionary<string, List<Config>> jsonObjects = JsonConvert.DeserializeObject<Dictionary<string, List<Config>>>(json);
            foreach (Config eachConfig in jsonObjects["configs"])
            {
                _configs.Add(eachConfig);
            }
        }
    }
}