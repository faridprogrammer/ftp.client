using System;
using CommandLine;

namespace Ftp.Client.Commands
{
    [Verb("exit", HelpText = "Closes the application")]
    public class ExitCommand : ICommand
    {
        public void Execute()
        {
            Environment.Exit(0);
        }
    }
}
