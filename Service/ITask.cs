namespace Service
{
    public interface ITask
    {
        void Execute(Config config, Schedule schedule);
    }
}