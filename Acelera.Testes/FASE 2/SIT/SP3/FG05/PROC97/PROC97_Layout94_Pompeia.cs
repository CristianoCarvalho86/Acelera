using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP3.FG05.PROC97
{
    [TestClass]
    public class PROC97_Layout94_POMPEIA : TestesFG05
    {

        /// <summary>
        /// Informar CD_SEGURADORA com um CD_EXTERNO cadastrado na tabela TAB_ODS_PARCEIRO_NEGOCIO_2000 como "SE". 
        /// Este CD_PARCEIRO_NEGOCIO deve estar parametrizado na TAB_ODS_ENDERECO_2001 sem nenhum campo cadastral preenchido (cnpj, endereço, cidade, uf ou cep).
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4696()
        {
            IniciarTeste(TipoArquivo.Sinistro, "4696", "FG05 - PROC97");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            CarregarArquivo(arquivo, 1, OperadoraEnum.POMPEIA);

            RemoverLinhasExcetoAsPrimeiras(1);

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "97", 1);

        }


    }
}
