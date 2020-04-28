using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC82_Layout94_Pompeia : TestesFG02
    {

        /// <summary>
        /// Replicar linha e informar CD_MOVIMENTO = 3 nas duas linhas
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2860_SINISTRO_DT_AVISO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "2860", "FG02 - PROC82 - Replicar linha e informar CD_MOVIMENTO = 3 nas duas linhas");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.SINISTRO-EV-0001-20191223.txt"));

            //ALTERAR O VALOR SELECIONADO
            ReplicarLinhaComCorrecao(0, 1);
            AlterarLinha(0, "CD_MOVIMENTO", "3");
            AlterarLinha(0, "DT_MOVIMENTO", "20200409");
            AlterarLinha(0, "CD_CLIENTE", "12345");
            AlterarLinha(1, "CD_MOVIMENTO", "3");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.POMPEIA.SINISTRO-EV-/*R*/-20191223.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "82");
            ValidarTeste();

        }

        /// <summary>
        /// Replicar linha e informar Cd_MOVIMENTO diferentes
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2861_SINISTRO_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "2861", "FG02 - PROC82 - Replicar linha e informar Cd_MOVIMENTO diferentes");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.SINISTRO-EV-0001-20191223.txt"));

            //ALTERAR O VALOR SELECIONADO
            SelecionarLinhaParaValidacao(0);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.POMPEIA.SINISTRO-EV-/*R*/-20191223.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(false);
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTeste();

        }

    }
}
