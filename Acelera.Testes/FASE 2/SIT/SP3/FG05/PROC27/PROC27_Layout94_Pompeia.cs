using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Acelera.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP3.FG05.PROC27
{
    [TestClass]
    public class PROC27_Layout94_POMPEIA : TestesFG05
    {

        /// <summary>
        /// Gerar arquivo cujo CD_CLIENTE não esteja cadastrado na tabela TAB_ODS_PARCEIRO_NEGOCIO_2000 com CD_TIPO_PARCEIRO_NEGOCIO=CL. Utilizar CD_EXTERNO para essa comparação
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4268()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "4268", "FG05 - PROC27");

            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.POMPEIA);

            AlterarLinha(0, "CD_CLIENTE", dados.ObterParceiroNegocioNaoExistente());

            SalvarArquivo(false,"PROC27");

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "27", 1);

        }

        /// <summary>
        /// Gerar arquivo cujo CD_CLIENTE não esteja cadastrado na tabela TAB_ODS_PARCEIRO_NEGOCIO_2000 com CD_TIPO_PARCEIRO_NEGOCIO=CL. Utilizar CD_EXTERNO para essa comparação
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4269()
        {
            IniciarTeste(TipoArquivo.Sinistro, "4269", "FG02 - PROC1002");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.SINISTRO-EV-0001-20191223.txt"));

            AlterarLinha(0, "CD_CLIENTE", dados.ObterCDSeguradoraDoTipoParceiro("SE"));
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "7");
            AlterarLinha(0, "CD_BANCO", dados.ObterCDBancoSeg(true));
            AlterarLinha(0, "CD_BANCO_SEG", dados.ObterCDBancoSeg(true));
            AlterarLinha(0, "NR_CONTA_DIG_SEG", "7");
            AlterarLinha(0, "TP_SINISTRO", "04");
            AlterarLinha(0, "CD_FORMA_PAGTO", "D");
            RemoverLinhasExcetoAsPrimeiras(1);

            SalvarArquivo("PROC27");

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "27", 1);

        }

        /// <summary>
        /// Gerar arquivo cujo CD_CLIENTE não esteja cadastrado na tabela TAB_ODS_PARCEIRO_NEGOCIO_2000 com CD_TIPO_PARCEIRO_NEGOCIO=CL. Utilizar CD_EXTERNO para essa comparação
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4270()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "4270", "FG05 - PROC27");

            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.POMPEIA);

            AlterarLinha(0, "CD_CONTRATO", StringUtils.AlterarUltimasPosicoes(ObterValorFormatado(0, "CD_CONTRATO"), GerarNumeroAleatorio(8)));
            AlterarLinha(0, "NR_PROPOSTA", ObterValorFormatado(0, "CD_CONTRATO"));
            AlterarLinha(0, "NR_APOLICE", ObterValorFormatado(0, "CD_CONTRATO"));
            AlterarLinha(0, "CD_CLIENTE", dados.ObterCDSeguradoraDoTipoParceiro("CL"));
            AlterarLinha(0, "CD_SEGURADORA", "5908");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNegocioComDependencia);

        }

        /// <summary>
        /// Gerar arquivo cujo CD_CLIENTE não esteja cadastrado na tabela TAB_ODS_PARCEIRO_NEGOCIO_2000 com CD_TIPO_PARCEIRO_NEGOCIO=CL. Utilizar CD_EXTERNO para essa comparação
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4271()
        {
            IniciarTeste(TipoArquivo.Sinistro, "4271", "FG05 - PROC27");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            CarregarArquivo(arquivo, 1, OperadoraEnum.POMPEIA);

            AlterarLinha(0, "CD_CLIENTE", dados.ObterCDSeguradoraDoTipoParceiro("CL"));

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNegocioComDependencia);

        }

    }
}
