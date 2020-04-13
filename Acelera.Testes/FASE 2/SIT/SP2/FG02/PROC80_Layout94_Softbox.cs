using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC80_Layout94_Softbox : TestesFG02
    {

        /// <summary>
        /// Informar DT_AVISO igual a D-365 a DT_OCORRENCIA
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2856_SINISTRO_DT_AVISO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "2856", "FG02 - PROC80 - Informar DT_AVISO igual a D-365 a DT_OCORRENCIA");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.SINISTRO-EV-3248-20200321.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "DT_AVISO", SomarData(ObterValor(0, "DT_OCORRENCIA"), -365));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SOFTBOX.SINISTRO-EV-/*R*/-20200321.txt");

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
        /// Informar DT_AVISO igual a D+22 DT_OCORRENCIA
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2857_SINISTRO_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "2857", "FG02 - PROC80 - Informar DT_AVISO igual a D+22 DT_OCORRENCIA");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.SINISTRO-EV-3248-20200321.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "DT_AVISO", SomarData(ObterValor(0, "DT_OCORRENCIA"), 22));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SOFTBOX.SINISTRO-EV-/*R*/-20200321.txt");

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
