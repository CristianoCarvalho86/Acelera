using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_3;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP3.FG05.PROC108
{
    [TestClass]
    public class PROC108_Layout93_VIVO : TestesFG05
    {

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4491()
        {
            IniciarTeste(TipoArquivo.Comissao, "4491", "FG05 - PROC108");

            arquivo = new Arquivo_Layout_9_3_EmsComissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            AlterarLinha(0, "CD_CONTRATO", "7231000031709");
            var cobertura = dados.ObterCoberturaSimples(ObterValorHeader("CD_TPA"));
            AlterarLinha(0, "CD_COBERTURA", cobertura.CdCobertura);
            AlterarLinha(0, "CD_RAMO", dados.ObterRamoNaoRelacionadoACobertura(cobertura.CdRamo));
            RemoverLinhasExcetoAsPrimeiras(1);

            SalvarArquivo();

            ExecutarEValidarAteFg02(arquivo, "108");

        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4492()
        {
            IniciarTeste(TipoArquivo.Comissao, "4492", "FG05 - PROC108");

            arquivo = new Arquivo_Layout_9_3_EmsComissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            AlterarLinha(0, "CD_CONTRATO", "7231000031709");
            var cobertura = dados.ObterCoberturaSimples(ObterValorHeader("CD_TPA"));
            AlterarLinha(0, "CD_COBERTURA", cobertura.CdCobertura);
            AlterarLinha(0, "CD_RAMO", cobertura.CdRamo);

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNegocioComDependencia);

        }
    }
}
