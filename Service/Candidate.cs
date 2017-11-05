using System;

namespace Service
{
    public class Candidate
    {
        // 所根據的 Config 物件，由 constructor 傳入
        public Config GetConfig { get; }

        // 檔案的日期與時間
        public string FileDateTime { get; }

        // 檔案名稱
        public string Name { get; }

        // 處理檔案的 process
        public string ProcessName { get; }

        // 檔案 size
        public int Size { get; }

        public Candidate(Config getConfig, string fileDateTime, string name, string processName, int size)
        {
            GetConfig = getConfig ?? throw new ArgumentNullException(nameof(getConfig));
            FileDateTime = fileDateTime ?? throw new ArgumentNullException(nameof(fileDateTime));
            Name = name ?? throw new ArgumentNullException(nameof(name));
            ProcessName = processName ?? throw new ArgumentNullException(nameof(processName));
            Size = size;
        }
    }
}