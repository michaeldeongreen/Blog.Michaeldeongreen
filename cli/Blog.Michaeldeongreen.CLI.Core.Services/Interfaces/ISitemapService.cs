﻿namespace Blog.Michaeldeongreen.CLI.Core.Services.Interfaces
{
    public interface ISitemapService
    {
        void Generate(string domain, string configurationPath, string sitemapOutputPath);
    }
}
