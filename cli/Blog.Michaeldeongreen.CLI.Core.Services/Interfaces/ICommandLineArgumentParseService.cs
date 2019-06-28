using Blog.Michaeldeongreen.CLI.Core.Common;
using Blog.Michaeldeongreen.CLI.Core.Domain;

namespace Blog.Michaeldeongreen.CLI.Core.Services.Interfaces
{
    public interface ICommandLineArgumentParseService
    {
        CommandLineArgument Parse(string[] args, CommandLineArgumentType type);
    }
}
