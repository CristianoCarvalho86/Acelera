using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_3;
using Acelera.Domain.Layouts._9_4;
using Acelera.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP3.FG05.PROC212
{
    [TestClass]
    public class PROC212_Layout94_SOFTBOX : TestesFG05
    {

        /// <summary>
        /// Em um arquivo, enviar emissão da apolice com CD_TIPO_EMISSAO=20 e NR_SEQ_EMISSAO=1.Registro deve ser gravado na ODS. 
        /// Em outro arquivo, enviar emissão de cancelamento do mesmo contrato, informando CD_TIPO_EMISSAO=10. Manter NR_SEQ_EMISSAO=1.
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4547()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "4547", "FG05 - PROC212 - ");

            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1 , OperadoraEnum.SOFTBOX);

            AlterarLinha(0, "CD_CONTRATO", StringUtils.AlterarUltimasPosicoes(ObterValorFormatado(0, "CD_CONTRATO"), GerarNumeroAleatorio(8)));
            AlterarLinha(0, "NR_PROPOSTA", ObterValorFormatado(0, "CD_CONTRATO"));
            AlterarLinha(0, "NR_APOLICE", ObterValorFormatado(0, "CD_CONTRATO"));
            AlterarLinha(0, "CD_TIPO_EMISSAO", "20");
            AlterarLinha(0, "ID_TRANSACAO_CANC", "");
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", "2");
            AlterarLinha(0, "NR_ENDOSSO", GerarNumeroAleatorio(8));
            AlterarLinha(0, "VL_LMI", ObterValor(0, "VL_IS"));

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "212", 1);


        }

        /// <summary>
        /// Em um arquivo, enviar emissão da apolice com CD_TIPO_EMISSAO=20 e NR_SEQ_EMISSAO=1.Registro deve ser gravado na ODS. 
        /// Em outro arquivo, enviar emissão de cancelamento do mesmo contrato, informando CD_TIPO_EMISSAO=11. Manter NR_SEQ_EMISSAO=1.
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4548()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "4548", "FG05 - PROC212 - ");

            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.SOFTBOX);

            AlterarLinha(0, "CD_CONTRATO", StringUtils.AlterarUltimasPosicoes(ObterValorFormatado(0, "CD_CONTRATO"), GerarNumeroAleatorio(8)));
            AlterarLinha(0, "NR_PROPOSTA", ObterValorFormatado(0, "CD_CONTRATO"));
            AlterarLinha(0, "NR_APOLICE", ObterValorFormatado(0, "CD_CONTRATO"));
            AlterarLinha(0, "CD_TIPO_EMISSAO", "7");
            AlterarLinha(0, "ID_TRANSACAO_CANC", "");
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", "2");
            AlterarLinha(0, "NR_ENDOSSO", GerarNumeroAleatorio(8));
            AlterarLinha(0, "VL_LMI", ObterValor(0, "VL_IS"));

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "212", 1);


        }


        /// <summary>
        /// Em um arquivo, enviar emissão da apolice com CD_TIPO_EMISSAO=20 e NR_SEQ_EMISSAO=1.Registro deve ser gravado na ODS. 
        /// Em outro arquivo, enviar emissão de cancelamento do mesmo contrato, informando CD_TIPO_EMISSAO=11. Manter NR_SEQ_EMISSAO=1.
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4551()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "4551", "FG05 - PROC212 - ");

            var arquivoods = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivoods, 1, OperadoraEnum.SOFTBOX);

            arquivoods.AlterarLinha(0, "CD_TIPO_EMISSAO", "20");
            arquivoods.AlterarLinha(0, "NR_SEQ_EMISSAO", "1");
            arquivoods.AlterarLinha(0, "NR_ENDOSSO", "0");
            var idCanc = arquivoods.ObterValorFormatadoSeExistirCampo(0, "ID_TRANSACAO");

            EnviarParaOdsAlterandoCliente(arquivoods);

            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.SOFTBOX);

            ArquivoUtils.IgualarCampos(arquivoods, arquivo, new string[] { "CD_CONTRATO", "NR_APOLICE", "NR_PROPOSTA" });
            AlterarLinha(0, "CD_TIPO_EMISSAO", "10");
            AlterarLinha(0, "ID_TRANSACAO_CANC", idCanc);
            AlterarLinha(0, "CD_MOVTO_COBRANCA", "02");
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", "2");
            AlterarLinha(0, "NR_ENDOSSO", "0");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNegocioComDependencia);


        }

        /// <summary>
        /// Em um arquivo, enviar emissão da apolice com CD_TIPO_EMISSAO=20 e NR_SEQ_EMISSAO=1.Registro deve ser gravado na ODS. 
        /// Em outro arquivo, enviar emissão de cancelamento do mesmo contrato, informando CD_TIPO_EMISSAO=11. Manter NR_SEQ_EMISSAO=1.
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4552()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "4552", "FG05 - PROC212 - ");

            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.SOFTBOX);

            AlterarLinha(0, "CD_CONTRATO", StringUtils.AlterarUltimasPosicoes(ObterValorFormatado(0, "CD_CONTRATO"), GerarNumeroAleatorio(8)));
            AlterarLinha(0, "NR_PROPOSTA", ObterValorFormatado(0, "CD_CONTRATO"));
            AlterarLinha(0, "NR_APOLICE", ObterValorFormatado(0, "CD_CONTRATO"));
            AlterarLinha(0, "CD_TIPO_EMISSAO", "18");
            AlterarLinha(0, "ID_TRANSACAO_CANC", "");
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", "1");
            AlterarLinha(0, "NR_ENDOSSO", "0");
            AlterarLinha(0, "VL_LMI", ObterValor(0, "VL_IS"));

            EnviarParaOdsAlterandoCliente(arquivo);
            var arquivoods = arquivo.Clone();

            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.SOFTBOX);

            var campos = new string[] { "CD_CONTRATO", "NR_APOLICE", "NR_PROPOSTA" };
            ArquivoUtils.IgualarCampos(arquivoods, arquivo, campos);
            AlterarLinha(0, "CD_TIPO_EMISSAO", "20");
            AlterarLinha(0, "ID_TRANSACAO_CANC", "");
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", "2");
            AlterarLinha(0, "NR_ENDOSSO", GerarNumeroAleatorio(8));
            AlterarLinha(0, "VL_LMI", ObterValor(0, "VL_IS"));

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNegocioComDependencia);


        }

    }
}
