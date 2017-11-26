using System;

namespace Service.Models
{
    public class Backup
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime FileDateTime { get; set; }
        public long Size { get; set; }
        public byte[] Target { get; set; }
        public DateTime CreateTime { get; set; }
    }
}