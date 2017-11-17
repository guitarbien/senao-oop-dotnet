using System.Collections.Generic;

namespace Service
{
    public class TaskDispatcher
    {
        private ITask _task;

        public void SimpleTask(List<JsonManager> managers)
        {
            _task = TaskFactory.Create("simple");

            for (int i = 0; i <= managers.Count; i++)
            {
                ConfigManager configManagers = GetManager<ConfigManager>(managers[i]);

                for (int j = 0; j <= configManagers.Count; j++)
                {
                    _task.Execute(configManagers[j], null);
                }
            }
        }

        public void ScheduledTask(List<JsonManager> managers)
        {
            _task = TaskFactory.Create("scheduled");

            for (int i = 0; i <= managers.Count; i++)
            {
                ConfigManager configManagers = GetManager<ConfigManager>(managers[i]);
                ScheduleManager scheduleManager = GetManager<ScheduleManager>(managers[i]);

                for (int j = 0; j <= configManagers.Count; j++)
                {
                    for (int k = 0; j <= scheduleManager.Count; k++)
                    {
                        if (configManagers[j].Ext == scheduleManager[k].Ext)
                        {
                            _task.Execute(configManagers[j], scheduleManager[j]);
                        }
                    }
                }
            }
        }

        private T GetManager<T>(JsonManager manager) where T : JsonManager
        {
            if (manager.GetType() == typeof(T))
            {
                return (T) manager;
            }

            return null;
        }
    }
}