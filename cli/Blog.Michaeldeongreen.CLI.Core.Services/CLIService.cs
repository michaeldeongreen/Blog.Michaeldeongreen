﻿using Blog.Michaeldeongreen.CLI.Core.Common;
using Blog.Michaeldeongreen.CLI.Core.Domain;
using Blog.Michaeldeongreen.CLI.Core.Services.Interfaces;
using Blog.Michaeldeongreen.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Blog.Michaeldeongreen.CLI.Core.Services
{
    public class CLIService : ICLIService
    {
        private readonly EnvironmentSettings _settings;
        public event EventHandler<CLILogMessageEventArgs> CLILogMessageProcessStatusChanged;

        public CLIService(IList<CommandLineArgument> commandLineArguments)
        {
            _settings = new EnvironmentSettings(commandLineArguments);
        }
        public void Generate()
        {
            AnnounceEvent("Process has started....");

            AnnounceEvent("BlogContextManager init has started....");
            BlogContextManager.Init(_settings.ConfigDir.Value);
            AnnounceEvent("BlogContextManager init has completed....");

            GenerateSitemaps();
            GenerateRSSFeed();
            GenerateStaticHtml();
            AnnounceEvent("Process completed successfully....");
        }

        private void GenerateSitemaps()
        {
            AnnounceEvent("Sitemap generation has started....");
            ISitemapService sitemapService = new SitemapService();
            sitemapService.Generate(_settings.ApiUrl.Value, _settings.ConfigDir.Value, _settings.OutputDir.Value);
            AnnounceEvent("Sitemap generation has completed....");
        }

        private void GenerateRSSFeed()
        {
            AnnounceEvent("RSS Feed generation has started....");
            IRSSService rssService = new RSSService();
            rssService.Generate(_settings.ApiUrl.Value, _settings.OutputDir.Value);
            AnnounceEvent("RSS Feed generation has completed....");
        }

        private void GenerateStaticHtml()
        {
            AnnounceEvent("Static HTML generation has started....");
            IHtmlService htmlService = new HtmlService();
            htmlService.Generate(_settings.ApiUrl.Value, _settings.OutputDir.Value, _settings.OutputDir.Value);
            AnnounceEvent("Static HTML generation has completed....");
        }

        private void AnnounceEvent(string message)
        {
            OnCLILogMessageProcessStatusChanged(this, new CLILogMessageEventArgs() { Message = message });
        }

        protected virtual void OnCLILogMessageProcessStatusChanged(object sender, CLILogMessageEventArgs e)
        {
            EventHandler<CLILogMessageEventArgs> handler = CLILogMessageProcessStatusChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }
    }
}
