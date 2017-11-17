namespace Service
{
    public class TaskFactory
    {
        public static ITask Create(string task)
        {
            if (task == "simple")
            {
                return new SimpleTask();
            }

            if (task == "scheduled")
            {
                return new ScheduledTask();
            }

            return null;
        }
    }
}