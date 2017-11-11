namespace Service.Handler
{
    public class FileFinderFactory
    {
        public static IFileFinder Create(string finder, Config config)
        {
            if (finder == "file")
            {
                return new LocalFileFinder(config);
            }

            return null;
        }
    }
}