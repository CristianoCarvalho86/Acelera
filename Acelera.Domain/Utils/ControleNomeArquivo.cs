using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Domain.Utils
{
    public class ControleNomeArquivo
    {
        //Sinistro:0,
        //Cliente:0,
        //Comissao:0,
        //LanctoComissao:0,
        //OCRCobranca:0,
        //ParcEmissao:0,
        //ParcEmissaoAuto:0,
        //SequencialPapcard:0

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
            return ObtemValor(tipo.ObterTexto(),4);
        }

        public string ObtemValor(string chave, int posicoesTotais = 0)
        {
            var valoresAtuais = File.ReadAllText(enderecoArquivo).Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Replace(Environment.NewLine, ""));
            var registroAtual = valoresAtuais.Where(x => x.Contains(chave)).FirstOrDefault();
            if (string.IsNullOrEmpty(registroAtual))
                throw new Exception("NAO FOI ENCONTRADO O NUMERO PARA SER COLOCADO NO ARQUIVO.");

            var valor = registroAtual.Substring(chave.Length + 1).Replace(",", "");// +1 para remover o ':'
            if (!int.TryParse(valor, out int resultado))
                throw new Exception($"NAO EXISTE VALOR PARA O CAMPO {chave}");

            AtualizaResultado(chave, resultado, resultado + 1);

            var retorno = "";
            if (posicoesTotais > 0)
                retorno = (resultado + 1).ToString().PadLeft(posicoesTotais, '0');
            else
                retorno = (resultado + 1).ToString();
            return retorno;
        }


        private void AtualizaResultado(string chave, int valorAnterior, int valorNovo)
        {
            try
            {
                var texto = File.ReadAllText(enderecoArquivo);
                texto = texto.Replace($"{chave}:{valorAnterior.ToString()}", $"{chave}:{valorNovo.ToString()}");
                File.WriteAllText(enderecoArquivo, texto);
            }
            catch (Exception ex)
            {
                throw new Exception("ERRO AO ATUALIZAR VALOR NO CONTROLE ARQUIVO. : " + ex.ToString());
            }

        }

    }
}
