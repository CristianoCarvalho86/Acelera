using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC131_Layout94_Pompeia : TestesFG02
    {

        /// <summary>
        /// Em um único arquivo, duplicar linha. Em uma das linhas, informar Cd_TIPO_MOVIMENTO = 1 e DT_REGISTRO = 01/04/2020 Na segunda linha, informar CD_TIPO_MOVIMENTO = 2 e DT_REGISTRO = 02/04/2020
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3196_DT_REGISTRO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3196", "FG02 - PROC131 - Em um único arquivo, duplicar linha. Em uma das linhas, informar Cd_TIPO_MOVIMENTO = 1 e DT_REGISTRO = 01/04/2020 Na segunda linha, informar CD_TIPO_MOVIMENTO = 2 e DT_REGISTRO = 02/04/2020");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.SINISTRO-EV-0001-20191223.txt"));

            //ALTERAR O VALOR SELECIONADO
            ReplicarLinha(0, 1);
            AlterarLinha(0, "Cd_TIPO_MOVIMENTO", "1");
            AlterarLinha(0, "DT_REGISTRO", "01/04/2020");
            AlterarLinha(1, "Cd_TIPO_MOVIMENTO", "2");
            AlterarLinha(1, "Cd_TIPO_MOVIMENTO", "02/04/2020");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.POMPEIA.SINISTRO-EV-/*R*/-20191223.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "131");
            ValidarTeste();
        }

        /// <summary>
        ///  Em um único arquivo, duplicar linha. Em uma das linhas, informar Cd_TIPO_MOVIMENTO = 1 e DT_REGISTRO = 01/04/2020 Na segunda linha, informar CD_TIPO_MOVIMENTO = 7 e DT_REGISTRO = 07/03/2020
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3197_DT_REGISTRO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3197", "FG02 - PROC131 - Em um único arquivo, duplicar linha. Em uma das linhas, informar Cd_TIPO_MOVIMENTO = 1 e DT_REGISTRO = 01/04/2020 Na segunda linha, informar CD_TIPO_MOVIMENTO = 7 e DT_REGISTRO = 07/03/2020");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.SINISTRO-EV-0001-20191223.txt"));

            //ALTERAR O VALOR SELECIONADO
            ReplicarLinha(0, 1);
            AlterarLinha(0, "Cd_TIPO_MOVIMENTO", "1");
            AlterarLinha(0, "DT_REGISTRO", "01/04/2020");
            AlterarLinha(1, "Cd_TIPO_MOVIMENTO", "7");
            AlterarLinha(1, "Cd_TIPO_MOVIMENTO", "07/03/2020");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.POMPEIA.SINISTRO-EV-/*R*/-20191223.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "131");
            ValidarTeste();
        }

        /// <summary>
        /// Em um único arquivo, duplicar linha. Em uma das linhas, informar Cd_TIPO_MOVIMENTO = 1 e DT_REGISTRO = 01/04/2020 Na segunda linha, informar CD_TIPO_MOVIMENTO = 9 e DT_REGISTRO = 31/03//2020
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3198_DT_REGISTRO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3198", "FG02 - PROC131 - Em um único arquivo, duplicar linha. Em uma das linhas, informar Cd_TIPO_MOVIMENTO = 1 e DT_REGISTRO = 01/04/2020 Na segunda linha, informar CD_TIPO_MOVIMENTO = 9 e DT_REGISTRO = 31/03//2020");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.SINISTRO-EV-0001-20200117.txt"));

            //ALTERAR O VALOR SELECIONADO
            ReplicarLinha(0, 1);
            AlterarLinha(0, "Cd_TIPO_MOVIMENTO", "1");
            AlterarLinha(0, "DT_REGISTRO", "01/04/2020");
            AlterarLinha(1, "Cd_TIPO_MOVIMENTO", "9");
            AlterarLinha(1, "Cd_TIPO_MOVIMENTO", "31/03/2020");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.POMPEIA.SINISTRO-EV-/*R*/-20200117.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "131");
            ValidarTeste();
        }

        /// <summary>
        /// Em um único arquivo, duplicar linha. Em uma das linhas, informar Cd_TIPO_MOVIMENTO = 1 e DT_REGISTRO = 01/03/2020 Na segunda linha, informar CD_TIPO_MOVIMENTO = 30 e DT_REGISTRO = 02/03/2020
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3199_DT_REGISTRO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3199", "FG02 - PROC131 - Em um único arquivo, duplicar linha. Em uma das linhas, informar Cd_TIPO_MOVIMENTO = 1 e DT_REGISTRO = 01/03/2020 Na segunda linha, informar CD_TIPO_MOVIMENTO = 30 e DT_REGISTRO = 02/03/2020");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.SINISTRO-EV-0001-20200127.txt"));

            //ALTERAR O VALOR SELECIONADO
            ReplicarLinha(0, 1);
            AlterarLinha(0, "Cd_TIPO_MOVIMENTO", "1");
            AlterarLinha(0, "DT_REGISTRO", "01/03/2020");
            AlterarLinha(1, "Cd_TIPO_MOVIMENTO", "30");
            AlterarLinha(1, "Cd_TIPO_MOVIMENTO", "02/03/2020");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.POMPEIA.SINISTRO-EV-/*R*/-20200127.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "131");
            ValidarTeste();
        }

        /// <summary>
        ///Em um único arquivo, duplicar linha. Em uma das linhas, informar Cd_TIPO_MOVIMENTO = 1 e DT_REGISTRO = 31/03/2020 Na segunda linha, informar CD_TIPO_MOVIMENTO = 11 e DT_REGISTRO = 01/04/2020
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3200_DT_REGISTRO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3200", "FG02 - PROC131 - Em um único arquivo, duplicar linha. Em uma das linhas, informar Cd_TIPO_MOVIMENTO = 1 e DT_REGISTRO = 31/03/2020 Na segunda linha, informar CD_TIPO_MOVIMENTO = 11 e DT_REGISTRO = 01/04/2020");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.SINISTRO-EV-0001-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            ReplicarLinha(0, 1);
            AlterarLinha(0, "Cd_TIPO_MOVIMENTO", "1");
            AlterarLinha(0, "DT_REGISTRO", "31/03/2020");
            AlterarLinha(1, "Cd_TIPO_MOVIMENTO", "11");
            AlterarLinha(1, "Cd_TIPO_MOVIMENTO", "01/04/2020");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.POMPEIA.SINISTRO-EV-/*R*/-20200211.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "131");
            ValidarTeste();
        }

        /// <summary>
        /// Em um único arquivo, duplicar linha. Em uma das linhas, informar Cd_TIPO_MOVIMENTO = 1 e DT_REGISTRO = 29/02/2020 Na segunda linha, informar CD_TIPO_MOVIMENTO = 146 e DT_REGISTRO = 02/03/2020
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3201_DT_REGISTRO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3201", "FG02 - PROC131 - Em um único arquivo, duplicar linha. Em uma das linhas, informar Cd_TIPO_MOVIMENTO = 1 e DT_REGISTRO = 29/02/2020 Na segunda linha, informar CD_TIPO_MOVIMENTO = 146 e DT_REGISTRO = 02/03/2020");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.SINISTRO-EV-0002-20191220.txt"));

            //ALTERAR O VALOR SELECIONADO
            ReplicarLinha(0, 1);
            AlterarLinha(0, "Cd_TIPO_MOVIMENTO", "1");
            AlterarLinha(0, "DT_REGISTRO", "29/02/2020");
            AlterarLinha(1, "Cd_TIPO_MOVIMENTO", "146");
            AlterarLinha(1, "Cd_TIPO_MOVIMENTO", "02/03/2020");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.POMPEIA.SINISTRO-EV-/*R*/-20191220.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "131");
            ValidarTeste();
        }

        /// <summary>
        ///Em um único arquivo, duplicar linha. Em uma das linhas, informar Cd_TIPO_MOVIMENTO = 1 e DT_REGISTRO = 01/04/2020 Na segunda linha, informar CD_TIPO_MOVIMENTO = 2 e DT_REGISTRO = 01/04/2020
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3202_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3202", "FG02 - PROC131 - Em um único arquivo, duplicar linha. Em uma das linhas, informar Cd_TIPO_MOVIMENTO = 1 e DT_REGISTRO = 01/04/2020 Na segunda linha, informar CD_TIPO_MOVIMENTO = 2 e DT_REGISTRO = 01/04/2020");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.SINISTRO-EV-0001-20200127.txt"));

            //ALTERAR O VALOR SELECIONADO
            ReplicarLinha(0, 1);
            AlterarLinha(0, "Cd_TIPO_MOVIMENTO", "1");
            AlterarLinha(0, "DT_REGISTRO", "01/04/2020");
            AlterarLinha(1, "Cd_TIPO_MOVIMENTO", "2");
            AlterarLinha(1, "Cd_TIPO_MOVIMENTO", "01/04/2020");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.POMPEIA.SINISTRO-EV-/*R*/-20200127.txt");

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

        /// <summary>
        ///Em um único arquivo, duplicar linha. Em uma das linhas, informar Cd_TIPO_MOVIMENTO = 1 e DT_REGISTRO = 07/03/2020 Na segunda linha, informar CD_TIPO_MOVIMENTO = 7 e DT_REGISTRO = 07/03/2020
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3203_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3203", "FG02 - PROC131 - Em um único arquivo, duplicar linha. Em uma das linhas, informar Cd_TIPO_MOVIMENTO = 1 e DT_REGISTRO = 07/03/2020 Na segunda linha, informar CD_TIPO_MOVIMENTO = 7 e DT_REGISTRO = 07/03/2020");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.SINISTRO-EV-0001-20200127.txt"));

            //ALTERAR O VALOR SELECIONADO
            ReplicarLinha(0, 1);
            AlterarLinha(0, "Cd_TIPO_MOVIMENTO", "1");
            AlterarLinha(0, "DT_REGISTRO", "07/03/2020");
            AlterarLinha(1, "Cd_TIPO_MOVIMENTO", "7");
            AlterarLinha(1, "Cd_TIPO_MOVIMENTO", "07/03/2020");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.POMPEIA.SINISTRO-EV-/*R*/-20200127.txt");

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

        /// <summary>
        ///Em um único arquivo, duplicar linha. Em uma das linhas, informar Cd_TIPO_MOVIMENTO = 1 e DT_REGISTRO = 31/03//2020 Na segunda linha, informar CD_TIPO_MOVIMENTO = 9 e DT_REGISTRO = 31/03//2020
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3204_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3204", "FG02 - PROC131 - Em um único arquivo, duplicar linha. Em uma das linhas, informar Cd_TIPO_MOVIMENTO = 1 e DT_REGISTRO = 31/03/2020 Na segunda linha, informar CD_TIPO_MOVIMENTO = 9 e DT_REGISTRO = 31/03//2020");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.SINISTRO-EV-0001-20191223.txt"));

            //ALTERAR O VALOR SELECIONADO
            ReplicarLinha(0, 1);
            AlterarLinha(0, "Cd_TIPO_MOVIMENTO", "1");
            AlterarLinha(0, "DT_REGISTRO", "31/03/2020");
            AlterarLinha(1, "Cd_TIPO_MOVIMENTO", "9");
            AlterarLinha(1, "Cd_TIPO_MOVIMENTO", "31/03/2020");

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

        /// <summary>
        ///Em um único arquivo, duplicar linha. Em uma das linhas, informar Cd_TIPO_MOVIMENTO = 1 e DT_REGISTRO = 02/03/2020 Na segunda linha, informar CD_TIPO_MOVIMENTO = 30 e DT_REGISTRO = 02/03/2020
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3205_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3205", "FG02 - PROC131 - Em um único arquivo, duplicar linha. Em uma das linhas, informar Cd_TIPO_MOVIMENTO = 1 e DT_REGISTRO = 02/03/2020 Na segunda linha, informar CD_TIPO_MOVIMENTO = 30 e DT_REGISTRO = 02/03/2020");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.SINISTRO-EV-0001-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            ReplicarLinha(0, 1);
            AlterarLinha(0, "Cd_TIPO_MOVIMENTO", "1");
            AlterarLinha(0, "DT_REGISTRO", "02/03/2020");
            AlterarLinha(1, "Cd_TIPO_MOVIMENTO", "30");
            AlterarLinha(1, "Cd_TIPO_MOVIMENTO", "02/03/2020");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.POMPEIA.SINISTRO-EV-/*R*/-20200211.txt");

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

        /// <summary>
        ///Em um único arquivo, duplicar linha. Em uma das linhas, informar Cd_TIPO_MOVIMENTO = 1 e DT_REGISTRO = 02/03/2020 Na segunda linha, informar CD_TIPO_MOVIMENTO = 11 e DT_REGISTRO = 02/03/2020
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3206_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3206", "FG02 - PROC131 - Em um único arquivo, duplicar linha. Em uma das linhas, informar Cd_TIPO_MOVIMENTO = 1 e DT_REGISTRO = 02/03/2020 Na segunda linha, informar CD_TIPO_MOVIMENTO = 11 e DT_REGISTRO = 02/03/2020");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.SINISTRO-EV-0001-20200117.txt"));

            //ALTERAR O VALOR SELECIONADO
            ReplicarLinha(0, 1);
            AlterarLinha(0, "Cd_TIPO_MOVIMENTO", "1");
            AlterarLinha(0, "DT_REGISTRO", "02/03/2020");
            AlterarLinha(1, "Cd_TIPO_MOVIMENTO", "11");
            AlterarLinha(1, "Cd_TIPO_MOVIMENTO", "02/03/2020");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.POMPEIA.SINISTRO-EV-/*R*/-20200117.txt");

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

        /// <summary>
        ///Em um único arquivo, duplicar linha. Em uma das linhas, informar Cd_TIPO_MOVIMENTO = 1 e DT_REGISTRO = 29/02/2020 Na segunda linha, informar CD_TIPO_MOVIMENTO = 146 e DT_REGISTRO = 29/02/2020
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3207_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3207", "FG02 - PROC131 - Em um único arquivo, duplicar linha. Em uma das linhas, informar Cd_TIPO_MOVIMENTO = 1 e DT_REGISTRO = 29/02/2020 Na segunda linha, informar CD_TIPO_MOVIMENTO = 146 e DT_REGISTRO = 29/02/2020");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.SINISTRO-EV-0001-20200127.txt"));

            //ALTERAR O VALOR SELECIONADO
            ReplicarLinha(0, 1);
            AlterarLinha(0, "Cd_TIPO_MOVIMENTO", "1");
            AlterarLinha(0, "DT_REGISTRO", "29/02/2020");
            AlterarLinha(1, "Cd_TIPO_MOVIMENTO", "146");
            AlterarLinha(1, "Cd_TIPO_MOVIMENTO", "29/02/2020");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.POMPEIA.SINISTRO-EV-/*R*/-20200127.txt");

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
