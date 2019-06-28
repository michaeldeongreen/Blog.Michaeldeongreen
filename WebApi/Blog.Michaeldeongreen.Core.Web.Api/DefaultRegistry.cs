using Lamar;

namespace Blog.Michaeldeongreen.Core.Web.Api
{
    public class DefaultRegistry : ServiceRegistry
    {
        public DefaultRegistry()
        {
            Scan(scan =>
            {
                scan.TheCallingAssembly();
                scan.WithDefaultConventions();
            });
        }
    }
}
