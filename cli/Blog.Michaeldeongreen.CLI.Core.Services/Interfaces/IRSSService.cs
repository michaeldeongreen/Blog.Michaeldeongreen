namespace Blog.Michaeldeongreen.CLI.Core.Services.Interfaces
{
    public interface IRSSService
    {
        void Generate(string domain, string rssOutputPath);
    }
}
