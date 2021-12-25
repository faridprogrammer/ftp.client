using System;
using CommandLine;

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

            Parser.Default.ParseArguments<FetchFolderCommand, FileUploadCommand>(args).WithParsed(t => ((ICommand)t).Execute());

            Console.WriteLine("Press any key to close...");
        }
    }
}
