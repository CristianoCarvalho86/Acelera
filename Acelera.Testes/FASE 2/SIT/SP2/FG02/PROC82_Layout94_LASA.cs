using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC82_Layout94_Lasa : TestesFG02
    {

        /// <summary>
        /// Enviar primeiro um airquivo com CD_MOVIMENTO = 3. Depois, enviar outro arquivo com a mesma linha e o mesmo CD_MOVIMENTO.
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2862_SINISTRO_DT_AVISO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "2862", "FG02 - PROC82 - Enviar primeiro um airquivo com CD_MOVIMENTO = 3. Depois, enviar outro arquivo com a mesma linha e o mesmo CD_MOVIMENTO.");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.SINISTRO-EV-3312-20200325.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_MOVIMENTO", "3");
            var linha = CopiarLinha(0);
            

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.SINISTRO-EV-/*R*/-20200325.txt");

            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.SINISTRO-EV-3303-20200324.txt"));

            //ALTERAR O VALOR SELECIONADO
            InserirLinha(linha, 0);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.SINISTRO-EV-/*R*/-20200324.txt");

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
        public void SAP_2863_SINISTRO_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "2863", "FG02 - PROC82 - Replicar linha e informar Cd_MOVIMENTO diferentes");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.SINISTRO-EV-3312-20200325.txt"));

            //ALTERAR O VALOR SELECIONADO
            SelecionarLinhaParaValidacao(0);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.SINISTRO-EV-/*R*/-20200325.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(true, "82");
            ValidarStagesSemGerarErro(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTeste();

        }

    }
}
