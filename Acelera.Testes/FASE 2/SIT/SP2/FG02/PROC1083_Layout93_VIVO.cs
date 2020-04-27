using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_3;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC1083_Layout93_VIVO : TestesFG02
    {
        /// <summary>
        /// DT_VENCIMENTO = D-30 DT_EMISSAO
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3888_ParcEmissaoAuto_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "3888", "FG02 - PROC1083 - DT_VENCIMENTO = D-30 DT_EMISSAO");

            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1868-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "DT_VENCIMENTO", SomarData(ObterValor(0,"DT_EMISSAO"), -30));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissaoAuto.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(false);
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTeste();

        }
    }
}
