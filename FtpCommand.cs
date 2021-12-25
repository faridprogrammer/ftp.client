using System;
using System.Collections.Generic;
using System.Text;
using CommandLine;

namespace Ftp.Client
{
    public class FtpCommand : ICommand
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



        public virtual void Execute()
        {

        }
    }
}
