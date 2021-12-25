using System;
using CommandLine;
using FluentFTP;

namespace Ftp.Client
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

                var result = ftpClient.UploadFile(LocalFile, Path);


                Console.WriteLine("Result: ");
                Console.WriteLine(result);

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
