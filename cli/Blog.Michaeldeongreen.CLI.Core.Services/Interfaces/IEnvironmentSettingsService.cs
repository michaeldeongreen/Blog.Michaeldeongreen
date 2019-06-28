using Blog.Michaeldeongreen.CLI.Core.Domain;

namespace Blog.Michaeldeongreen.CLI.Core.Services.Interfaces
{
    public interface IEnvironmentSettingsService
    {
        EnvironmentSettings Get(string environment, string path);
    }
}
