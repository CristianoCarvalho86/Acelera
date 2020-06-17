using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP3.FG05.PROC27
{
    [TestClass]
    public class PROC27_Layout94_SOFTBOX : TestesFG05
    {

        /// <summary>
        /// Gerar arquivo cujo CD_CLIENTE não esteja cadastrado na tabela TAB_ODS_PARCEIRO_NEGOCIO_2000 com CD_TIPO_PARCEIRO_NEGOCIO=CL. Utilizar CD_EXTERNO para essa comparação
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4263()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "4263", "FG05 - PROC27");

            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.SOFTBOX);

            AlterarLinha(0, "CD_CLIENTE", dados.ObterParceiroNegocioNaoExistente());
            AlterarLinha(0, "CD_CONTRATO", AlterarUltimasPosicoes(ObterValorFormatado(0, "CD_CONTRATO"), GerarNumeroAleatorio(8)));
            AlterarLinha(0, "NR_PROPOSTA", ObterValorFormatado(0, "CD_CONTRATO"));
            AlterarLinha(0, "NR_APOLICE", ObterValorFormatado(0, "CD_CONTRATO"));
            AlterarLinha(0, "CD_SEGURADORA", "5908");
            AlterarLinha(0, "VL_LMI", ObterValorFormatado(0, "VL_IS"));

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "27", 1);

        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4264()
        {
            IniciarTeste(TipoArquivo.Sinistro, "4264", "FG05 - PROC27");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            CarregarArquivo(arquivo, 1, OperadoraEnum.SOFTBOX);

            AlterarLinha(0, "CD_CLIENTE", dados.ObterParceiroNegocioNaoExistente());
            AlterarLinha(0, "CD_CONTRATO", AlterarUltimasPosicoes(ObterValorFormatado(0, "CD_CONTRATO"), GerarNumeroAleatorio(8)));
            AlterarLinha(0, "NR_PROPOSTA", ObterValorFormatado(0, "CD_CONTRATO"));
            AlterarLinha(0, "NR_APOLICE", ObterValorFormatado(0, "CD_CONTRATO"));
            AlterarLinha(0, "CD_SEGURADORA", "5908");
            AlterarLinha(0, "VL_LMI", ObterValorFormatado(0, "VL_IS"));

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "27", 1);

        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4265()
        {
            IniciarTeste(TipoArquivo.Sinistro, "4265", "FG05 - PROC27");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            CarregarArquivo(arquivo, 1, OperadoraEnum.SOFTBOX);

            AlterarLinha(0, "CD_CLIENTE", dados.ObterCDSeguradoraDoTipoParceiro("SE"));

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "27", 1);

        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4266()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "4266", "FG05 - PROC27");

            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.SOFTBOX);

            AlterarLinha(0, "CD_CLIENTE", dados.ObterCDSeguradoraDoTipoParceiro("CL"));
            AlterarLinha(0, "CD_CONTRATO", AlterarUltimasPosicoes(ObterValorFormatado(0, "CD_CONTRATO"), GerarNumeroAleatorio(8)));
            AlterarLinha(0, "NR_PROPOSTA", ObterValorFormatado(0, "CD_CONTRATO"));
            AlterarLinha(0, "NR_APOLICE", ObterValorFormatado(0, "CD_CONTRATO"));
            AlterarLinha(0, "CD_SEGURADORA", "5908");
            AlterarLinha(0, "VL_LMI", ObterValorFormatado(0, "VL_IS"));
            AlterarLinha(0, "VL_PREMIO_TOTAL", "30");
            AlterarLinha(0, "VL_PREMIO_LIQUIDO", "15");
            AlterarLinha(0, "VL_IOF", "15");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNegocioComDependencia);

        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4267()
        {
            IniciarTeste(TipoArquivo.Sinistro, "4267", "FG05 - PROC27");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            CarregarArquivo(arquivo, 1, OperadoraEnum.SOFTBOX);

            AlterarLinha(0, "CD_CLIENTE", dados.ObterCDSeguradoraDoTipoParceiro("CL"));

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNegocioComDependencia);

        }
    }
}
