using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC131_Layout94_Softbox : TestesFG02
    {

        /// <summary>
        /// Em um único arquivo, duplicar linha. Em uma das linhas, informar CD_TIPO_MOVIMENTO = 1 e DT_REGISTRO = 01/04/2020 Na segunda linha, informar CD_TIPO_MOVIMENTO = 2 e DT_REGISTRO = 02/04/2020
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3220_DT_REGISTRO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3220", "FG02 - PROC131 - Em um único arquivo, duplicar linha. Em uma das linhas, informar CD_TIPO_MOVIMENTO = 1 e DT_REGISTRO = 01/04/2020 Na segunda linha, informar CD_TIPO_MOVIMENTO = 2 e DT_REGISTRO = 02/04/2020");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.SINISTRO-EV-3191-20200317.txt"));

            //ALTERAR O VALOR SELECIONADO
            ReplicarLinha(0, 1);
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "1");
            AlterarLinha(0, "DT_REGISTRO", "01/04/2020");
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "2");
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "02/04/2020");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SOFTBOX.SINISTRO-EV-/*R*/-20200317.txt");

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
        ///  Em um único arquivo, duplicar linha. Em uma das linhas, informar CD_TIPO_MOVIMENTO = 1 e DT_REGISTRO = 01/04/2020 Na segunda linha, informar CD_TIPO_MOVIMENTO = 7 e DT_REGISTRO = 07/03/2020
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3221_DT_REGISTRO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3221", "FG02 - PROC131 - Em um único arquivo, duplicar linha. Em uma das linhas, informar CD_TIPO_MOVIMENTO = 1 e DT_REGISTRO = 01/04/2020 Na segunda linha, informar CD_TIPO_MOVIMENTO = 7 e DT_REGISTRO = 07/03/2020");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.SINISTRO-EV-3217-20200319.txt"));

            //ALTERAR O VALOR SELECIONADO
            ReplicarLinha(0, 1);
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "1");
            AlterarLinha(0, "DT_REGISTRO", "01/04/2020");
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "7");
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "07/03/2020");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SOFTBOX.SINISTRO-EV-/*R*/-20200319.txt");

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
        /// Em um único arquivo, duplicar linha. Em uma das linhas, informar CD_TIPO_MOVIMENTO = 1 e DT_REGISTRO = 01/04/2020 Na segunda linha, informar CD_TIPO_MOVIMENTO = 9 e DT_REGISTRO = 31/03//2020
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3222_DT_REGISTRO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3222", "FG02 - PROC131 - Em um único arquivo, duplicar linha. Em uma das linhas, informar CD_TIPO_MOVIMENTO = 1 e DT_REGISTRO = 01/04/2020 Na segunda linha, informar CD_TIPO_MOVIMENTO = 9 e DT_REGISTRO = 31/03//2020");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.SINISTRO-EV-3220-20200319.txt"));

            //ALTERAR O VALOR SELECIONADO
            ReplicarLinha(0, 1);
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "1");
            AlterarLinha(0, "DT_REGISTRO", "01/04/2020");
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "9");
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "31/03/2020");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SOFTBOX.SINISTRO-EV-/*R*/-20200319.txt");

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
        /// Em um único arquivo, duplicar linha. Em uma das linhas, informar CD_TIPO_MOVIMENTO = 1 e DT_REGISTRO = 01/03/2020 Na segunda linha, informar CD_TIPO_MOVIMENTO = 30 e DT_REGISTRO = 02/03/2020
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3223_DT_REGISTRO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3223", "FG02 - PROC131 - Em um único arquivo, duplicar linha. Em uma das linhas, informar CD_TIPO_MOVIMENTO = 1 e DT_REGISTRO = 01/03/2020 Na segunda linha, informar CD_TIPO_MOVIMENTO = 30 e DT_REGISTRO = 02/03/2020");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.SINISTRO-EV-3222-20200319.txt"));

            //ALTERAR O VALOR SELECIONADO
            ReplicarLinha(0, 1);
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "1");
            AlterarLinha(0, "DT_REGISTRO", "01/03/2020");
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "30");
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "02/03/2020");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SOFTBOX.SINISTRO-EV-/*R*/-20200319.txt");

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
        ///Em um único arquivo, duplicar linha. Em uma das linhas, informar CD_TIPO_MOVIMENTO = 1 e DT_REGISTRO = 31/03/2020 Na segunda linha, informar CD_TIPO_MOVIMENTO = 11 e DT_REGISTRO = 01/04/2020
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3224_DT_REGISTRO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3224", "FG02 - PROC131 - Em um único arquivo, duplicar linha. Em uma das linhas, informar CD_TIPO_MOVIMENTO = 1 e DT_REGISTRO = 31/03/2020 Na segunda linha, informar CD_TIPO_MOVIMENTO = 11 e DT_REGISTRO = 01/04/2020");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.SINISTRO-EV-3231-20200320.txt"));

            //ALTERAR O VALOR SELECIONADO
            ReplicarLinha(0, 1);
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "1");
            AlterarLinha(0, "DT_REGISTRO", "31/03/2020");
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "11");
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "01/04/2020");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SOFTBOX.SINISTRO-EV-/*R*/-20200320.txt");

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
        /// Em um único arquivo, duplicar linha. Em uma das linhas, informar CD_TIPO_MOVIMENTO = 1 e DT_REGISTRO = 29/02/2020 Na segunda linha, informar CD_TIPO_MOVIMENTO = 146 e DT_REGISTRO = 02/03/2020
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3225_DT_REGISTRO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3225", "FG02 - PROC131 - Em um único arquivo, duplicar linha. Em uma das linhas, informar CD_TIPO_MOVIMENTO = 1 e DT_REGISTRO = 29/02/2020 Na segunda linha, informar CD_TIPO_MOVIMENTO = 146 e DT_REGISTRO = 02/03/2020");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.SINISTRO-EV-3232-20200320.txt"));

            //ALTERAR O VALOR SELECIONADO
            ReplicarLinha(0, 1);
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "1");
            AlterarLinha(0, "DT_REGISTRO", "29/02/2020");
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "146");
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "02/03/2020");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SOFTBOX.SINISTRO-EV-/*R*/-20200320.txt");

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
        ///Em um único arquivo, duplicar linha. Em uma das linhas, informar CD_TIPO_MOVIMENTO = 1 e DT_REGISTRO = 01/04/2020 Na segunda linha, informar CD_TIPO_MOVIMENTO = 2 e DT_REGISTRO = 01/04/2020
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3226_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3226", "FG02 - PROC131 - Em um único arquivo, duplicar linha. Em uma das linhas, informar CD_TIPO_MOVIMENTO = 1 e DT_REGISTRO = 01/04/2020 Na segunda linha, informar CD_TIPO_MOVIMENTO = 2 e DT_REGISTRO = 01/04/2020");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.SINISTRO-EV-3238-20200320.txt"));

            //ALTERAR O VALOR SELECIONADO
            ReplicarLinha(0, 1);
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "1");
            AlterarLinha(0, "DT_REGISTRO", "01/04/2020");
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "2");
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "01/04/2020");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SOFTBOX.SINISTRO-EV-/*R*/-20200320.txt");

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
        ///Em um único arquivo, duplicar linha. Em uma das linhas, informar CD_TIPO_MOVIMENTO = 1 e DT_REGISTRO = 07/03/2020 Na segunda linha, informar CD_TIPO_MOVIMENTO = 7 e DT_REGISTRO = 07/03/2020
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3227_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3227", "FG02 - PROC131 - Em um único arquivo, duplicar linha. Em uma das linhas, informar CD_TIPO_MOVIMENTO = 1 e DT_REGISTRO = 07/03/2020 Na segunda linha, informar CD_TIPO_MOVIMENTO = 7 e DT_REGISTRO = 07/03/2020");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.SINISTRO-EV-3248-20200321.txt"));

            //ALTERAR O VALOR SELECIONADO
            ReplicarLinha(0, 1);
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "1");
            AlterarLinha(0, "DT_REGISTRO", "07/03/2020");
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "7");
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "07/03/2020");

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

        /// <summary>
        ///Em um único arquivo, duplicar linha. Em uma das linhas, informar CD_TIPO_MOVIMENTO = 1 e DT_REGISTRO = 31/03//2020 Na segunda linha, informar CD_TIPO_MOVIMENTO = 9 e DT_REGISTRO = 31/03//2020
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3228_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3228", "FG02 - PROC131 - Em um único arquivo, duplicar linha. Em uma das linhas, informar CD_TIPO_MOVIMENTO = 1 e DT_REGISTRO = 31/03/2020 Na segunda linha, informar CD_TIPO_MOVIMENTO = 9 e DT_REGISTRO = 31/03//2020");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.SINISTRO-EV-3254-20200321.txt"));

            //ALTERAR O VALOR SELECIONADO
            ReplicarLinha(0, 1);
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "1");
            AlterarLinha(0, "DT_REGISTRO", "31/03/2020");
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "9");
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "31/03/2020");

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

        /// <summary>
        ///Em um único arquivo, duplicar linha. Em uma das linhas, informar CD_TIPO_MOVIMENTO = 1 e DT_REGISTRO = 02/03/2020 Na segunda linha, informar CD_TIPO_MOVIMENTO = 30 e DT_REGISTRO = 02/03/2020
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3229_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3229", "FG02 - PROC131 - Em um único arquivo, duplicar linha. Em uma das linhas, informar CD_TIPO_MOVIMENTO = 1 e DT_REGISTRO = 02/03/2020 Na segunda linha, informar CD_TIPO_MOVIMENTO = 30 e DT_REGISTRO = 02/03/2020");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.SINISTRO-EV-3280-20200323.txt"));

            //ALTERAR O VALOR SELECIONADO
            ReplicarLinha(0, 1);
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "1");
            AlterarLinha(0, "DT_REGISTRO", "02/03/2020");
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "30");
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "02/03/2020");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SOFTBOX.SINISTRO-EV-/*R*/-20200323.txt");

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
        ///Em um único arquivo, duplicar linha. Em uma das linhas, informar CD_TIPO_MOVIMENTO = 1 e DT_REGISTRO = 02/03/2020 Na segunda linha, informar CD_TIPO_MOVIMENTO = 11 e DT_REGISTRO = 02/03/2020
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3230_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3230", "FG02 - PROC131 - Em um único arquivo, duplicar linha. Em uma das linhas, informar CD_TIPO_MOVIMENTO = 1 e DT_REGISTRO = 02/03/2020 Na segunda linha, informar CD_TIPO_MOVIMENTO = 11 e DT_REGISTRO = 02/03/2020");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.SINISTRO-EV-3297-20200324.txt"));

            //ALTERAR O VALOR SELECIONADO
            ReplicarLinha(0, 1);
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "1");
            AlterarLinha(0, "DT_REGISTRO", "02/03/2020");
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "11");
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "02/03/2020");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SOFTBOX.SINISTRO-EV-/*R*/-20200324.txt");

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
        ///Em um único arquivo, duplicar linha. Em uma das linhas, informar CD_TIPO_MOVIMENTO = 1 e DT_REGISTRO = 29/02/2020 Na segunda linha, informar CD_TIPO_MOVIMENTO = 146 e DT_REGISTRO = 29/02/2020
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3231_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3231", "FG02 - PROC131 - Em um único arquivo, duplicar linha. Em uma das linhas, informar CD_TIPO_MOVIMENTO = 1 e DT_REGISTRO = 29/02/2020 Na segunda linha, informar CD_TIPO_MOVIMENTO = 146 e DT_REGISTRO = 29/02/2020");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.SINISTRO-EV-3300-20200324.txt"));

            //ALTERAR O VALOR SELECIONADO
            ReplicarLinha(0, 1);
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "1");
            AlterarLinha(0, "DT_REGISTRO", "29/02/2020");
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "146");
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "29/02/2020");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SOFTBOX.SINISTRO-EV-/*R*/-20200324.txt");

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
