using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_3;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP3.FG05.PROC38
{
    [TestClass]
    public class PROC38_Layout93_VIVO : TestesFG05
    {

        /// <summary>
        /// Informar CD_COBERTURA que esteja parcialmente preenchida na tabela TAB_PRM_COBERTURA_7007, isto é, com campos em branco, como CD_CLASSE_COBERTURA, DT_INICIO_VIGENCIA e DT_FIM_VIGENCIA
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4414()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "4414", "FG05 - PROC38 - ");

            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            AlterarLinha(0, "CD_COBERTURA", "00084");
            AlterarLinha(0, "CD_RAMO", "31");
            AlterarLinha(0, "CD_PRODUTO", "31523");

            SalvarArquivo("PROC38_4414");

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "38", 1);

        }

        /// <summary>
        /// Informar CD_COBERTURA que não esteja parametrizada na tabela TAB_PRM_COBERTURA_7007, mas que exista nas demais tabelas de cobertura, como a 7009
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4415()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "4415", "FG05 - PROC38 - ");

            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            AlterarLinha(0, "CD_CONTRATO", AlterarUltimasPosicoes(ObterValorFormatado(0, "CD_CONTRATO"), GerarNumeroAleatorio(8)));
            AlterarLinha(0, "NR_PROPOSTA", ObterValorFormatado(0, "CD_CONTRATO"));
            AlterarLinha(0, "NR_APOLICE", ObterValorFormatado(0, "CD_CONTRATO"));
            AlterarLinha(0, "VL_LMI", ObterValor(0, "VL_IS"));
            AlterarLinha(0, "CD_COBERTURA", "01589");
            AlterarLinha(0, "CD_RAMO", "71");
            AlterarLinha(0, "CD_PRODUTO", "71724");

            AlterarCobertura(false);

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "38", 1);

        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4416()
        {
            IniciarTeste(TipoArquivo.Comissao, "4416", "FG05 - PROC38 - ");

            arquivo = new Arquivo_Layout_9_3_EmsComissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            AlterarLinha(0, "CD_COBERTURA", dados.ObterCoberturaValida(false));

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "38", 1);

        }

        /// <summary>
        /// Informar CD_COBERTURA que não esteja parametrizada na tabela TAB_PRM_COBERTURA_7007, mas que exista nas demais tabelas de cobertura, como a 7009
        /// </summary>
        [TestMethod]
        [Ignore]
        [TestCategory("Com Critica")]
        public void SAP_4417()
        {
            IniciarTeste(TipoArquivo.Comissao, "4417", "FG05 - PROC38 - ");

            arquivo = new Arquivo_Layout_9_3_EmsComissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            AlterarLinha(0, "CD_COBERTURA", dados.ObterCoberturaValida(false));

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "38", 1);

        }

        
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4419()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "4419", "FG05 - PROC38 - ");

            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            AlterarLinha(0, "CD_CONTRATO", AlterarUltimasPosicoes(ObterValorFormatado(0, "CD_CONTRATO"), GerarNumeroAleatorio(8)));
            AlterarLinha(0, "NR_PROPOSTA", ObterValorFormatado(0, "CD_CONTRATO"));
            AlterarLinha(0, "NR_APOLICE", ObterValorFormatado(0, "CD_CONTRATO"));
            AlterarLinha(0, "VL_LMI", ObterValor(0, "VL_IS"));

            SalvarArquivo();

            ExecutarEValidarDesconsiderandoErro(CodigoStage.AprovadoNegocioComDependencia, "38");

        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4420()
        {
            IniciarTeste(TipoArquivo.Comissao, "4420", "FG05 - PROC38 - ");

            arquivo = new Arquivo_Layout_9_3_EmsComissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            AlterarLinha(0, "CD_CONTRATO", AlterarUltimasPosicoes(ObterValorFormatado(0, "CD_CONTRATO"), GerarNumeroAleatorio(8)));

            SalvarArquivo();

            ExecutarEValidarDesconsiderandoErro(CodigoStage.AprovadoNegocioComDependencia, "38");

        }

    }
}