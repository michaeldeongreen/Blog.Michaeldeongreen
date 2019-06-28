using Lamar;

namespace Blog.Michaeldeongreen.Core.Services
{
    public class ServicesRegistry : ServiceRegistry
    {
        public ServicesRegistry()
        {
            Scan(scan => {
                scan.TheCallingAssembly();
                scan.WithDefaultConventions();
            });
        }
    }
}
