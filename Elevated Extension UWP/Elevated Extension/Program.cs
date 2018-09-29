using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Elevated_Extension
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 2)
            {
                if (args[2] == "/admin")
                {
                    // re-launch as admin
                    ProcessStartInfo info = new ProcessStartInfo();
                    info.Verb = "runas";
                    info.UseShellExecute = true;
                    string localAppDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                    info.FileName = localAppDataPath + @"\microsoft\windowsapps\ElevatedExtension.exe"; // path to the appExecutionAlias
                    Process.Start(info); // launch new elevated instance
                    return;
                }
            }

            AutoResetEvent areWeDone = new AutoResetEvent(false);
            // do some task, then exit
            areWeDone.WaitOne(10000); 
        }
    }
}
