using Blog.Michaeldeongreen.CLI.Core.Common;
using System;

namespace Blog.Michaeldeongreen.CLI.Core.Services.Interfaces
{
    public interface ICLIService
    {
        event EventHandler<CLILogMessageEventArgs> CLILogMessageProcessStatusChanged;
        void Generate();
    }
}
