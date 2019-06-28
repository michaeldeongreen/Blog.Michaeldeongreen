using Blog.Michaeldeongreen.CLI.Core.Common;
using Blog.Michaeldeongreen.CLI.Core.Domain;
using Blog.Michaeldeongreen.CLI.Core.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Blog.Michaeldeongreen.CLI.Core.Services
{
    public class CommandLineArgumentValidationService : ICommandLineArgumentValidationService
    {
        private IList<CommandLineArgument> _commandLineArguments;
        private IList<CommandLineArgumentError> _errors;
        public IList<CommandLineArgumentError> Errors { get { return _errors; } }

        public CommandLineArgumentValidationService()
        {
            _errors = new List<CommandLineArgumentError>();
        }

        public bool IsValid(IList<CommandLineArgument> commandLineArguments)
        {
            _commandLineArguments = commandLineArguments;
            if (!IsThereArguments())
                return false;
            if (!IsThereAConfigArgument())
                return false;
            if (!IsThereAOutputArgument())
                return false;
            if (!IsThereABlogUrlArgument())
                return false;

            return true;
        }

        private bool IsThereArguments()
        {
            if (_commandLineArguments == null || _commandLineArguments.Count == 0)
            {
                this._errors.Add(new CommandLineArgumentError() { Id = 0, Description = "Invalid arguments provided.  Should be: gc-cli -config \"c:\\configdirectory\" -output \"c:\\outputdirectory\" -blogurl \"http://Blog.Michaeldeongreen.com\" " });
                return false;
            }
            return true;
        }

        private bool IsThereAConfigArgument()
        {
            var argument = _commandLineArguments.Where(a => a.Type == CommandLineArgumentType.ConfigDir).SingleOrDefault();
            if (argument == null || string.IsNullOrEmpty(argument.Value))
            {
                this._errors.Add(new CommandLineArgumentError() { Id = 0, Description = "-configdir argument not provided. Example: -configdir \"c:\\configdirectory\"" });
                return false;
            }
            return true;
        }

        private bool IsThereAOutputArgument()
        {
            var argument = _commandLineArguments.Where(a => a.Type == CommandLineArgumentType.OutputDir).SingleOrDefault();
            if (argument == null || string.IsNullOrEmpty(argument.Value))
            {
                this._errors.Add(new CommandLineArgumentError() { Id = 0, Description = "-outputdir argument not provided.  Example: -outputdir \"c:\\outputdirectory\"" });
                return false;
            }
            return true;
        }

        private bool IsThereABlogUrlArgument()
        {
            var argument = _commandLineArguments.Where(a => a.Type == CommandLineArgumentType.BlogUrl).SingleOrDefault();
            if (argument == null || string.IsNullOrEmpty(argument.Value))
            {
                this._errors.Add(new CommandLineArgumentError() { Id = 0, Description = "-apiurl argument not provided.  Example: -blogurl \"http://Blog.Michaeldeongreen.com\"" });
                return false;
            }
            return true;
        }
    }
}