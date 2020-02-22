using Microsoft.AspNetCore.Hosting;
using Lamar.Microsoft.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;
using Microsoft.AspNetCore;

namespace Blog.Michaeldeongreen.Core.Web.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateHostBuilder(string[] args) =>
                WebHost.CreateDefaultBuilder(args)
                    .UseLamar()
                    .UseStartup<Startup>();
    }
}
