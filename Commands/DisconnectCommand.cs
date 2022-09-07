using System;
using System.Linq;
using CommandLine;
using FluentFTP;

namespace Ftp.Client.Commands
{
    [Verb("disconnect", HelpText = "Connect to ftp server")]
    public class DisconnectCommand : ICommand
    {
        public void Execute()
        {
            try
            {
                if (Program.Client != null)
                {
                    Program.Client.Disconnect();
                    Program.Client.Dispose();
                    Console.WriteLine("Successfully connected to ftp server...");
                    Program.Client = null;
                }
                else
                {
                    Console.WriteLine("There is no active connection to a ftp server...");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
