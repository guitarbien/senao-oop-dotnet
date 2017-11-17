﻿using System;

namespace Service
{
    public class Candidate
    {
        // 所根據的 Config 物件，由 constructor 傳入
        private readonly Config _config;

        // 檔案的日期與時間
        private readonly string _fileDateTime;

        // 檔案名稱
        private readonly string _name;

        // 處理檔案的 process
        private readonly string _processName;

        // 檔案 size
        private readonly int _size;

        public Config Config => _config;
        public string FileDateTime => _fileDateTime;
        public string Name => _name;
        public string ProcessName => _processName;
        public int Size => _size;

        public Candidate(Config config, string fileDateTime, string name, string processName, int size)
        {
            _config = config ?? throw new ArgumentNullException(nameof(config));
            _fileDateTime = fileDateTime ?? throw new ArgumentNullException(nameof(fileDateTime));
            _name = name ?? throw new ArgumentNullException(nameof(name));
            _processName = processName ?? throw new ArgumentNullException(nameof(processName));
            _size = size;
        }
    }
}