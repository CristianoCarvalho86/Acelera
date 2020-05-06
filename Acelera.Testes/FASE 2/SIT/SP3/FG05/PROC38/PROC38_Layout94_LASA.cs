using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP3.FG05.PROC38
{
    [TestClass]
    public class PROC38_Layout94_LASA : TestesFG05
    {

        /// <summary>
        /// Informar CD_COBERTURA que esteja parcialmente preenchida na tabela TAB_PRM_COBERTURA_7007, isto é, com campos em branco, como CD_CLASSE_COBERTURA, DT_INICIO_VIGENCIA e DT_FIM_VIGENCIA
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4421()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "4421", "FG05 - PROC38 - ");

            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

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
        public void SAP_4422()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "4422", "FG05 - PROC38 - ");

            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            AlterarLinha(0, "CD_COBERTURA", dados.ObterCoberturaValida(false));

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "38", 1);

        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4423()
        {
            IniciarTeste(TipoArquivo.Comissao, "4423", "FG05 - PROC38 - ");

            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

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
        public void SAP_4424()
        {
            IniciarTeste(TipoArquivo.Comissao, "4424", "FG05 - PROC38 - ");

            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            AlterarLinha(0, "CD_COBERTURA", dados.ObterCoberturaValida(false));

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "38", 1);

        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4425()
        {
            IniciarTeste(TipoArquivo.Sinistro, "4425", "FG05 - PROC38 - ");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

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
        public void SAP_4426()
        {
            IniciarTeste(TipoArquivo.Sinistro, "4426", "FG05 - PROC38 - ");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            AlterarLinha(0, "CD_COBERTURA", dados.ObterCoberturaValida(false));

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "38", 1);

        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4427()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "4427", "FG05 - PROC38 - ");

            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            AlterarLinha(0, "CD_COBERTURA", dados.ObterCoberturaValida(true));

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNegocioComDependencia);

        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4428()
        {
            IniciarTeste(TipoArquivo.Comissao, "4428", "FG05 - PROC38 - ");

            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            AlterarLinha(0, "CD_COBERTURA", dados.ObterCoberturaValida(true));

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNegocioComDependencia);

        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4429()
        {
            IniciarTeste(TipoArquivo.Sinistro, "4429", "FG05 - PROC38 - ");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            AlterarLinha(0, "CD_COBERTURA", dados.ObterCoberturaValida(true));

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNegocioComDependencia);

        }

    }
}