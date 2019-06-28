using Blog.Michaeldeongreen.CLI.Core.Domain;
using System.Collections.Generic;


namespace Blog.Michaeldeongreen.CLI.Core.Services.Interfaces
{
    public interface ICommandLineArgumentValidationService
    {
        IList<CommandLineArgumentError> Errors { get; }
        bool IsValid(IList<CommandLineArgument> commandLineArguments);

    }
}
