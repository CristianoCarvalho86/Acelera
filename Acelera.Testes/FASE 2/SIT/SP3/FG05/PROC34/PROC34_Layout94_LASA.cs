using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_3;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP3.FG05.PROC34
{
    [TestClass]
    public class PROC34_Layout94_LASA : TestesFG05
    {

        /// <summary>
        /// Informar CD_SEGURADORA com um CD_EXTERNO cadastrado na tabela TAB_ODS_PARCEIRO_NEGOCIO_2000 como "SE". 
        /// Este CD_PARCEIRO_NEGOCIO deve estar parametrizado na TAB_ODS_ENDERECO_2001 sem CNPJ preenchido. Os demais campos devem estar preenchidos
        /// </summary>
        [TestMethod]
        [TestCategory("Comm Critica")]
        public void SAP_()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3801", "FG02 - PROC1002 - ");

            var arquivoods = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivoods, 1, OperadoraEnum.VIVO);

            arquivoods.AlterarLinha(0, "CD_SEGURADORA", dados.ObterCDSeguradoraDoTipoParceiro("SE"));
            arquivoods.AlterarLinha(0, "",)
            
            EnviarParaOds(arquivoods);

            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            var campos = dados.ObterAtributosDoLayout(TipoArquivo.Sinistro, "9.4");
            IgualarCampos(arquivoods, arquivo, campos);

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "34", 1);

        }

    }
}
