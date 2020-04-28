using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC131_Layout94_LASA : TestesFG02
    {

        /// <summary>
        /// Em um único arquivo, duplicar linha. Em uma das linhas, informar CD_TIPO_MOVIMENTO = 1 e DT_REGISTRO = 01/04/2020 Na segunda linha, informar CD_TIPO_MOVIMENTO = 2 e DT_REGISTRO = 02/04/2020
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3208_DT_REGISTRO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3208", "FG02 - PROC131 - Em um único arquivo, duplicar linha. Em uma das linhas, informar CD_TIPO_MOVIMENTO = 1 e DT_REGISTRO = 01/04/2020 Na segunda linha, informar CD_TIPO_MOVIMENTO = 2 e DT_REGISTRO = 02/04/2020");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.SINISTRO-EV-2757-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "1");
            AlterarLinha(0, "DT_REGISTRO", "20200401");
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "2");
            AlterarLinha(1, "DT_REGISTRO", "20200402");
            AlterarLinha(1, "CD_SINISTRO", ObterValor(0, "CD_SINISTRO"));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.SINISTRO-EV-/*R*/-20200211.txt");

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
        public void SAP_3209_DT_REGISTRO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3209", "FG02 - PROC131 - Em um único arquivo, duplicar linha. Em uma das linhas, informar CD_TIPO_MOVIMENTO = 1 e DT_REGISTRO = 01/04/2020 Na segunda linha, informar CD_TIPO_MOVIMENTO = 7 e DT_REGISTRO = 07/03/2020");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.SINISTRO-EV-2758-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO

            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "1");
            AlterarLinha(0, "DT_REGISTRO", "20200401");
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "7");
            AlterarLinha(1, "DT_REGISTRO", "20200703");
            AlterarLinha(1, "CD_SINISTRO", ObterValor(0, "CD_SINISTRO"));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.SINISTRO-EV-/*R*/-20200211.txt");

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
        public void SAP_3210_DT_REGISTRO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3210", "FG02 - PROC131 - Em um único arquivo, duplicar linha. Em uma das linhas, informar CD_TIPO_MOVIMENTO = 1 e DT_REGISTRO = 01/04/2020 Na segunda linha, informar CD_TIPO_MOVIMENTO = 9 e DT_REGISTRO = 31/03//2020");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.SINISTRO-EV-3287-20200323.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "1");
            AlterarLinha(0, "DT_REGISTRO", "20200401");
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "9");
            AlterarLinha(1, "DT_REGISTRO", "20200331");
            AlterarLinha(1, "CD_SINISTRO", ObterValor(0, "CD_SINISTRO"));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.SINISTRO-EV-/*R*/-20200323.txt");

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
        public void SAP_3211_DT_REGISTRO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3211", "FG02 - PROC131 - Em um único arquivo, duplicar linha. Em uma das linhas, informar CD_TIPO_MOVIMENTO = 1 e DT_REGISTRO = 01/03/2020 Na segunda linha, informar CD_TIPO_MOVIMENTO = 30 e DT_REGISTRO = 02/03/2020");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.SINISTRO-EV-3296-20200324.txt"));

            //ALTERAR O VALOR SELECIONADO

            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "1");
            AlterarLinha(0, "DT_REGISTRO", "20200301");
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "30");
            AlterarLinha(1, "DT_REGISTRO", "20200302");
            AlterarLinha(1, "CD_SINISTRO", ObterValor(0, "CD_SINISTRO"));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.SINISTRO-EV-/*R*/-20200324.txt");

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
        public void SAP_3212_DT_REGISTRO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3212", "FG02 - PROC131 - Em um único arquivo, duplicar linha. Em uma das linhas, informar CD_TIPO_MOVIMENTO = 1 e DT_REGISTRO = 31/03/2020 Na segunda linha, informar CD_TIPO_MOVIMENTO = 11 e DT_REGISTRO = 01/04/2020");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.SINISTRO-EV-3298-20200324.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "1");
            AlterarLinha(0, "DT_REGISTRO", "20200331");
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "11");
            AlterarLinha(1, "DT_REGISTRO", "20200401");
            AlterarLinha(1, "CD_SINISTRO", ObterValor(0, "CD_SINISTRO"));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.SINISTRO-EV-/*R*/-20200324.txt");

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
        public void SAP_3213_DT_REGISTRO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3213", "FG02 - PROC131 - Em um único arquivo, duplicar linha. Em uma das linhas, informar CD_TIPO_MOVIMENTO = 1 e DT_REGISTRO = 29/02/2020 Na segunda linha, informar CD_TIPO_MOVIMENTO = 146 e DT_REGISTRO = 02/03/2020");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.SINISTRO-EV-3301-20200324.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "1");
            AlterarLinha(0, "DT_REGISTRO", "20200229");
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "146");
            AlterarLinha(1, "DT_REGISTRO", "20200302");
            AlterarLinha(1, "CD_SINISTRO", ObterValor(0, "CD_SINISTRO"));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("PROC131");

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
        public void SAP_3214_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3214", "FG02 - PROC131 - Em um único arquivo, duplicar linha. Em uma das linhas, informar CD_TIPO_MOVIMENTO = 1 e DT_REGISTRO = 01/04/2020 Na segunda linha, informar CD_TIPO_MOVIMENTO = 2 e DT_REGISTRO = 01/04/2020");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.SINISTRO-EV-3303-20200324.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "1");
            AlterarLinha(0, "DT_REGISTRO", "20200401");
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "2");
            AlterarLinha(1, "DT_REGISTRO", "20200401");
            AlterarLinha(1, "CD_SINISTRO", ObterValor(0, "CD_SINISTRO"));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.SINISTRO-EV-/*R*/-20200324.txt");

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
        public void SAP_3215_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3215", "FG02 - PROC131 - Em um único arquivo, duplicar linha. Em uma das linhas, informar CD_TIPO_MOVIMENTO = 1 e DT_REGISTRO = 07/03/2020 Na segunda linha, informar CD_TIPO_MOVIMENTO = 7 e DT_REGISTRO = 07/03/2020");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.SINISTRO-EV-3312-20200325.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "1");
            AlterarLinha(0, "DT_REGISTRO", "20200307");
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "7");
            AlterarLinha(1, "DT_REGISTRO", "20200307");
            AlterarLinha(1, "CD_SINISTRO", ObterValor(0, "CD_SINISTRO"));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.SINISTRO-EV-/*R*/-20200325.txt");

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
        public void SAP_3216_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3216", "FG02 - PROC131 - Em um único arquivo, duplicar linha. Em uma das linhas, informar CD_TIPO_MOVIMENTO = 1 e DT_REGISTRO = 31/03/2020 Na segunda linha, informar CD_TIPO_MOVIMENTO = 9 e DT_REGISTRO = 31/03//2020");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.SINISTRO-EV-3314-20200325.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "1");
            AlterarLinha(0, "DT_REGISTRO", "20200331");
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "9");
            AlterarLinha(1, "DT_REGISTRO", "20200331");
            AlterarLinha(1, "CD_SINISTRO", ObterValor(0, "CD_SINISTRO"));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.SINISTRO-EV-/*R*/-20200325.txt");

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
        public void SAP_3217_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3217", "FG02 - PROC131 - Em um único arquivo, duplicar linha. Em uma das linhas, informar CD_TIPO_MOVIMENTO = 1 e DT_REGISTRO = 02/03/2020 Na segunda linha, informar CD_TIPO_MOVIMENTO = 30 e DT_REGISTRO = 02/03/2020");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.SINISTRO-EV-3317-20200325.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "1");
            AlterarLinha(0, "DT_REGISTRO", "20200302");
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "30");
            AlterarLinha(1, "DT_REGISTRO", "20200302");
            AlterarLinha(1, "CD_SINISTRO", ObterValor(0, "CD_SINISTRO"));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.SINISTRO-EV-/*R*/-20200325.txt");

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
        public void SAP_3218_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3218", "FG02 - PROC131 - Em um único arquivo, duplicar linha. Em uma das linhas, informar CD_TIPO_MOVIMENTO = 1 e DT_REGISTRO = 02/03/2020 Na segunda linha, informar CD_TIPO_MOVIMENTO = 11 e DT_REGISTRO = 02/03/2020");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.SINISTRO-EV-3319-20200325.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "1");
            AlterarLinha(0, "DT_REGISTRO", "20200302");
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "11");
            AlterarLinha(1, "DT_REGISTRO", "20200302");
            AlterarLinha(1, "CD_SINISTRO", ObterValor(0, "CD_SINISTRO"));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.SINISTRO-EV-/*R*/-20200325.txt");

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
        public void SAP_3219_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3219", "FG02 - PROC131 - Em um único arquivo, duplicar linha. Em uma das linhas, informar CD_TIPO_MOVIMENTO = 1 e DT_REGISTRO = 29/02/2020 Na segunda linha, informar CD_TIPO_MOVIMENTO = 146 e DT_REGISTRO = 29/02/2020");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.SINISTRO-EV-3329-20200326.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "1");
            AlterarLinha(0, "DT_REGISTRO", "20200329");
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "146");
            AlterarLinha(1, "DT_REGISTRO", "20200329");
            AlterarLinha(1, "CD_SINISTRO", ObterValor(0, "CD_SINISTRO"));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.SINISTRO-EV-/*R*/-20200326.txt");

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
