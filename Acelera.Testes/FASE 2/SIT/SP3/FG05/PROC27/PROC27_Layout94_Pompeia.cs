using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP3.FG05.PROC27
{
    [TestClass]
    public class PROC27_Layout94_POMPEIA : TestesFG05
    {

        /// <summary>
        /// Gerar arquivo cujo CD_CLIENTE não esteja cadastrado na tabela TAB_ODS_PARCEIRO_NEGOCIO_2000 com CD_TIPO_PARCEIRO_NEGOCIO=CL. Utilizar CD_EXTERNO para essa comparação
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4268()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "4268", "FG05 - PROC27");

            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.POMPEIA);

            AlterarLinha(0, "CD_CLIENTE", dados.ObterParceiroNegocioNaoExistente());

            SalvarArquivo(false,"PROC27");

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "27", 1);

        }

        /// <summary>
        /// Gerar arquivo cujo CD_CLIENTE não esteja cadastrado na tabela TAB_ODS_PARCEIRO_NEGOCIO_2000 com CD_TIPO_PARCEIRO_NEGOCIO=CL. Utilizar CD_EXTERNO para essa comparação
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4269()
        {
            IniciarTeste(TipoArquivo.Sinistro, "4269", "FG02 - PROC1002");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            CarregarArquivo(arquivo, 1, OperadoraEnum.POMPEIA);

            AlterarLinha(0, "CD_CLIENTE", dados.ObterParceiroNegocioNaoExistente());

            SalvarArquivo("PROC27");

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "27", 1);

        }

        /// <summary>
        /// Gerar arquivo cujo CD_CLIENTE não esteja cadastrado na tabela TAB_ODS_PARCEIRO_NEGOCIO_2000 com CD_TIPO_PARCEIRO_NEGOCIO=CL. Utilizar CD_EXTERNO para essa comparação
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4270()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "4270", "FG05 - PROC27");

            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.POMPEIA);

            AlterarLinha(0, "CD_CLIENTE", dados.ObterCDSeguradoraDoTipoParceiro("CL"));

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNegocioComDependencia);

        }

        /// <summary>
        /// Gerar arquivo cujo CD_CLIENTE não esteja cadastrado na tabela TAB_ODS_PARCEIRO_NEGOCIO_2000 com CD_TIPO_PARCEIRO_NEGOCIO=CL. Utilizar CD_EXTERNO para essa comparação
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4271()
        {
            IniciarTeste(TipoArquivo.Sinistro, "4271", "FG05 - PROC27");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            CarregarArquivo(arquivo, 1, OperadoraEnum.POMPEIA);

            AlterarLinha(0, "CD_CLIENTE", dados.ObterCDSeguradoraDoTipoParceiro("CL"));

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNegocioComDependencia);

        }

    }
}
