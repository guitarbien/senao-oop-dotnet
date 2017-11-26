using System;

namespace Service.Models
{
    public class Log
    {
        public long Id { get; set; }
        public DateTime fileDateTime { get; set; }
        public bool createTime { get; set; }
    }
}