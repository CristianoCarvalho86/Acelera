using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_3;
using Acelera.Domain.Layouts._9_4;
using Acelera.Domain.Layouts._9_6;
using Acelera.Utils;
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
            IniciarTeste(TipoArquivo.ParcEmissao, "", "FG05 - PROC219 - ");

            //Envia parc normal
            arquivo = new Arquivo_Layout_9_4_2_new_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.PAPCARD);
            arquivoRegras.AlterarLayout<Arquivo_Layout_9_6_ParcEmissao>(ref arquivo);

            contratoRegras.CriarNovoContrato(0,arquivo);

            CriarNovaLinhaParaEmissao(arquivo, 0);
            AlterarLinha(0, "CD_CLIENTE", GerarNumeroAleatorio(8));

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNegocioComDependencia);
        }
    }
}
