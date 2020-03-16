using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Lamar;
using Blog.Michaeldeongreen.Core.Common;
using Blog.Michaeldeongreen.Core.Services;
using Microsoft.Extensions.Hosting;

namespace Blog.Michaeldeongreen.Core.Web.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureContainer(ServiceRegistry services)
        {
            services.AddControllers();
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            services.AddCors();
            services.AddLogging();

            services.Scan(s =>
            {
                s.TheCallingAssembly();
                s.WithDefaultConventions();
                s.AssemblyContainingType<CommonRegistry>();
                s.AssemblyContainingType<ServicesRegistry>();
                s.AssemblyContainingType<DefaultRegistry>();
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            BlogConfig.Configure($"{env.ContentRootPath}//AppData");
            app.UseCors(c => c.AllowAnyOrigin());
            app.UseRouting();
            app.UseEndpoints(endpoints => 
            {
                endpoints.MapControllers();
            });
        }
    }
}
