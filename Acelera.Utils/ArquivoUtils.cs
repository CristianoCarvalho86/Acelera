using Acelera.Contratos;
using Acelera.Domain;
using Acelera.Domain.Entidades.Interfaces;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts;
using Acelera.Domain.Utils;
using Acelera.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Utils
{
    public static class ArquivoUtils
    {
        public static string ObterNumeroDoLote(string nomeArquivo)
        {
            return nomeArquivo.Split('-')[2];
        }

        public static string AlterarNumeroDoLote(string nomeArquivo)
        {
            return nomeArquivo.Split('-')[2];
        }

        public static void IgualarCampos(ILinhaArquivo linhaOrigem, ILinhaArquivo linhaDestino, string[] campos, IMyLogger logger = null)
        {
            if (logger != null)
                logger.AbrirBloco("IGUALANDO CAMPOS DAS LINHAS:");
            var nomeCampo = string.Empty;
            foreach (var campo in campos)
            {
                linhaDestino.ObterCampoDoArquivo(campo).AlterarValor(linhaOrigem.ObterCampoDoArquivo(campo).ValorFormatado);
            }
            if (logger != null)
                logger.FecharBloco();
        }

        public static void IgualarCamposQueExistirem(ILinhaArquivo linhaOrigem, ILinhaArquivo linhaDestino, IMyLogger logger = null)
        {
            if(logger != null)
            logger.AbrirBloco("IGUALANDO CAMPOS DAS LINHAS:");
            var nomeCampo = string.Empty;
            foreach (var campo in linhaOrigem.Campos)
            {
                linhaDestino.ObterCampoSeExistir(campo.ColunaArquivo)?.AlterarValor(linhaOrigem[campo.ColunaArquivo]);
            }
            if (logger != null)
                logger.FecharBloco();
        }

        public static void IgualarCamposQueExistirem(IArquivo arquivoOrigem, IArquivo arquivoDestino)
        {
            if (arquivoOrigem.Linhas.Count != arquivoDestino.Linhas.Count)
                throw new Exception("ARQUIVOS COM QUANTIDADE DE LINHAS DIFERENTES.");

            var nomeCampo = string.Empty;
            foreach (var linha in arquivoOrigem.Linhas)
                foreach (var campo in arquivoOrigem.CamposDoBody)
                {
                    nomeCampo = campo;
                    if (campo == "NR_SEQ_EMISSAO")
                        nomeCampo = "NR_SEQUENCIAL_EMISSAO";

                    if (!arquivoDestino.CamposDoBody.Contains(nomeCampo))
                        continue;

                    arquivoDestino.AlterarLinha(linha.Index, nomeCampo, arquivoOrigem.ObterLinha(linha.Index).ObterCampoDoArquivo(nomeCampo).ValorFormatado);
                }
        }

        public static void IgualarCampos(IArquivo arquivoOrigem, IArquivo arquivoDestino, string[] campos, bool linhaUnicaNaOrigem = false, bool adicionaValidacao = true)
        {
            var nomeCampo = string.Empty;
            foreach (var linha in arquivoDestino.Linhas)
                foreach (var campo in campos)
                {
                    nomeCampo = campo;
                    if (campo == "NR_SEQ_EMISSAO")
                        nomeCampo = "NR_SEQUENCIAL_EMISSAO";

                    var index = linhaUnicaNaOrigem ? 0 : linha.Index;
                    arquivoDestino.AlterarLinha(linha.Index, nomeCampo, arquivoOrigem.ObterLinha(index).ObterCampoDoArquivo(nomeCampo).ValorFormatado);
                }
        }

        public static IArquivo CarregarArquivo(IArquivo arquivo, int qtdLinhas, OperadoraEnum operadora, IMyLogger logger)
        {
            logger.AbrirBloco($"INICIANDO CARREGAMENTO DE ARQUIVO DO TIPO: {arquivo.tipoArquivo.ObterTexto()} - OPERACAO: {operadora.ObterTexto()}");
            var arquivoGerado = ArquivoOrigem.ObterArquivoAleatorio(arquivo.tipoArquivo, operadora, Parametros.pastaOrigem);
            arquivo.Carregar(arquivoGerado, 1, 1, qtdLinhas);
            logger.Escrever("ARQUIVO GERADO " + arquivo.NomeArquivo);
            logger.FecharBloco();
            return arquivo;
        }

    }
}
