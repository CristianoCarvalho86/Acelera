using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Utils
{
    public static class CommandUtils
    {
        public static int RunBatch(string command, out string output, out string error)
        {
            int exitCode;
            ProcessStartInfo processInfo;
            Process process;

            processInfo = new ProcessStartInfo("cmd.exe", "/c " + command);
            processInfo.CreateNoWindow = true;
            processInfo.UseShellExecute = false;
            // *** Redirect the output ***
            processInfo.RedirectStandardError = true;
            processInfo.RedirectStandardOutput = true;

            process = Process.Start(processInfo);
            var inProcess = true;

            var countSegundos = 0;
            while (inProcess)
            {
                process.Refresh();
                System.Threading.Thread.Sleep(1000);
                countSegundos++;
                if (process.HasExited || countSegundos >= 150)
                {
                    if(!process.HasExited)
                        process.Kill();
                    inProcess = false;
                }

            }

            output = process.StandardOutput.ReadToEnd();
            error = process.StandardError.ReadToEnd();

            exitCode = process.ExitCode;

            process.Close();

            return exitCode;
        }
    }
}
