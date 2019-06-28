using Blog.Michaeldeongreen.Core.Common;

namespace Blog.Michaeldeongreen.Core.Web.Api
{
    public class BlogConfig
    {
        public static void Configure(string path)
        {
            BlogContextManager.Init(path);
        }
    }
}
