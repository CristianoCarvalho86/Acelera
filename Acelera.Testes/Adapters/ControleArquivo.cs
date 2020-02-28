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
    public class ControleNomeArquivo
    {
       //Sinistro:0,
       //Cliente:0,
       //Comissao:0,
       //LanctoComissao:0,
       //OCRCobranca:0,
       //ParcEmissao:0,
       //ParcEmissaoAuto:0

        private static ControleNomeArquivo instancia;
        private string enderecoArquivo;
        private ControleNomeArquivo()
        {
            enderecoArquivo = ConfigurationManager.AppSettings["PastaControleArquivo"];
            if (!File.Exists(enderecoArquivo))
                throw new Exception("Controle Arquivo nao encontrado.");
        }

        public static ControleNomeArquivo Instancia
        {
            get
            {
                try
                {
                    if (instancia == null)
                    {
                        instancia = new ControleNomeArquivo();
                    }
                    return instancia;
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao obter Instancia de Controle Arquivo");
                }
            }
        }

        public string ObtemValor(TipoArquivo tipo)
        {
            var valoresAtuais = File.ReadAllText(enderecoArquivo).Split(new string[] { "," },StringSplitOptions.RemoveEmptyEntries);
            var registroAtual = valoresAtuais.Where(x => x.Contains(tipo.ObterTexto())).FirstOrDefault();
            if (string.IsNullOrEmpty(registroAtual))
                throw new Exception("NAO FOI ENCONTRADO O NUMERO PARA SER COLOCADO NO ARQUIVO.");
            
            var valor = registroAtual.Substring(tipo.ObterTexto().Length + 1).Replace(",", "");// +1 para remover o ':'
            if (!int.TryParse(valor, out int resultado))
                throw new Exception($"NAO EXISTE VALOR PARA O CAMPO {tipo.ObterTexto()}");

            AtualizaResultado(tipo, resultado, resultado + 1);

            return (resultado + 1).ToString().PadLeft(6,'0');
        }

        private void AtualizaResultado(TipoArquivo tipo, int valorAnterior, int valorNovo)
        {
            try
            {
                var texto = File.ReadAllText(enderecoArquivo);
                texto = texto.Replace($"{tipo.ObterTexto()}:{valorAnterior.ToString()}", $"{tipo.ObterTexto()}:{valorNovo.ToString()}");
                File.WriteAllText(enderecoArquivo, texto);
            }
            catch (Exception ex)
            {
                throw new Exception("ERRO AO ATUALIZAR VALOR NO CONTROLE ARQUIVO. : " + ex.ToString());
            }

        }

    }
}
