using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_3;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP3.FG05.PROC227
{
    [TestClass]
    public class PROC227_Layout93_VIVO : TestesFG05
    {

        /// <summary>
        /// Enviar primeiro arquivo PARC para a ODS com DT_INICIO_VIGENCIA e DT_FIM VIGENCIA. 
        /// Após registro gravado, enviar outro arquivo SINISTRO cuja DT_OCORRENCIA seja inferior a DT_INICIO_VIGENCIA da apólice (do 1o arquivo)
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4623()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "4623", "FG05 - PROC227 - ");

            arquivo = new Arquivo_Layout_9_3_Cliente();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            AlterarLinha(0, "CD_CLIENTE", GerarNumeroAleatorio(8));
            var cdCliente = ObterValor(0, "CD_CLIENTE");
            AlterarLinha(0, "DT_NASCIMENTO", "");

            EnviarParaOdsAlterandoCliente(arquivo, false);
            var arquivoods = arquivo.Clone();

            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            AlterarLinha(0, "CD_CLIENTE", cdCliente);

            SalvarArquivo(false);

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "227", 1);
        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4625()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "4623", "FG05 - PROC227 - ");

            arquivo = new Arquivo_Layout_9_3_Cliente();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            AlterarLinha(0, "CD_CLIENTE", GerarNumeroAleatorio(8));
            var cdCliente = ObterValor(0, "CD_CLIENTE");

            EnviarParaOdsAlterandoCliente(arquivo, false);
            var arquivoods = arquivo.Clone();

            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            AlterarLinha(0, "CD_CLIENTE", cdCliente);

            SalvarArquivo(false);

            ExecutarEValidarDesconsiderandoErro(CodigoStage.AprovadoNegocioComDependencia, "227");
        }

    }
}
