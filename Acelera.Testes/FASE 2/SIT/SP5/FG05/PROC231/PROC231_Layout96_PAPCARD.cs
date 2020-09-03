using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_3;
using Acelera.Domain.Layouts._9_4;
using Acelera.Domain.Layouts._9_6;
using Acelera.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP5.FG05.PROC231
{
    [TestClass]
    public class PROC231_Layout96_PAPCARD : TestesFG05
    {
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_9300()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "9300", "SAP-9300:FG05 - PROC 231 - C/C - PAPCARD - COMISSAO - Comissão para emissão = 18");


            //Envia parc normal
            arquivo = new Arquivo_Layout_9_4_2_new_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.PAPCARD);
            AlterarLayout<Arquivo_Layout_9_6_ParcEmissao>(ref arquivo);

            AlterarLinhaParaPrimeiraEmissao(arquivo, 0);

            //EnviarParaOdsAlterandoCliente(arquivo);
            var arquivoods = arquivo.Clone();

            arquivo = CriarComissao<Arquivo_Layout_9_6_EmsComissao>(OperadoraEnum.PAPCARD, arquivoods,true);

            AlterarLinha(0, "VL_COMISSAO", "1");

            SalvarArquivo();

            //ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "231", 1);
        }
    }
}
