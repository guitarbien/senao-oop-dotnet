using System;
using MyBackupCandidate;

namespace Service
{
    public class ScheduledTask : AbstractTask
    {
        public override void Execute(Config config, Schedule schedule)
        {
            base.Execute(config, schedule);

            // todo 目前這樣做會遇到三種 config 可能會因為頻率和時間被卡住很久
            while (true)
            {
                string time = DateTime.Now.ToString("HH:mm");
                string date = DateTime.Now.ToString("dddd");

                if (schedule.Time == time && schedule.Interval == date)
                {
                    foreach (Candidate candidate in FileFinder)
                    {
                        BroadcastToHandlers(candidate);
                    }

                    break;
                }
            }
        }
    }
}