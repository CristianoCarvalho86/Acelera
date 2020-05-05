using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP3.FG05.PROC38
{
    [TestClass]
    public class PROC38_Layout94_SOFTBOX : TestesFG05
    {

        /// <summary>
        /// Informar CD_COBERTURA que esteja parcialmente preenchida na tabela TAB_PRM_COBERTURA_7007, isto é, com campos em branco, como CD_CLASSE_COBERTURA, DT_INICIO_VIGENCIA e DT_FIM_VIGENCIA
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4430()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "4430", "FG05 - PROC38 - ");

            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.SOFTBOX);

            AlterarLinha(0, "CD_COBERTURA", dados.ObterCoberturaValida(false));

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "38", 1);

        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4431()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "4431", "FG05 - PROC38 - ");

            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.SOFTBOX);

            AlterarLinha(0, "CD_COBERTURA", dados.ObterCoberturaValida(false));

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "38", 1);

        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4432()
        {
            IniciarTeste(TipoArquivo.Comissao, "4432", "FG05 - PROC38 - ");

            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.SOFTBOX);

            AlterarLinha(0, "CD_COBERTURA", dados.ObterCoberturaValida(false));

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "38", 1);

        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4433()
        {
            IniciarTeste(TipoArquivo.Comissao, "4433", "FG05 - PROC38 - ");

            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.SOFTBOX);

            AlterarLinha(0, "CD_COBERTURA", dados.ObterCoberturaValida(false));

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "38", 1);

        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4434()
        {
            IniciarTeste(TipoArquivo.Sinistro, "4434", "FG05 - PROC38 - ");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            CarregarArquivo(arquivo, 1, OperadoraEnum.SOFTBOX);

            AlterarLinha(0, "CD_COBERTURA", dados.ObterCoberturaValida(false));

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "38", 1);

        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4435()
        {
            IniciarTeste(TipoArquivo.Sinistro, "4435", "FG05 - PROC38 - ");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            CarregarArquivo(arquivo, 1, OperadoraEnum.SOFTBOX);

            AlterarLinha(0, "CD_COBERTURA", dados.ObterCoberturaValida(false));

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "38", 1);

        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4436()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "4436", "FG05 - PROC38 - ");

            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.SOFTBOX);

            AlterarLinha(0, "CD_COBERTURA", dados.ObterCoberturaValida(true));

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNegocioComDependencia);

        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4437()
        {
            IniciarTeste(TipoArquivo.Comissao, "4437", "FG05 - PROC38 - ");

            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.SOFTBOX);

            AlterarLinha(0, "CD_COBERTURA", dados.ObterCoberturaValida(true));

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNegocioComDependencia);

        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4438()
        {
            IniciarTeste(TipoArquivo.Sinistro, "4438", "FG05 - PROC38 - ");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            CarregarArquivo(arquivo, 1, OperadoraEnum.SOFTBOX);

            AlterarLinha(0, "CD_COBERTURA", dados.ObterCoberturaValida(true));

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNegocioComDependencia);

        }

    }
}