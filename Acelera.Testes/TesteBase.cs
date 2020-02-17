using Acelera.Testes.Adapters;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes
{
    public abstract class TesteBase
    {
        IntegracaoCMD integracao;
        private string pastaOrigem
        {
            get
            {
                var origem = ConfigurationManager.AppSettings.Get("PastaOrigem");
                if (string.IsNullOrEmpty(origem))
                    throw new Exception("Pasta de Origem nao definida");
                if (!origem.EndsWith("\\"))
                    origem += "\\";
                return origem;
            }
        }
        private string pastaDestino
        {
            get
            {
                var origem = ConfigurationManager.AppSettings.Get("PastaDestino");
                if (string.IsNullOrEmpty(origem))
                    throw new Exception("Pasta de Destino nao definida");
                if (!origem.EndsWith("\\"))
                    origem += "\\";
                return origem;
            }
        }
        protected string ObterArquivoOrigem(string nomeArquivo)
        {
            return pastaOrigem + nomeArquivo;
        }

        protected string ObterArquivoDestino(string nomeArquivo)
        {
            return pastaDestino + nomeArquivo;
        }

        protected string ChamarExecucao()
        {
            integracao = new IntegracaoCMD();
            integracao.AbrirCMD();
            return integracao.ChamarAplicativo();
        }

        protected string ObterRetornoUltimoMetodo()
        {
            return "";
        }
    }
}
