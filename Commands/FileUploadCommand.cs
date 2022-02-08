using System;
using System.Linq;
using CommandLine;
using FluentFTP;

namespace Ftp.Client.Commands
{
    [Verb("upload-file", HelpText = "Upload file from local path to a remote path")]
    public class FileUploadCommand : FtpCommand
    {
        [Option('p', "path", Required = true)]
        public string Path
        {
            get;
            set;
        }

        [Option('f', "local-path", Required = true, HelpText = "Local path of the file to upload")]
        public string LocalFile
        {
            get;
            set;
        }

        protected override void Execute(IFtpClient ftpClient)
        {
            var result = ftpClient.UploadFile(LocalFile, Path);

            Console.WriteLine("Result: ");
            Console.WriteLine(result);
        }
    }
}
