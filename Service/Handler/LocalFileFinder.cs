using System.Collections.Generic;
using System.IO;
using MyBackupCandidate;

namespace Service.Handler
{
    public class LocalFileFinder : AbstractFileFinder
    {
        public LocalFileFinder(Config config) : base(config)
        {
            if (config.SubDirectory)
            {
                Files = GetSubDirectoryFiles(config);
            }
            else
            {
                Files = Directory.GetFiles(config.Location, "*." + config.Ext);
            }
        }

        private string[] GetSubDirectoryFiles(Config config)
        {
            List<string> allFiles = new List<string>();

            // 取出該層的所有檔案
            allFiles.AddRange(Directory.GetFiles(config.Location, "*." + config.Ext));

            // 加入該層的所有目錄下的檔案
            foreach (string folder in Directory.GetDirectories(config.Location))
            {
                allFiles.AddRange(Directory.GetFiles(folder, "*." + config.Ext));
            }

            return allFiles.ToArray();
        }

        protected override Candidate CreateCandidate(string filename)
        {
            if (!File.Exists(filename)) return null;

            var fileInfo = new FileInfo(filename);
            return CandidateFactory.Create(Config, filename, fileInfo.CreationTime, fileInfo.Length);
        }
    }
}