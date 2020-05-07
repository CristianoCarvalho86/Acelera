using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_3;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP3.FG05.PROC228
{
    [TestClass]
    public class PROC228_Layout94_LASA : TestesFG05
    {

        /// <summary>
        /// Enviar primeiro arquivo PARC para a ODS com DT_INICIO_VIGENCIA e DT_FIM VIGENCIA. 
        /// Após registro gravado, enviar outro arquivo SINISTRO cuja DT_OCORRENCIA seja inferior a DT_INICIO_VIGENCIA da apólice (do 1o arquivo)
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4643()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "4643", "FG05 - PROC228 - ");

            var arquivoods = new Arquivo_Layout_9_4_Cliente();
            CarregarArquivo(arquivoods, 1, OperadoraEnum.LASA);

            var cdCliente = ObterValor(0, "CD_CLIENTE");
            arquivoods.AlterarLinha(0, "SEXO", "");

            EnviarParaOds(arquivoods, false);

            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            AlterarLinha(0, "CD_CLIENTE", cdCliente);

            SalvarArquivo(false);

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "228", 1);
        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4645()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "4645", "FG05 - PROC228 - ");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNegocioComDependencia);
        }

    }
}
