using System;
using Service;

namespace MyBackupCandidate
{
    public class Candidate
    {
        // 所根據的 Config 物件，由 constructor 傳入
        private readonly Config _config;

        // 檔案的日期與時間
        private readonly DateTime _fileDateTime;

        // 檔案名稱
        private readonly string _name;

        // 處理檔案的 process
        private readonly string _processName;

        // 檔案 size
        private readonly long _size;

        public Config Config => _config;
        public DateTime FileDateTime => _fileDateTime;
        public string Name => _name;
        public string ProcessName => _processName;
        public long Size => _size;

        internal Candidate(Config config, DateTime fileDateTime, string name, string processName, long size)
        {
            _config = config ?? throw new ArgumentNullException(nameof(config));
            _fileDateTime = fileDateTime;
            _name = name ?? throw new ArgumentNullException(nameof(name));
            _processName = processName ?? throw new ArgumentNullException(nameof(processName));
            _size = size;
        }
    }
}