using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP3.FG05.PROC97
{
    [TestClass]
    public class PROC97_Layout94_LASA : TestesFG05
    {

        /// <summary>
        /// Informar CD_SEGURADORA com um CD_EXTERNO cadastrado na tabela TAB_ODS_PARCEIRO_NEGOCIO_2000 como "SE". 
        /// Este CD_PARCEIRO_NEGOCIO deve estar parametrizado na TAB_ODS_ENDERECO_2001 sem Endereço preenchido. Os demais campos devem estar preenchidos
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4291()
        {
            IniciarTeste(TipoArquivo.Cliente, "4291", "FG05 - PROC97");

            arquivo = new Arquivo_Layout_9_4_Cliente();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            RemoverLinhasExcetoAsPrimeiras(1);

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "97", 1);

        }

        /// <summary>
        /// Informar CD_SEGURADORA com um CD_EXTERNO cadastrado na tabela TAB_ODS_PARCEIRO_NEGOCIO_2000 como "SE". 
        /// Este CD_PARCEIRO_NEGOCIO deve estar parametrizado na TAB_ODS_ENDERECO_2001 sem Endereço preenchido. Os demais campos devem estar preenchidos
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4294()
        {
            IniciarTeste(TipoArquivo.LanctoComissao, "4291", "FG05 - PROC97");

            arquivo = new Arquivo_Layout_9_4_LanctoComissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            RemoverLinhasExcetoAsPrimeiras(1);

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "97", 1);

        }

    }
}
