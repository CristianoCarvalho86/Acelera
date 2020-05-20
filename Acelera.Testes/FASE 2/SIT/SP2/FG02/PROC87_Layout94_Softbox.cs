using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC87_Layout94_Softbox : TestesFG02
    {

        /// <summary>
        /// Informar Informar CD_TIPO_MOVIMENTO =146, TP_SINISTRO=02, CD_FORMA_PAGTO=D e não informar campo NR_CONTA_SEG
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2896_SemNR_CONTA_SEG()
        {
            IniciarTeste(TipoArquivo.Sinistro, "2896", "FG02 - PROC87 - Informar CD_TIPO_MOVIMENTO =146, TP_SINISTRO=02, CD_FORMA_PAGTO=D e não informar campo NR_CONTA_SEG");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.SINISTRO-EV-3232-20200320.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "146");
            AlterarLinha(0, "TP_SINISTRO", "02");
            AlterarLinha(0, "CD_FORMA_PAGTO", "D");
            AlterarLinha(0, "NR_CONTA_SEG", "");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SOFTBOX.SINISTRO-EV-/*R*/-20200320.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "87");
            ValidarTeste();

        }

        /// <summary>
        /// Informar CD_TIPO_MOVIMENTO=1 e não informar NR_CONTA_SEG
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2897_SINISTRO_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "2897", "FG02 - PROC87 - Informar CD_TIPO_MOVIMENTO=1 e não informar NR_CONTA_SEG");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.SINISTRO-EV-3232-20200320.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "1");
            AlterarLinha(0, "NR_CONTA_SEG", "");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SOFTBOX.SINISTRO-EV-/*R*/-20200320.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(true, "87");
            ValidarStagesSemGerarErro(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTeste();

        }

    }
}
