using System;
using CommandLine;
using FluentFTP;

namespace Ftp.Client
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

        public override void Execute()
        {
            var ftpClient = new FtpClient(Host, UserName, Password);

            try
            {
                if (EnableSsl)
                {
                    ftpClient.EncryptionMode = FtpEncryptionMode.Explicit;
                    ftpClient.DataConnectionType = FtpDataConnectionType.PORT;
                }

                if (!string.IsNullOrEmpty(ExternalIp))
                    ftpClient.AddressResolver = () => ExternalIp;

                if (EnablePassive)
                    ftpClient.DataConnectionType = FtpDataConnectionType.AutoPassive;

                ftpClient.Connect();

                var listing = ftpClient.GetNameListing(Path);

                Console.WriteLine("Result: ");
                foreach (var s in listing)
                {
                    Console.WriteLine(s);
                }

                Console.WriteLine("Press any key to exit...");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                ftpClient.Disconnect();
            }

        }
    }
}
