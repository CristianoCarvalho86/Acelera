using Acelera.Contratos;
using Acelera.Domain.Enums;
using Acelera.Domain.Layouts;
using Acelera.Logger;
using Acelera.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.RegrasNegocio
{
    public class CancelamentoRegras : BaseRegras
    {
        public CancelamentoRegras(IMyLogger logger) : base(logger)
        {

        }

        public void CriarArquivoCancelamento(IArquivo ArquivoEmissao, IArquivo ArquivoCancelamento, string cdTipoEmissao, string cdMovtoCobranca = "02",
string nrSequencialEmissao = "")
        {
            foreach (var linha in ArquivoEmissao.Linhas)
            {
                ArquivoCancelamento.AdicionarLinha(CriarLinhaCancelamento(linha, cdTipoEmissao, cdMovtoCobranca, nrSequencialEmissao));
            }
        }

        public ILinhaArquivo CriarLinhaCancelamento(ILinhaArquivo linhaArquivoEmissao, string cdTipoEmissao, string cdMovtoCobranca = "02",
        string nrSequencialEmissao = "")
        {
            logger.AbrirBloco("CRIANDO LINHA DE CANCELAMENTO.");
            logger.Escrever($"Utilizando a linha de emissao : {linhaArquivoEmissao.ObterTexto()}");

            var linhaCancelamento = linhaArquivoEmissao.Clone();
            var idTransacaoDaLinhaOriginal = linhaArquivoEmissao.ObterCampoSeExistir("ID_TRANSACAO").ValorFormatado;

            linhaCancelamento.ObterCampoDoArquivo("ID_TRANSACAO_CANC").AlterarValor(idTransacaoDaLinhaOriginal);
            linhaCancelamento.ObterCampoDoArquivo("CD_TIPO_EMISSAO").AlterarValor(cdTipoEmissao);
            linhaCancelamento.ObterCampoDoArquivo("NR_PARCELA").AlterarValor((linhaCancelamento.ObterValorInteiro("NR_PARCELA")).ToString());
            linhaCancelamento.ObterCampoDoArquivo("NR_ENDOSSO").AlterarValor(ParametrosRegrasEmissao.CarregaProximoNumeroEndosso(linhaCancelamento));
            nrSequencialEmissao = string.IsNullOrEmpty(nrSequencialEmissao) ? ParametrosRegrasEmissao.CarregaProximoNumeroSequencialEmissao(linhaArquivoEmissao, linhaArquivoEmissao.OperadoraDoArquivo).ToString() : nrSequencialEmissao;
            linhaCancelamento.ObterCampoDoArquivo("NR_SEQUENCIAL_EMISSAO").AlterarValor(nrSequencialEmissao);
            linhaCancelamento.ObterCampoDoArquivo("CD_MOVTO_COBRANCA").AlterarValor(cdMovtoCobranca);

            logger.FecharBloco();
            return linhaCancelamento;
        }

    }
}
