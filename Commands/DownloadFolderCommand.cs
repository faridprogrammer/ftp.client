using System;
using System.Linq;
using CommandLine;
using FluentFTP;

namespace Ftp.Client.Commands
{
    [Verb("download-folder", HelpText = "Download folder content")]
    public class DownloadFolderCommand : FtpCommand
    {
        [Option('p', "path", Required = true)]
        public string Path
        {
            get;
            set;
        }

        protected override void Execute(IFtpClient ftpClient)
        {
            var tempFolder = System.IO.Path.Combine(System.IO.Path.GetTempPath(), System.IO.Path.GetFileNameWithoutExtension(System.IO.Path.GetRandomFileName()));

            var result = ftpClient.DownloadDirectory(tempFolder, Path);
            if (result.Any())
            {

                result.ForEach(ftpResult =>
                {
                    if (ftpResult.IsSuccess)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine($"Download to: {tempFolder}");
                        Console.WriteLine($"{ftpResult.Name}: Success: true");
                        Console.ResetColor();

                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Download to: {tempFolder}");
                        Console.WriteLine($"{ftpResult.Name}: Success: false, Exception: {ftpResult.Exception}");
                        Console.ResetColor();
                    }
                });
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"No files downloaded");
                Console.ResetColor();
                Console.WriteLine(" ");
            }
        }
    }
}
