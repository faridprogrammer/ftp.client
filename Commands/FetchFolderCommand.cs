using System;
using System.Linq;
using CommandLine;
using FluentFTP;

namespace Ftp.Client.Commands
{
    [Verb("fetch-folder", HelpText = "Fetch folder content list")]
    public class FetchFolderCommand : FtpCommand
    {
        [Option('p', "path", Required = true)]
        public string Path
        {
            get;
            set;
        }

        protected override void Execute(IFtpClient ftpClient)
        {
            var listing = ftpClient.GetNameListing(Path);

            foreach (var s in listing)
            {
                Console.WriteLine(s);
            }
        }
    }
}
