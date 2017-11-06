using System;
using System.Collections.Generic;

namespace Service
{
    public class Config
    {
        /// <summary>
        /// properties
        /// </summary>
        /// 檔案格式
        public string Ext { get; }

        /// 要備份檔案的目錄
        public string Location { get; }

        /// 是否處理子目錄 true:處理子目錄 / false:不處理子目錄
        public bool SubDirectory { get; }

        /// 備份單位 file:以單一檔案為處理單位 / directory:以整個目錄為處理單位
        public string Unit { get; }

        /// 處理完是否刪除檔案 true:刪除 / false:不刪除
        public bool Remove { get; }

        /// 處理方式 zip:壓縮 / encode:加密
        public List<string> Handlers { get; }

        /// 處理後要儲存到什麼地方 directory:目錄 / db資料庫
        public string Destination { get; }

        /// 處理後的目錄
        public string Dir { get; }

        /// 資料庫連接字串
        public string ConnectionString { get; }

        public Config(string ext, string location, bool subDirectory, string unit, bool remove, List<string> handlers,
            string destination, string dir, string connectionString)
        {
            Ext = ext ?? throw new ArgumentNullException(nameof(ext));
            Location = location ?? throw new ArgumentNullException(nameof(location));
            SubDirectory = subDirectory;
            Unit = unit ?? throw new ArgumentNullException(nameof(unit));
            Remove = remove;
            Handlers = handlers ?? throw new ArgumentNullException(nameof(handlers));
            Destination = destination ?? throw new ArgumentNullException(nameof(destination));
            Dir = dir ?? throw new ArgumentNullException(nameof(dir));
            ConnectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }
    }
}