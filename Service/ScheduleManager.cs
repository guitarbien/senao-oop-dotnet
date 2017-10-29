using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace Service
{
    public class ScheduleManager : JsonManager
    {
        private readonly List<Schedule> _schedule = new List<Schedule>();

        // access object peroperty with index style
        public Schedule this[int index] => _schedule[index];

        public int Count => _schedule.Count;

        // Config.json file path
        const string ConcigJsonPath = @"/Users/bien/Documents/Codes/senao_oop_laravel/storage/app/schedule.json";

        public override void ProcessConfig()
        {
            string json = ReadJsonConfig();

            JObject jsonObjects = JObject.Parse(json);
            List<JToken> allSchedules = jsonObjects["schedules"].Children().ToList();

            foreach (JToken eachSchedule in allSchedules)
            {
                _schedule.Add(eachSchedule.ToObject<Schedule>());
            }
        }

        private string ReadJsonConfig()
        {
            return File.ReadAllText(ConcigJsonPath);
        }
    }
}