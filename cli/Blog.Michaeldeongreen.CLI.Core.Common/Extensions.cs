namespace Blog.Michaeldeongreen.CLI.Core.Common
{
    public static class Extensions
    {
        public static string ToArgument(this CommandLineArgumentType type)
        {
            string arg = $"-{type.ToString().ToLower()}";
            return arg;
        }
    }
}
