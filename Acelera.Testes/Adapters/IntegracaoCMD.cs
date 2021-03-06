﻿using Acelera.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.Adapters
{
    public class IntegracaoCMD : IntegracaoCMDItens
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
            process.StartInfo.WorkingDirectory = EnderecoHDB;
            process.Start();
        }

        public void ChamarExecucao()
        {
            process.StandardInput.WriteLine(comandoExecutar);
            process.StandardInput.Flush();
            
        }

        public void ExecutarQuery(string queryValidacao)
        {
            process.StandardInput.WriteLine(ObterComandoSelect(queryValidacao));
            process.StandardInput.Flush();

        }

        public string ObterTextoCMD()
        {
            process.StandardInput.Close();
            return process.StandardOutput.ReadToEnd();
        }

        public void FecharCMD()
        {
            process.StandardInput.Close();
            process.Dispose();
        }
    }
}
