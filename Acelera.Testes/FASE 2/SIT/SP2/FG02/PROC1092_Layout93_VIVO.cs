using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_3;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC1092_Layout93_VIVO : TestesFG02
    {
        /// <summary>
        /// Informar CD_FRANQUIA não parametrizado na TAB_PRM_FRANQUIA_7010
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3924_ParcEmissaoAuto_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "3924", "FG02 - PROC1092 - Informar CD_FRANQUIA não parametrizado na TAB_PRM_FRANQUIA_7010");

            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1864-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_FRANQUIA", dados.ObterCDFranquia(false));

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
