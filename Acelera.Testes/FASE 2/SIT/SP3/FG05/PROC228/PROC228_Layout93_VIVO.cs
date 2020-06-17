using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_3;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP3.FG05.PROC228
{
    [TestClass]
    public class PROC228_Layout93_VIVO : TestesFG05
    {

        /// <summary>
        /// Enviar primeiro arquivo PARC para a ODS com DT_INICIO_VIGENCIA e DT_FIM VIGENCIA. 
        /// Após registro gravado, enviar outro arquivo SINISTRO cuja DT_OCORRENCIA seja inferior a DT_INICIO_VIGENCIA da apólice (do 1o arquivo)
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4639()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "4639", "FG05 - PROC228 - ");

            arquivo = new Arquivo_Layout_9_3_Cliente();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            AlterarLinha(0, "CD_CLIENTE", GerarNumeroAleatorio(8));
            var cdCliente = ObterValor(0, "CD_CLIENTE");
            arquivo.AlterarLinha(0, "SEXO", "");

            EnviarParaOds(arquivo, false);

            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            AlterarLinha(0, "CD_CLIENTE", cdCliente);

            SalvarArquivo(false);

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "228", 1);
        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4641()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "4639", "FG05 - PROC228 - ");

            arquivo = new Arquivo_Layout_9_3_Cliente();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            AlterarLinha(0, "CD_CLIENTE", GerarNumeroAleatorio(8));
            var cdCliente = ObterValor(0, "CD_CLIENTE");

            EnviarParaOds(arquivo, false);

            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            AlterarLinha(0, "CD_CLIENTE", cdCliente);

            SalvarArquivo(false);

            ExecutarEValidarDesconsiderandoErro(CodigoStage.AprovadoNegocioComDependencia, "228");
        }

    }
}
