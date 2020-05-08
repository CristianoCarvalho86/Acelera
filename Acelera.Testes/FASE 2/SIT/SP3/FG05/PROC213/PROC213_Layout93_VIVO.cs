using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_3;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP3.FG05.PROC213
{
    [TestClass]
    public class PROC213_Layout93_VIVO : TestesFG05
    {

        /// <summary>
        /// Informar Cd_VEICUCLO no formato NNNNNNN
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4679()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "4679", "FG05 - PROC213");

            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            AlterarLinha(0, "CD_MODELO", "1234567");

            SalvarArquivo(true, "PROC213");

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "213", 1);

        }

        /// <summary>
        /// Informar Cd_VEICUCLO no formato NNNNNNN
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4680()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "4680", "FG05 - PROC213");

            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            AlterarLinha(0, "CD_MODELO", "11223-34");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "213", 1);

        }

        /// <summary>
        /// Informar Cd_VEICUCLO no formato NNNNNNN
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4681()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "4681", "FG05 - PROC213");

            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            AlterarLinha(0, "CD_MODELO", "14325-6");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "213", 1);

        }


        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4282()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "4282", "FG05 - PROC213");

            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            AlterarLinha(0, "CD_MODELO", "001001-4");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNegocioComDependencia);

        }
    }
}
