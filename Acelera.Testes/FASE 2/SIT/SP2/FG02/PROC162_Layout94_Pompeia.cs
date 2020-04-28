using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC162_Layout94_Pompeia : TestesFG02
    {

        /// <summary>
        /// Enviar dois registro no mesmo arquivo, um com CD_TIPO_EMISSÃO=20 e o segundo com CD_TIPO_EMISSAO=5. No segundo, informar DT_EMISSAO anterior a data do primeiro
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3387_PARC_EMISSAO_VL_IS_negativo()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3387", "FG02 - PROC162 - Enviar dois registro no mesmo arquivo, um com CD_TIPO_EMISSÃO=20 e o segundo com CD_TIPO_EMISSAO=5. No segundo, informar DT_EMISSAO anterior a data do primeiro	");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.PARCEMS-EV-1925-20200210.txt"));

            //ALTERAR O VALOR SELECIONADO
            ReplicarLinhaComCorrecao(0, 1);
            AlterarLinha(0, "CD_TIPO_EMISSAO", "20");
            AlterarLinha(1, "CD_TIPO_EMISSAO", "5");
            AlterarLinha(1, "ID_TRANSACAO_CANC", SomarData(ObterValor(0,"DT_EMISSAO"),-365));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.POMPEIA.PARCEMS-EV-/*R*/-20200210.TXT");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "162");
            ValidarTeste();

        }

        /// <summary>
        /// Enviar dois registro no mesmo arquivo, um com CD_TIPO_EMISSÃO=7 e o segundo com CD_TIPO_EMISSAO=5. No segundo, informar DT_EMISSAO anterior a data do primeiro
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3388_PARC_EMISSAO_VL_IS_negativo()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3388", "FG02 - PROC162 - Enviar dois registro no mesmo arquivo, um com CD_TIPO_EMISSÃO=7 e o segundo com CD_TIPO_EMISSAO=5. No segundo, informar DT_EMISSAO anterior a data do primeiro	");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.PARCEMS-EV-1928-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            ReplicarLinhaComCorrecao(0, 1);
            AlterarLinha(0, "CD_TIPO_EMISSAO", "7");
            AlterarLinha(1, "CD_TIPO_EMISSAO", "5");
            AlterarLinha(1, "ID_TRANSACAO_CANC", SomarData(ObterValor(0, "DT_EMISSAO"), -30));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.POMPEIA.PARCEMS-EV-/*R*/-20200211.TXT");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "162");
            ValidarTeste();

        }


        /// <summary>
        /// Enviar dois registro no mesmo arquivo, um com CD_TIPO_EMISSÃO=20 e o segundo com CD_TIPO_EMISSAO=5. No segundo, informar DT_EMISSAO igual a data do primeiro
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3389_PARC_EMISSAO_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3389", "FG00 - PROC162 - Enviar dois registro no mesmo arquivo, um com CD_TIPO_EMISSÃO=20 e o segundo com CD_TIPO_EMISSAO=5. No segundo, informar DT_EMISSAO igual a data do primeiro");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.PARCEMS-EV-1931-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            ReplicarLinhaComCorrecao(0, 1);
            AlterarLinha(0, "CD_TIPO_EMISSAO", "20");
            AlterarLinha(1, "CD_TIPO_EMISSAO", "5");
            AlterarLinha(1, "ID_TRANSACAO_CANC", ObterValor(0, "DT_EMISSAO"));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.POMPEIA.PARCEMS-EV-/*R*/-20200212.TXT");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(false);
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTeste();

        }

        
        /// <summary>
        /// Enviar dois registro no mesmo arquivo, um com CD_TIPO_EMISSÃO=7 e o segundo com CD_TIPO_EMISSAO=5. No segundo, informar DT_EMISSAO superior a data do primeiro
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3390_PARC_EMISSAO_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3390", "FG00 - PROC162 -Enviar dois registro no mesmo arquivo, um com CD_TIPO_EMISSÃO=7 e o segundo com CD_TIPO_EMISSAO=5. No segundo, informar DT_EMISSAO superior a data do primeiro");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.PARCEMS-EV-1934-20200213.txt"));

            //ALTERAR O VALOR SELECIONADO
            ReplicarLinhaComCorrecao(0, 1);
            AlterarLinha(0, "CD_TIPO_EMISSAO", "7");
            AlterarLinha(1, "CD_TIPO_EMISSAO", "5");
            AlterarLinha(1, "ID_TRANSACAO_CANC", ObterValor(0, "DT_EMISSAO"));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.POMPEIA.PARCEMS-EV-/*R*/-20200213.TXT");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(false);
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTeste();

        }
    }
}
