using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.Adapters
{
    public class IntegracaoCMD
    {
        Process process;
        public void AbrirCMD()
        {
            process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.UseShellExecute = false;
            process.Start();
        }

        public string ChamarAplicativo()
        {
            process.StandardInput.WriteLine("ipconfig");
            process.StandardInput.Flush();
            process.StandardInput.WriteLine("cd AppData");
            process.StandardInput.Flush();
            process.StandardInput.WriteLine("dir");
            process.StandardInput.Flush();
            process.StandardInput.Close();
            //process.WaitForExit();
            return process.StandardOutput.ReadToEnd();
        }

        public void FecharCMD()
        {
            process.StandardInput.Close();
        }
    }
}
