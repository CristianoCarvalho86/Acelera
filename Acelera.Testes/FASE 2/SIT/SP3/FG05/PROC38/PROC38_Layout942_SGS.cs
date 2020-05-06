using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4_2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP3.FG05.PROC38
{
    [TestClass]
    public class PROC38_Layout94_SGS : TestesFG05
    {

       
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4448()
        {
            IniciarTeste(TipoArquivo.Sinistro, "4448", "FG05 - PROC38 - ");

            arquivo = new Arquivo_Layout_9_4_2();
            CarregarArquivo(arquivo, 1, OperadoraEnum.SGS);

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
        public void SAP_4449()
        {
            IniciarTeste(TipoArquivo.Sinistro, "4449", "FG05 - PROC38 - ");

            arquivo = new Arquivo_Layout_9_4_2();
            CarregarArquivo(arquivo, 1, OperadoraEnum.SGS);

            AlterarLinha(0, "CD_COBERTURA", dados.ObterCoberturaValida(false));

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "38", 1);

        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4450()
        {
            IniciarTeste(TipoArquivo.Sinistro, "4450", "FG05 - PROC38 - ");

            arquivo = new Arquivo_Layout_9_4_2();
            CarregarArquivo(arquivo, 1, OperadoraEnum.SGS);

            AlterarLinha(0, "CD_COBERTURA", dados.ObterCoberturaValida(true));

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNegocioComDependencia);

        }

    }
}