using System;
using CommandLine;
using FluentFTP;
using Ftp.Client.Commands;

namespace Ftp.Client
{
    internal class Program
    {
        public static FtpClient Client;
        static void Main(string[] args)
        {
            Console.WriteLine(@"┌──────────────────────────────────────────────┐
│                                              │
│             Welcome to ftp.client            │
│                                              │
├──────────────────────────────────────────────┤
│Commands available:                           │
│                                              │
│  help, version, connect, disconnect          │
│                                              │
│  fetch-folder, download-folder, upload-file  │
│                                              │
└──────────────────────────────────────────────┘");

            while (true)
            {
                Console.Write("$ ");
                var commandText = Console.ReadLine();
                if(string.IsNullOrEmpty(commandText))
                    continue;
                var commandArgs = commandText.Split(" ");
                if (commandArgs.Length == 0)
                {
                    Console.WriteLine("Invalid args");
                    continue;
                }

                Parser.Default.ParseArguments<FetchFolderCommand, FileUploadCommand, DownloadFolderCommand, ExitCommand, ConnectCommand, DisconnectCommand>(commandArgs).WithParsed(t => ((ICommand)t).Execute());
            }
        }
    }
}
