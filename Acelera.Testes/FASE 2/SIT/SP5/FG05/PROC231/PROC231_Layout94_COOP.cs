using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_3;
using Acelera.Domain.Layouts._9_6;
using Acelera.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP5.FG05.PROC231
{
    [TestClass]
    public class PROC231_Layout94_COOP : TestesFG05
    {
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_9299()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "9299", "FG05 - PROC231 - ");
            

            //Envia parc normal
            arquivo = new Arquivo_Layout_9_6_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.COOP);
            contratoRegras.CriarNovoContrato(0,arquivo);

            emissaoRegras.AlterarLinhaParaPrimeiraEmissao(arquivo, 0);

            SalvarArquivo();

            //EnviarParaOdsAlterandoCliente(arquivo);
            var arquivoods = arquivo.Clone();

            arquivo = comissaoRegras.CriarComissao<Arquivo_Layout_9_6_EmsComissao>(OperadoraEnum.COOP, arquivoods);

            AlterarLinha(0, "VL_COMISSAO", "1");

            SalvarArquivo();

            //ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "231", 1);
        }
    }
}
