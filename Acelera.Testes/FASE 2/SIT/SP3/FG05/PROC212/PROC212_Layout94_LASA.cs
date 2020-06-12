using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_3;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP3.FG05.PROC212
{
    [TestClass]
    public class PROC212_Layout94_LASA : TestesFG05
    {

        /// <summary>
        /// Em um arquivo, enviar emissão da apolice com CD_TIPO_EMISSAO=20 e NR_SEQ_EMISSAO=1.Registro deve ser gravado na ODS. 
        /// Em outro arquivo, enviar emissão de cancelamento do mesmo contrato, informando CD_TIPO_EMISSAO=10. Manter NR_SEQ_EMISSAO=1.
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4539()
        {

            IniciarTeste(TipoArquivo.ParcEmissao, "4539", "FG05 - PROC212");

            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            AlterarLinha(0, "CD_CONTRATO", AlterarUltimasPosicoes(ObterValorFormatado(0, "CD_CONTRATO"), "00002"));
            AlterarLinha(0, "NR_PROPOSTA", ObterValorFormatado(0, "CD_CONTRATO"));
            AlterarLinha(0, "NR_APOLICE", ObterValorFormatado(0, "CD_CONTRATO"));
            AlterarLinha(0, "CD_TIPO_EMISSAO", "10");
            AlterarLinha(0, "ID_TRANSACAO_CANC", SomarValor(0, "ID_TRANSACAO", 1));
            AlterarLinha(0, "CD_MOVTO_COBRANCA", "02");
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", "2");
            AlterarLinha(0, "NR_ENDOSSO", "12345");
            AlterarLinha(0, "VL_LMI", ObterValor(0, "VL_IS"));

            SalvarArquivo(true);

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "212", 1);


        }

        /// <summary>
        /// Em um arquivo, enviar emissão da apolice com CD_TIPO_EMISSAO=20 e NR_SEQ_EMISSAO=1.Registro deve ser gravado na ODS. 
        /// Em outro arquivo, enviar emissão de cancelamento do mesmo contrato, informando CD_TIPO_EMISSAO=11. Manter NR_SEQ_EMISSAO=1.
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4540()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "4539", "FG05 - PROC212");

            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            AlterarLinha(0, "CD_CONTRATO", AlterarUltimasPosicoes(ObterValorFormatado(0, "CD_CONTRATO"), "00002"));
            AlterarLinha(0, "NR_PROPOSTA", ObterValorFormatado(0, "CD_CONTRATO"));
            AlterarLinha(0, "NR_APOLICE", ObterValorFormatado(0, "CD_CONTRATO"));
            AlterarLinha(0, "CD_TIPO_EMISSAO", "11");
            AlterarLinha(0, "ID_TRANSACAO_CANC", SomarValor(0, "ID_TRANSACAO", 1));
            AlterarLinha(0, "CD_MOVTO_COBRANCA", "02");
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", "2");
            AlterarLinha(0, "NR_ENDOSSO", "12345");
            AlterarLinha(0, "VL_LMI", ObterValor(0, "VL_IS"));

            SalvarArquivo(true);

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "212", 1);

        }


        /// <summary>
        /// Em um arquivo, enviar emissão da apolice com CD_TIPO_EMISSAO=20 e NR_SEQ_EMISSAO=1.Registro deve ser gravado na ODS. 
        /// Em outro arquivo, enviar emissão de cancelamento do mesmo contrato, informando CD_TIPO_EMISSAO=11. Manter NR_SEQ_EMISSAO=1.
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4543()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "4543", "FG05 - PROC212 - ");

            var arquivoods = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivoods, 1, OperadoraEnum.LASA);

            arquivoods.AlterarLinha(0, "CD_TIPO_EMISSAO", "20");
            arquivoods.AlterarLinha(0, "NR_SEQ_EMISSAO", "1");
            arquivoods.AlterarLinha(0, "NR_ENDOSSO", "0");
            var idCanc = arquivoods.ObterValorFormatadoSeExistirCampo(0, "ID_TRANSACAO");

            EnviarParaOds(arquivoods);

            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            IgualarCampos(arquivoods, arquivo, new string[] { "CD_CONTRATO", "NR_APOLICE", "NR_PROPOSTA" });
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
        public void SAP_4544()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "4544", "FG05 - PROC212 - ");

            var arquivoods = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivoods, 1, OperadoraEnum.LASA);

            arquivoods.AlterarLinha(0, "CD_TIPO_EMISSAO", "20");
            arquivoods.AlterarLinha(0, "NR_SEQ_EMISSAO", "1");
            arquivoods.AlterarLinha(0, "NR_ENDOSSO", "0");
            var idCanc = arquivoods.ObterValorFormatadoSeExistirCampo(0, "ID_TRANSACAO");

            EnviarParaOds(arquivoods);

            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            IgualarCampos(arquivoods, arquivo, new string[] { "CD_CONTRATO", "NR_APOLICE", "NR_PROPOSTA" });
            AlterarLinha(0, "CD_TIPO_EMISSAO", "11");
            AlterarLinha(0, "ID_TRANSACAO_CANC", idCanc);
            AlterarLinha(0, "CD_MOVTO_COBRANCA", "02");
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", "2");
            AlterarLinha(0, "NR_ENDOSSO", "0");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNegocioComDependencia);


        }

    }
}
