using System.IO;

namespace Service
{
    public abstract class JsonManager
    {
        protected abstract string ConcigJsonPath { get; }

        public abstract void ProcessConfig();

        protected string ReadJsonConfig()
        {
            return File.ReadAllText(ConcigJsonPath);
        }
    }
}