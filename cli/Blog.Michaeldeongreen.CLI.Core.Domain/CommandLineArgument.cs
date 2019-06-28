using Blog.Michaeldeongreen.CLI.Core.Common;

namespace Blog.Michaeldeongreen.CLI.Core.Domain
{
    public class CommandLineArgument
    {
        public CommandLineArgumentType Type { get; private set; }
        public string Value { get; private set; }
        public CommandLineArgument(CommandLineArgumentType type, string value)
        {
            Type = type;
            Value = value;
        }

    }
}
