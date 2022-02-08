using System;
using CommandLine;
using Ftp.Client.Commands;

namespace Ftp.Client
{
    internal class Program
    {

        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Invalid args");
                return;
            }

            Parser.Default.ParseArguments<FetchFolderCommand, FileUploadCommand, DownloadFolderCommand>(args).WithParsed(t => ((ICommand)t).Execute());

            Console.WriteLine("Press any key to close...");
        }
    }
}
