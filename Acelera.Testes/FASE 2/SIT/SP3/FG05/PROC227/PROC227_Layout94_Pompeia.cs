using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_3;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP3.FG05.PROC227
{
    [TestClass]
    public class PROC227_Layout94_POMPEIA : TestesFG05
    {

        /// <summary>
        /// Enviar primeiro arquivo PARC para a ODS com DT_INICIO_VIGENCIA e DT_FIM VIGENCIA. 
        /// Após registro gravado, enviar outro arquivo SINISTRO cuja DT_OCORRENCIA seja inferior a DT_INICIO_VIGENCIA da apólice (do 1o arquivo)
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4635()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "4635", "FG05 - PROC227 - ");

            arquivo = new Arquivo_Layout_9_4_Cliente();
            CarregarArquivo(arquivo, 1, OperadoraEnum.POMPEIA);

            AlterarLinha(0, "CD_CLIENTE", GerarNumeroAleatorio(8));
            var cdCliente = ObterValor(0, "CD_CLIENTE");
            AlterarLinha(0, "DT_NASCIMENTO", "");

            EnviarParaOdsAlterandoCliente(arquivo, false);
            var arquivosOds = arquivo.Clone();

            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.POMPEIA);

            AlterarLinha(0, "CD_CLIENTE", cdCliente);

            SalvarArquivo(false);

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "227", 1);
        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4637()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "4637", "FG05 - PROC227 - ");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.POMPEIA);

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNegocioComDependencia);
        }

    }
}
