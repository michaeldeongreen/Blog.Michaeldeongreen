﻿using Blog.Michaeldeongreen.CLI.Core.Common;
using Blog.Michaeldeongreen.CLI.Core.Services;
using Blog.Michaeldeongreen.CLI.Core.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace gc_cli
{
    class Program
    {
        private static ILogger<Program> _logger;
        private static ICommandLineArgumentParseService _commandLineArgumentParseService;
        private static ICommandLineArgumentValidationService _commandLineArgumentValidationService;
        static void Main(string[] args)
        {
            /*args = new string[] {"-configdir", @"C:\\Git\\Blog.Michaeldeongreen\\WebApi\\Blog.Michaeldeongreen.Core.Web.Api\\AppData",
                "-outputdir", @"C:\\Git\\Blog.Michaeldeongreen\\WebClient\\src", "-blogurl", "http://localhost:4200" };*/
            string path = Directory.GetCurrentDirectory();

            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(path);
            builder.Build();

            try
            {
                var serviceCollection = new ServiceCollection();
                ConfigureServices(serviceCollection);
                _logger = serviceCollection.BuildServiceProvider().GetService<ILogger<Program>>();
                _commandLineArgumentParseService = serviceCollection.BuildServiceProvider().GetService<ICommandLineArgumentParseService>();
                _commandLineArgumentValidationService = serviceCollection.BuildServiceProvider().GetService<ICommandLineArgumentValidationService>();
                new Startup().Configure(args, _commandLineArgumentParseService, _commandLineArgumentValidationService);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
            }
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging(configure => configure.AddConsole());
            services.AddScoped<ICommandLineArgumentParseService, CommandLineArgumentParseService>();
            services.AddScoped<ICommandLineArgumentValidationService, CommandLineArgumentValidationService>();
        }

        internal static void CLILogMessageHandler(object sender, CLILogMessageEventArgs e)
        {
            _logger.LogInformation(e.Message);
        }
    }
}
