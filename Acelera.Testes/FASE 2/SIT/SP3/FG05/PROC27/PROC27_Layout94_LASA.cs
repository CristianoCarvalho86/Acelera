using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP3.FG05.PROC27
{
    [TestClass]
    public class PROC27_Layout94_LASA : TestesFG05
    {

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4258()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "4258", "FG05 - PROC27");

            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

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
        public void SAP_4259()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "4259", "FG05 - PROC27");

            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            AlterarLinha(0, "CD_CLIENTE", dados.ObterCDSeguradoraDoTipoParceiro("SE"));
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
        public void SAP_4260()
        {
            IniciarTeste(TipoArquivo.Sinistro, "4260", "FG05 - PROC27");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            AlterarLinha(0, "CD_CLIENTE", dados.ObterParceiroNegocioNaoExistente());

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "27", 1);

        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4261()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "4261", "FG05 - PROC27");

            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            AlterarLinha(0, "CD_CLIENTE", dados.ObterCDSeguradoraDoTipoParceiro("CL"));
            AlterarLinha(0, "CD_CONTRATO", AlterarUltimasPosicoes(ObterValorFormatado(0, "CD_CONTRATO"), GerarNumeroAleatorio(8)));
            AlterarLinha(0, "NR_PROPOSTA", ObterValorFormatado(0, "CD_CONTRATO"));
            AlterarLinha(0, "NR_APOLICE", ObterValorFormatado(0, "CD_CONTRATO"));
            AlterarLinha(0, "CD_SEGURADORA", "5908");
            AlterarLinha(0, "VL_LMI", ObterValorFormatado(0, "VL_IS"));

            SalvarArquivo();

            ExecutarEValidarDesconsiderandoErro(CodigoStage.AprovadoNegocioComDependencia, "27");

        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4262()
        {
            IniciarTeste(TipoArquivo.Sinistro, "4258", "FG05 - PROC27");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            AlterarLinha(0, "CD_CLIENTE", dados.ObterCDSeguradoraDoTipoParceiro("CL"));

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNegocioComDependencia);

        }
    }
}
