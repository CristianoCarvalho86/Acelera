using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP5.FG02
{
    [TestClass]
    public class PROC185_Layout94_COOP : TestesFG02
    {

        /// <summary>
        ///Informar DT_REGISTRO = D-30 da DT_AVISO
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3699_DT_REGISTRO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3699", "FG02 - PROC185 -Informar DT_REGISTRO = D-30 da DT_AVISO");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.COOP.SINISTRO-EV-0001-20200127.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "DT_REGISTRO", SomarData(ObterValor(0,"DT_AVISO"), -30));
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "1");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.COOP.SINISTRO-EV-/*R*/-20200127.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "185");
            ValidarTeste();
        }

        /// <summary>
        ///Informar DT_REGISTRO = DT_AVISO
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3700_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3700", "FG02 - PROC185 - Informar DT_REGISTRO = DT_AVISO");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.COOP.SINISTRO-EV-0001-20200117.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "DT_REGISTRO", ObterValor(0, "DT_AVISO"));
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "1");
            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.COOP.SINISTRO-EV-/*R*/-20200117.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(true, "185");
            ValidarStagesSemGerarErro(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTeste();
        }

        /// <summary>
        ///Informar DT_REGISTRO = D+30 da DT_AVISO
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3701_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3701", "FG02 - PROC185 - Informar DT_REGISTRO = D+30 da DT_AVISO");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.COOP.SINISTRO-EV-0001-20191223.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "DT_REGISTRO", SomarData(ObterValor(0,"DT_AVISO"), 30));
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "1");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.COOP.SINISTRO-EV-/*R*/-20191223.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(true, "185");
            ValidarStagesSemGerarErro(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTeste();
        }
    }
}
