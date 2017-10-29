using System.Collections.Generic;

namespace Service
{
    public class ScheduleManager : JsonManager
    {
        private readonly List<Schedule> _schedule = new List<Schedule>();

        // access object peroperty with index style
        public Schedule this[int index] => _schedule[index];

        public int Count => _schedule.Count;

        // Config.json file path
        // todo 如何用 env 切換檔案位置 ? 測試如何 mock 掉此常數
        protected override string ConcigJsonPath => @"/Users/bien/Documents/Codes/senao_oop_laravel/storage/app/schedule.json";

        public override void ProcessConfig()
        {
            var jsonObjects = GetJsonConfig<Schedule>();

            foreach (Schedule eachConfig in jsonObjects["schedules"])
            {
                _schedule.Add(eachConfig);
            }

//            // todo 記錄眾多做法的另一種
//            string json = ReadJsonConfig();
//
//            JObject jsonObjects = JObject.Parse(json);
//            List<JToken> allSchedules = jsonObjects["schedules"].Children().ToList();
//
//            foreach (JToken eachSchedule in allSchedules)
//            {
//                _schedule.Add(eachSchedule.ToObject<Schedule>());
//            }
        }
    }
}