using Lamar;

namespace Blog.Michaeldeongreen.Core.Common
{
    public class CommonRegistry : ServiceRegistry
    {
        public CommonRegistry()
        {
            Scan(scan =>
            {
                scan.TheCallingAssembly();
                scan.WithDefaultConventions();
            });
       }
    }
}
