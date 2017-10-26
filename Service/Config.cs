using System;

namespace Service
{
    public class Config
    {
        /// <summary>
        /// assign fields
        /// </summary>
        /// <param name="ext">檔案格式</param>
        /// <param name="location">要備份檔案的目錄</param>
        /// <param name="subDirectory">是否處理子目錄，`true` : 處理子目錄；`false` :  `不` 處理子目錄</param>
        /// <param name="unit">備份單位，`file` : 以單一檔案為處理單位；`directory` : 以整個目錄為處理單位</param>
        /// <param name="remove">處理完是否刪除檔案，`true` : 刪除；`false` : 不刪除</param>
        /// <param name="handler">`zip`  : 壓縮；`encode` : 加密</param>
        /// <param name="destination">處理後要儲存到什麼地方，`directory` : 目錄；`db` : 資料庫</param>
        /// <param name="dir">處理後的目錄</param>
        /// <param name="connectionString">資料庫連接字串</param>
        public Config(string ext, string location, bool subDirectory, string unit, bool remove, string handler,
            string destination, string dir, string connectionString)
        {
            Ext = ext ?? throw new ArgumentNullException(nameof(ext));
            Location = location ?? throw new ArgumentNullException(nameof(location));
            SubDirectory = subDirectory;
            Unit = unit ?? throw new ArgumentNullException(nameof(unit));
            Remove = remove;
            Handler = handler ?? throw new ArgumentNullException(nameof(handler));
            Destination = destination ?? throw new ArgumentNullException(nameof(destination));
            Dir = dir ?? throw new ArgumentNullException(nameof(dir));
            ConnectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }

        /// <summary>
        /// properties
        /// </summary>
        public string Ext { get; }
        public string Location { get; }
        public bool SubDirectory { get; }
        public string Unit { get; }
        public bool Remove { get; }
        public string Handler { get; }
        public string Destination { get; }
        public string Dir { get; }
        public string ConnectionString { get; }
    }
}