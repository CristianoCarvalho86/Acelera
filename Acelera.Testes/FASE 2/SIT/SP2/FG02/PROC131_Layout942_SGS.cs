using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4_2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC131_Layout942_SGS : TestesFG02
    {

        /// <summary>
        /// Em um único arquivo, duplicar linha. Em uma das linhas, informar CD_TIPO_MOVIMENTO = 1 e DT_REGISTRO = 01/04/2020 Na segunda linha, informar CD_TIPO_MOVIMENTO = 2 e DT_REGISTRO = 02/04/2020
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3232_DT_REGISTRO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3232", "FG02 - PROC131 - Em um único arquivo, duplicar linha. Em uma das linhas, informar CD_TIPO_MOVIMENTO = 1 e DT_REGISTRO = 01/04/2020 Na segunda linha, informar CD_TIPO_MOVIMENTO = 2 e DT_REGISTRO = 02/04/2020");
            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200209.txt"));

            //ALTERAR O VALOR SELECIONADO
            ReplicarLinhaComCorrecao(0, 1);
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "1");
            AlterarLinha(0, "DT_REGISTRO", "20200401");
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "2");
            AlterarLinha(1, "DT_REGISTRO", "20200402");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SGS.SINISTRO-EV-/*R*/-20200209.txt");

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
        public void SAP_3233_DT_REGISTRO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3233", "FG02 - PROC131 - Em um único arquivo, duplicar linha. Em uma das linhas, informar CD_TIPO_MOVIMENTO = 1 e DT_REGISTRO = 01/04/2020 Na segunda linha, informar CD_TIPO_MOVIMENTO = 7 e DT_REGISTRO = 07/03/2020");
            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            ReplicarLinhaComCorrecao(0, 1);
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "1");
            AlterarLinha(0, "DT_REGISTRO", "20200401");
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "7");
            AlterarLinha(1, "DT_REGISTRO", "20200307");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SGS.SINISTRO-EV-/*R*/-20200211.txt");

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
        public void SAP_3234_DT_REGISTRO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3234", "FG02 - PROC131 - Em um único arquivo, duplicar linha. Em uma das linhas, informar CD_TIPO_MOVIMENTO = 1 e DT_REGISTRO = 01/04/2020 Na segunda linha, informar CD_TIPO_MOVIMENTO = 9 e DT_REGISTRO = 31/03//2020");
            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            ReplicarLinhaComCorrecao(0, 1);
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "1");
            AlterarLinha(0, "DT_REGISTRO", "20200401");
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "9");
            AlterarLinha(1, "DT_REGISTRO", "20200331");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SGS.SINISTRO-EV-/*R*/-20200212.txt");

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
        public void SAP_3235_DT_REGISTRO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3235", "FG02 - PROC131 - Em um único arquivo, duplicar linha. Em uma das linhas, informar CD_TIPO_MOVIMENTO = 1 e DT_REGISTRO = 01/03/2020 Na segunda linha, informar CD_TIPO_MOVIMENTO = 30 e DT_REGISTRO = 02/03/2020");
            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200213.txt"));

            //ALTERAR O VALOR SELECIONADO
            ReplicarLinhaComCorrecao(0, 1);
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "1");
            AlterarLinha(0, "DT_REGISTRO", "20200301");
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "30");
            AlterarLinha(1, "DT_REGISTRO", "20200302");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SGS.SINISTRO-EV-/*R*/-20200213.txt");

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
        public void SAP_3236_DT_REGISTRO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3236", "FG02 - PROC131 - Em um único arquivo, duplicar linha. Em uma das linhas, informar CD_TIPO_MOVIMENTO = 1 e DT_REGISTRO = 31/03/2020 Na segunda linha, informar CD_TIPO_MOVIMENTO = 11 e DT_REGISTRO = 01/04/2020");
            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200209.txt"));

            //ALTERAR O VALOR SELECIONADO
            ReplicarLinhaComCorrecao(0, 1);
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "1");
            AlterarLinha(0, "DT_REGISTRO", "20200331");
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "11");
            AlterarLinha(1, "DT_REGISTRO", "20200401");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SGS.SINISTRO-EV-/*R*/-20200209.txt");

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
        public void SAP_3237_DT_REGISTRO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3237", "FG02 - PROC131 - Em um único arquivo, duplicar linha. Em uma das linhas, informar CD_TIPO_MOVIMENTO = 1 e DT_REGISTRO = 29/02/2020 Na segunda linha, informar CD_TIPO_MOVIMENTO = 146 e DT_REGISTRO = 02/03/2020");
            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            ReplicarLinhaComCorrecao(0, 1);
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "1");
            AlterarLinha(0, "DT_REGISTRO", "20200229");
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "146");
            AlterarLinha(1, "DT_REGISTRO", "20200302");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SGS.SINISTRO-EV-/*R*/-20200211.txt");

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
        public void SAP_3238_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3238", "FG02 - PROC131 - Em um único arquivo, duplicar linha. Em uma das linhas, informar CD_TIPO_MOVIMENTO = 1 e DT_REGISTRO = 01/04/2020 Na segunda linha, informar CD_TIPO_MOVIMENTO = 2 e DT_REGISTRO = 01/04/2020");

            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            ReplicarLinhaComCorrecao(0, 1);
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "1");
            AlterarLinha(0, "DT_REGISTRO", "20200401");
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "2");
            AlterarLinha(1, "DT_REGISTRO", "20200401");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SGS.SINISTRO-EV-/*R*/-20200212.txt");

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
        public void SAP_3239_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3239", "FG02 - PROC131 - Em um único arquivo, duplicar linha. Em uma das linhas, informar CD_TIPO_MOVIMENTO = 1 e DT_REGISTRO = 07/03/2020 Na segunda linha, informar CD_TIPO_MOVIMENTO = 7 e DT_REGISTRO = 07/03/2020");

            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200213.txt"));

            //ALTERAR O VALOR SELECIONADO
            ReplicarLinhaComCorrecao(0, 1);
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "1");
            AlterarLinha(0, "DT_REGISTRO", "20200307");
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "7");
            AlterarLinha(1, "DT_REGISTRO", "20200307");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SGS.SINISTRO-EV-/*R*/-20200213.txt");

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
        public void SAP_3240_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3240", "FG02 - PROC131 - Em um único arquivo, duplicar linha. Em uma das linhas, informar CD_TIPO_MOVIMENTO = 1 e DT_REGISTRO = 31/03/2020 Na segunda linha, informar CD_TIPO_MOVIMENTO = 9 e DT_REGISTRO = 31/03//2020");

            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200209.txt"));

            //ALTERAR O VALOR SELECIONADO
            ReplicarLinhaComCorrecao(0, 1);
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "1");
            AlterarLinha(0, "DT_REGISTRO", "20200331");
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "9");
            AlterarLinha(1, "DT_REGISTRO", "20200331");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SGS.SINISTRO-EV-/*R*/-20200209.txt");

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
        public void SAP_3241_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3241", "FG02 - PROC131 - Em um único arquivo, duplicar linha. Em uma das linhas, informar CD_TIPO_MOVIMENTO = 1 e DT_REGISTRO = 02/03/2020 Na segunda linha, informar CD_TIPO_MOVIMENTO = 30 e DT_REGISTRO = 02/03/2020");

            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            ReplicarLinhaComCorrecao(0, 1);
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "1");
            AlterarLinha(0, "DT_REGISTRO", "20200302");
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "30");
            AlterarLinha(1, "DT_REGISTRO", "20200302");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SGS.SINISTRO-EV-/*R*/-20200211.txt");

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
        public void SAP_3242_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3242", "FG02 - PROC131 - Em um único arquivo, duplicar linha. Em uma das linhas, informar CD_TIPO_MOVIMENTO = 1 e DT_REGISTRO = 02/03/2020 Na segunda linha, informar CD_TIPO_MOVIMENTO = 11 e DT_REGISTRO = 02/03/2020");

            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            ReplicarLinhaComCorrecao(0, 1);
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "1");
            AlterarLinha(0, "DT_REGISTRO", "20200302");
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "11");
            AlterarLinha(1, "DT_REGISTRO", "20200302");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SGS.SINISTRO-EV-/*R*/-20200212.txt");

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
        public void SAP_3243_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3243", "FG02 - PROC131 - Em um único arquivo, duplicar linha. Em uma das linhas, informar CD_TIPO_MOVIMENTO = 1 e DT_REGISTRO = 29/02/2020 Na segunda linha, informar CD_TIPO_MOVIMENTO = 146 e DT_REGISTRO = 29/02/2020");

            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200213.txt"));

            //ALTERAR O VALOR SELECIONADO
            ReplicarLinhaComCorrecao(0, 1);
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "1");
            AlterarLinha(0, "DT_REGISTRO", "20200229");
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "146");
            AlterarLinha(1, "DT_REGISTRO", "20200229");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SGS.SINISTRO-EV-/*R*/-20200213.txt");

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
