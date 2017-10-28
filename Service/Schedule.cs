using System;

namespace Service
{
    public class Schedule
    {
        /// <summary>
        /// properties
        /// </summary>
        /// 檔案格式
        public string Ext { get; }

        /// 要備份檔案的目錄
        public string Time { get; }

        /// 是否處理子目錄 true:處理子目錄 / false:不處理子目錄
        public string Interval { get; }

        public Schedule(string ext, string time, string interval)
        {
            Ext = ext ?? throw new ArgumentNullException(nameof(ext));
            Time = time ?? throw new ArgumentNullException(nameof(time));
            Interval = interval ?? throw new ArgumentNullException(nameof(interval));
        }
    }
}