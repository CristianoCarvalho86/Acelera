using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.Adapters
{
    public class ControleArquivo
    {
       //Sinistro:0,
       //Cliente:0,
       //Comissao:0,
       //LanctoComissao:0,
       //OCRCobranca:0,
       //ParcEmissao:0,
       //ParcEmissaoAuto:0

        private string enderecoArquivo;
        private ControleArquivo()
        {
            enderecoArquivo = ConfigurationManager.AppSettings["PastaControleArquivo"];
        }

        private string ObtemValor(TipoArquivo tipo)
        {
            var valoresAtuais = File.ReadAllText(enderecoArquivo).Split(new string[] { "," },StringSplitOptions.RemoveEmptyEntries);
            var registroAtual = valoresAtuais.Where(x => x.Contains(tipo.ObterTexto())).FirstOrDefault();
            if (string.IsNullOrEmpty(registroAtual))
                throw new Exception("NAO FOI ENCONTRADO O NUMERO PARA SER COLOCADO NO ARQUIVO.");
            var valor = registroAtual.Substring(tipo.ObterTexto().Length + 1)// +1 para remover o ':'
        }

        private string


    }
}
