﻿namespace Blog.Michaeldeongreen.Core.Common
{
    public class AppSettings
    {
        public int PageSize { get; set; }
        public int ArchiveMonths { get; set; }
        public int BlogMonitorInterval { get; set; }
        public string BlogMonitorApiUrl { get; set; }
        public bool BlogMonitorEnabled { get; set; }
    }
}
