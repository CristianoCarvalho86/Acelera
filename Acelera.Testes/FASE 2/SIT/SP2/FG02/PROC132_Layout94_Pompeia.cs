using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC132_Layout94_Pompeia : TestesFG02
    {

        /// <summary>
        /// Em uma das linhas, informar DT_MOVIMENTO=01/04/2020 e DT_AVISO=02/04/2020 CD_TIPO_MOVIMENTO=1
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3244_DT_REGISTRO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3244", "FG02 - PROC132 - Em uma das linhas, informar DT_MOVIMENTO=01/04/2020 e DT_AVISO=02/04/2020 CD_TIPO_MOVIMENTO=1");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.SINISTRO-EV-0001-20191223.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "DT_MOVIMENTO", "20200401");
            AlterarLinha(0, "DT_AVISO", "20200402");
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "1");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.POMPEIA.SINISTRO-EV-/*R*/-20191223.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "132");
            ValidarTeste();
        }

        /// <summary>
        /// Em uma das linhas, informar DT_MOVIMENTO igual a D-10 da do DT_AVISO CD_TIPO_MOVIMENTO=2
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3245_DT_REGISTRO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3245", "FG02 - PROC132 - Em uma das linhas, informar DT_MOVIMENTO igual a D-10 da do DT_AVISO CD_TIPO_MOVIMENTO=2");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.SINISTRO-EV-0001-20200117.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "DT_MOVIMENTO", SomarData(ObterValor(0,"DT_AVISO"), -10));
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "2");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.POMPEIA.SINISTRO-EV-/*R*/-20200117.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "132");
            ValidarTeste();
        }

        /// <summary>
        /// Em uma das linhas, informar DT_MOVIMENTO igual a D-30 da do DT_AVISO CD_TIPO_MOVIMENTO=7
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3246_DT_REGISTRO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3246", "FG02 - PROC132 - Em uma das linhas, informar DT_MOVIMENTO igual a D-30 da do DT_AVISO CD_TIPO_MOVIMENTO=7");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.SINISTRO-EV-0001-20200127.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "DT_MOVIMENTO", SomarData(ObterValor(0,"DT_AVISO"), -30));
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "7");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.POMPEIA.SINISTRO-EV-/*R*/-20200127.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "132");
            ValidarTeste();
        }

        /// <summary>
        /// Em uma das linhas, informar DT_MOVIMENTO igual a D-35 da do DT_AVISO CD_TIPO_MOVIMENTO=9
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3247_DT_REGISTRO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3247", "FG02 - PROC132 - Em uma das linhas, informar DT_MOVIMENTO igual a D-35 da do DT_AVISO CD_TIPO_MOVIMENTO=9");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.SINISTRO-EV-0001-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "DT_MOVIMENTO", SomarData(ObterValor(0,"DT_AVISO"), -35));
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "9");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.POMPEIA.SINISTRO-EV-/*R*/-20200211.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "132");
            ValidarTeste();
        }

        /// <summary>
        /// Em uma das linhas, informar DT_MOVIMENTO igual a D-60 da do DT_AVISO CD_TIPO_MOVIMENTO=30
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3248_DT_REGISTRO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3248", "FG02 - PROC132 - Em uma das linhas, informar DT_MOVIMENTO igual a D-60 da do DT_AVISO CD_TIPO_MOVIMENTO=30");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.SINISTRO-EV-0002-20191220.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "DT_MOVIMENTO", SomarData(ObterValor(0,"DT_AVISO"), -60));
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "30");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.POMPEIA.SINISTRO-EV-/*R*/-20191220.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "132");
            ValidarTeste();
        }

        /// <summary>
        /// Em uma das linhas, informar DT_MOVIMENTO igual a D-180 da do DT_AVISO CD_TIPO_MOVIMENTO=11
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3249_DT_REGISTRO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3249", "FG02 - PROC132 - Em uma das linhas, informar DT_MOVIMENTO igual a D-180 da do DT_AVISO CD_TIPO_MOVIMENTO=11");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.SINISTRO-EV-0001-20191223.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "DT_MOVIMENTO", SomarData(ObterValor(0,"DT_AVISO"), -180));
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "11");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.POMPEIA.SINISTRO-EV-/*R*/-20191223.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "132");
            ValidarTeste();
        }

        /// <summary>
        /// Em uma das linhas, informar DT_MOVIMENTO igual a D-365 da do DT_AVISO CD_TIPO_MOVIMENTO=146
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3250_DT_REGISTRO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3250", "FG02 - PROC132 - Em uma das linhas, informar DT_MOVIMENTO igual a D-365 da do DT_AVISO CD_TIPO_MOVIMENTO=146");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.SINISTRO-EV-0001-20200117.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "DT_MOVIMENTO", SomarData(ObterValor(0,"DT_AVISO"), -365));
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "146");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.POMPEIA.SINISTRO-EV-/*R*/-20200117.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "132");
            ValidarTeste();
        }

        /// <summary>
        ///Em uma das linhas, informar DT_MOVIMENTO D+1 da DT_AVISO CD_TIPO_MOVIMENTO=1
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3251_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3251", "FG02 - PROC132 - Em uma das linhas, informar DT_MOVIMENTO D+1 da DT_AVISO CD_TIPO_MOVIMENTO=1");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.SINISTRO-EV-0001-20200127.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "DT_MOVIMENTO", SomarData(ObterValor(0,"DT_AVISO"), 1));
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "1");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.POMPEIA.SINISTRO-EV-/*R*/-20200127.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(true, "132");
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia, true);
            ValidarTeste();

        }

        /// <summary>
        ///Em uma das linhas, informar DT_MOVIMENTO D+10 da DT_AVISO CD_TIPO_MOVIMENTO=2
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3252_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3252", "FG02 - PROC132 - Em uma das linhas, informar DT_MOVIMENTO D+10 da DT_AVISO CD_TIPO_MOVIMENTO=2");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.SINISTRO-EV-0001-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "DT_MOVIMENTO", SomarData(ObterValor(0,"DT_AVISO"), 10));
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "2");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.POMPEIA.SINISTRO-EV-/*R*/-20200211.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(true, "132");
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia, true);
            ValidarTeste();

        }

        /// <summary>
        ///Em uma das linhas, informar DT_MOVIMENTO D+30 da DT_AVISO CD_TIPO_MOVIMENTO=7
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3253_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3253", "FG02 - PROC132 - Em uma das linhas, informar DT_MOVIMENTO D+30 da DT_AVISO CD_TIPO_MOVIMENTO=7");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.SINISTRO-EV-0002-20191220.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "DT_MOVIMENTO", SomarData(ObterValor(0,"DT_AVISO"), 30));
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "7");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.POMPEIA.SINISTRO-EV-/*R*/-20191220.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(true, "132");
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia, true);
            ValidarTeste();

        }

        /// <summary>
        ///Em uma das linhas, informar DT_MOVIMENTO D+35 da DT_AVISO CD_TIPO_MOVIMENTO=9
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3254_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3254", "FG02 - PROC132 - Em uma das linhas, informar DT_MOVIMENTO D+35 da DT_AVISO CD_TIPO_MOVIMENTO=9");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.SINISTRO-EV-0001-20191223.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "DT_MOVIMENTO", SomarData(ObterValor(0,"DT_AVISO"), 35));
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "9");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.POMPEIA.SINISTRO-EV-/*R*/-20191223.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(true, "132");
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia, true);
            ValidarTeste();

        }

        /// <summary>
        ///Em uma das linhas, informar DT_MOVIMENTO D+60 da DT_AVISO CD_TIPO_MOVIMENTO=30
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3255_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3255", "FG02 - PROC132 - Em uma das linhas, informar DT_MOVIMENTO D+60 da DT_AVISO CD_TIPO_MOVIMENTO=30");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.SINISTRO-EV-0001-20200117.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "DT_MOVIMENTO", SomarData(ObterValor(0,"DT_AVISO"), 60));
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "30");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.POMPEIA.SINISTRO-EV-/*R*/-20200117.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(true, "132");
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia, true);
            ValidarTeste();

        }

        /// <summary>
        ///Em uma das linhas, informar DT_MOVIMENTO D+180 da DT_AVISO CD_TIPO_MOVIMENTO=11
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3256_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3256", "FG02 - PROC132 - Em uma das linhas, informar DT_MOVIMENTO D+180 da DT_AVISO CD_TIPO_MOVIMENTO=11");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.SINISTRO-EV-0001-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "DT_MOVIMENTO", SomarData(ObterValor(0,"DT_AVISO"), 180));
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "11");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.POMPEIA.SINISTRO-EV-/*R*/-20200211.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(true, "132");
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia, true);
            ValidarTeste();

        }

        /// <summary>
        ///Em uma das linhas, informar DT_MOVIMENTO D+365 da DT_AVISO CD_TIPO_MOVIMENTO=146
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3257_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3257", "FG02 - PROC132 - Em uma das linhas, informar DT_MOVIMENTO D+365 da DT_AVISO CD_TIPO_MOVIMENTO=146");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.SINISTRO-EV-0002-20191220.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "DT_MOVIMENTO", SomarData(ObterValor(0,"DT_AVISO"), 365));
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "146");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.POMPEIA.SINISTRO-EV-/*R*/-20191220.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(true, "132");
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia, true);
            ValidarTeste();

        }
    }
}
