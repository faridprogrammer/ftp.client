using System;
using System.Linq;
using CommandLine;
using FluentFTP;

namespace Ftp.Client.Commands
{
    public abstract class FtpCommand : ICommand
    {
        [Option('h', "Host", Required = true)]
        public string Host
        {
            get;
            set;
        }

        [Option('u', "username", Required = true)]
        public string UserName
        {
            get;
            set;
        }

        [Option('s', "password", Required = false)]
        public string Password
        {
            get;
            set;
        }

        [Option('l', "ssl", Required = false, HelpText = "Enable ssl support")]
        public bool EnableSsl
        {
            get;
            set;
        }

        [Option('v', "passive", Required = false, HelpText = "Set true to enable passive mode")]
        public bool EnablePassive
        {
            get;
            set;
        }

        [Option('e', "external-ip", Required = false, HelpText = "Set this parameter to your NAT outgoing IP if you are operating within a NAT")]
        public string ExternalIp
        {
            get;
            set;
        }


        [Option('r', "certificate", Required = false, HelpText = "Certificate string. If this parameter has been set then the validation will occur.")]
        public string Certificate
        {
            get;
            set;
        }

        [Option('d', "debug", Required = false, HelpText = "Enables detailed logging.")]
        public bool DebugMode
        {
            get;
            set;
        }

        [Option('a', "active_ports", Required = false, HelpText = "Comma separated active ports")]
        public string ActivePorts
        {
            get;
            set;
        }

        public void Execute()
        {
            var ftpClient = new FtpClient(Host, UserName, Password);
            ConfigureFtpClient(ftpClient);
            ftpClient.Connect();
            try
            {
                Execute(ftpClient);
                Console.WriteLine("Press any key to exit...");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                ftpClient?.Disconnect();
            }

        }

        protected abstract void Execute(IFtpClient ftpClient);

        protected virtual void ConfigureFtpClient(FtpClient ftpClient)
        {
            if (DebugMode)
                ftpClient.OnLogEvent += (level, s) => Console.WriteLine($"{level}: {s}");

            if (EnableSsl)
            {
                ftpClient.EncryptionMode = FtpEncryptionMode.Explicit;
                ftpClient.DataConnectionType = FtpDataConnectionType.PORT;
            }

            if (!string.IsNullOrEmpty(ExternalIp))
                ftpClient.AddressResolver = () => ExternalIp;

            if (EnablePassive)
                ftpClient.DataConnectionType = FtpDataConnectionType.AutoPassive;

            if (!string.IsNullOrEmpty(ActivePorts))
            {
                ftpClient.ActivePorts = ActivePorts.Split(",").Select(s => int.Parse(s.Trim())).ToArray();
            }

            ftpClient.ValidateCertificate += (control, args) =>
            {
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Certificate to validate: " + args?.Certificate?.GetCertHashString());
                Console.ResetColor();

                if (!string.IsNullOrEmpty(Certificate))
                {
                    var isValid = args.Certificate.GetCertHashString()?.ToUpper() == Certificate.Replace(":", "").ToUpper();
                    if (!isValid)
                        throw new InvalidOperationException();
                }
            };

        }
    }
}
