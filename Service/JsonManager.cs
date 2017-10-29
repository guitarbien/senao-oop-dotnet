using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Service
{
    public abstract class JsonManager
    {
        protected abstract string ConcigJsonPath { get; }

        public abstract void ProcessConfig();

        protected Dictionary<string, List<T>> GetJsonConfig<T>()
        {
            // todo deserialize 後型態為 List<Config>，如何 mapping 到 constructor parameters ???
            return JsonConvert.DeserializeObject<Dictionary<string, List<T>>>(File.ReadAllText(ConcigJsonPath));
        }
    }
}