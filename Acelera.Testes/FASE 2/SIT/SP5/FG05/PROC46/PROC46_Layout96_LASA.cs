using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_3;
using Acelera.Domain.Layouts._9_4;
using Acelera.Domain.Layouts._9_6;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP5.FG05.PROC46
{
    [TestClass]
    public class PROC46_Layout96_LASA : TestesFG05
    {

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_9247_Cancelamento()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "", "SAP-9247:FG05 - PROC 46 - C/C - COOP - PARCELA - Cancelamento e nr_seq_emissão=1");

            //Envia parc normal
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);
            CriarNovoContrato(0);

            AlterarLinhaParaPrimeiraEmissao(arquivo, 0);

            EnviarParaOdsAlterandoCliente(arquivo);

            LimparValidacao();

            arquivo.AdicionarLinha(CriarLinhaCancelamento(arquivo[0], "10", "02", "1"));
            AlterarLinha(1, "CD_ITEM", "12345");
            RemoverLinhaComAjusteDeFooter(0);
            //NAO PRECISA COLOCAR O NR_SEQUENCIAL_EMISSAO, POIS O METODOS DE CRIAR LINHA DE CANCELAMENTO JÁ ESTÁ FAZENDO

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "46", 1);
        }

    }
}
