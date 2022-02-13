using System;
using System.Linq;
using CommandLine;
using FluentFTP;

namespace Ftp.Client.Commands
{
    public abstract class FtpCommand : ICommand
    {
        public void Execute()
        {
            try
            {
                if (Program.Client == null)
                {
                    Console.WriteLine("Ftp command needs a connection run the `connect` command first ...");
                    return;
                }

                Execute(Program.Client);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        protected abstract void Execute(IFtpClient ftpClient);


    }
}
