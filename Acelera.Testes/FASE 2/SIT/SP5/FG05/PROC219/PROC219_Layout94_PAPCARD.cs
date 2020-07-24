using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_3;
using Acelera.Domain.Layouts._9_6;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP5.FG05.PROC219
{
    [TestClass]
    public class PROC219_Layout94_PAPCARD : TestesFG05
    {
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_9224()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "9180", "FG05 - PROC219 - ");
            

            //Envia parc normal
            var arquivoods1 = new Arquivo_Layout_9_6_ParcEmissao();
            CarregarArquivo(arquivoods1, 1, OperadoraEnum.PAPCARD);

            CriarNovoContrato(0);

            ReplicarLinha(0, 1);
            AlterarLinha(1, "CD_CLIENTE", "");
            AlterarLinha(1, "NR_ENDOSSO", "");
            AlterarLinha(1, "NR_SEQUENCIAL_EMISSAO", "");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNegocioComDependencia);
        }
    }
}
