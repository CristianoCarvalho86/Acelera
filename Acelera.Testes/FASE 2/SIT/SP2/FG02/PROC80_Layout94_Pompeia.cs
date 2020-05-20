using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC80_Layout94_Pompeia : TestesFG02
    {

        /// <summary>
        /// Informar DT_AVISO igual a D-1 a DT_OCORRENCIA
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4096_SINISTRO_DT_AVISO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "4096", "FG02 - PROC80 - Informar DT_AVISO igual a D-1 a DT_OCORRENCIA");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.SINISTRO-EV-0001-20200127.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "DT_AVISO", SomarData(ObterValor(1, "DT_OCORRENCIA"), -1));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.POMPEIA.SINISTRO-EV-/*R*/-20200127.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1,"80");
            ValidarTeste();

        }

        /// <summary>
        /// Informar DT_AVISO igual a D+365 DT_OCORRENCIA
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4097_SINISTRO_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "4097", "FG02 - PROC80 - Informar DT_AVISO igual a D+365 DT_OCORRENCIA");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.SINISTRO-EV-0001-20200127.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "DT_AVISO", ObterValor(1, "DT_OCORRENCIA"));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.POMPEIA.SINISTRO-EV-/*R*/-20200127.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(true, "80");
            ValidarStagesSemGerarErro(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTeste();

        }

    }
}
