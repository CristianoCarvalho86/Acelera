using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC132_Layout94_LASA : TestesFG02
    {

        /// <summary>
        /// Em uma das linhas, informar DT_MOVIMENTO=01/04/2020 e DT_AVISO=02/04/2020 CD_TIPO_MOVIMENTO=1
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3258_DT_REGISTRO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3258", "FG02 - PROC132 - Em uma das linhas, informar DT_MOVIMENTO=01/04/2020 e DT_AVISO=02/04/2020 CD_TIPO_MOVIMENTO=1");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.SINISTRO-EV-2757-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "DT_MOVIMENTO", "01/04/2020");
            AlterarLinha(0, "DT_AVISO", "02/04/2020");
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "1");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.SINISTRO-EV-/*R*/-20200211.txt");

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
        public void SAP_3259_DT_REGISTRO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3259", "FG02 - PROC132 - Em uma das linhas, informar DT_MOVIMENTO igual a D-10 da do DT_AVISO CD_TIPO_MOVIMENTO=2");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.SINISTRO-EV-2758-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "DT_MOVIMENTO", SomarData("DT_AVISO", -10));
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "2");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.SINISTRO-EV-/*R*/-20200211.txt");

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
        public void SAP_3260_DT_REGISTRO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3260", "FG02 - PROC132 - Em uma das linhas, informar DT_MOVIMENTO igual a D-30 da do DT_AVISO CD_TIPO_MOVIMENTO=7");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.SINISTRO-EV-3287-20200323.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "DT_MOVIMENTO", SomarData("DT_AVISO", -30));
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "7");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.SINISTRO-EV-/*R*/-20200323.txt");

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
        public void SAP_3261_DT_REGISTRO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3261", "FG02 - PROC132 - Em uma das linhas, informar DT_MOVIMENTO igual a D-35 da do DT_AVISO CD_TIPO_MOVIMENTO=9");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.SINISTRO-EV-3296-20200324.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "DT_MOVIMENTO", SomarData("DT_AVISO", -35));
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "9");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.SINISTRO-EV-/*R*/-20200324.txt");

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
        public void SAP_3262_DT_REGISTRO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3262", "FG02 - PROC132 - Em uma das linhas, informar DT_MOVIMENTO igual a D-60 da do DT_AVISO CD_TIPO_MOVIMENTO=30");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.SINISTRO-EV-3298-20200324.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "DT_MOVIMENTO", SomarData("DT_AVISO", -60));
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "30");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.SINISTRO-EV-/*R*/-20200324.txt");

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
        public void SAP_3263_DT_REGISTRO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3263", "FG02 - PROC132 - Em uma das linhas, informar DT_MOVIMENTO igual a D-180 da do DT_AVISO CD_TIPO_MOVIMENTO=11");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.SINISTRO-EV-3301-20200324.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "DT_MOVIMENTO", SomarData("DT_AVISO", -180));
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "11");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.SINISTRO-EV-/*R*/-20200324.txt");

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
        public void SAP_3264_DT_REGISTRO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3264", "FG02 - PROC132 - Em uma das linhas, informar DT_MOVIMENTO igual a D-365 da do DT_AVISO CD_TIPO_MOVIMENTO=146");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.SINISTRO-EV-3303-20200324.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "DT_MOVIMENTO", SomarData("DT_AVISO", -365));
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "146");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.SINISTRO-EV-/*R*/-20200324.txt");

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
        public void SAP_3265_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3265", "FG02 - PROC132 - Em uma das linhas, informar DT_MOVIMENTO D+1 da DT_AVISO CD_TIPO_MOVIMENTO=1");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.SINISTRO-EV-3312-20200325.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "DT_MOVIMENTO", SomarData("DT_AVISO", 1));
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "1");

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
        ///Em uma das linhas, informar DT_MOVIMENTO D+10 da DT_AVISO CD_TIPO_MOVIMENTO=2
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3266_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3266", "FG02 - PROC132 - Em uma das linhas, informar DT_MOVIMENTO D+10 da DT_AVISO CD_TIPO_MOVIMENTO=2");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.SINISTRO-EV-3314-20200325.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "DT_MOVIMENTO", SomarData("DT_AVISO", 10));
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "2");

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
        ///Em uma das linhas, informar DT_MOVIMENTO D+30 da DT_AVISO CD_TIPO_MOVIMENTO=7
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3267_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3267", "FG02 - PROC132 - Em uma das linhas, informar DT_MOVIMENTO D+30 da DT_AVISO CD_TIPO_MOVIMENTO=7");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.SINISTRO-EV-3317-20200325.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "DT_MOVIMENTO", SomarData("DT_AVISO", 30));
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "7");

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
        ///Em uma das linhas, informar DT_MOVIMENTO D+35 da DT_AVISO CD_TIPO_MOVIMENTO=9
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3268_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3268", "FG02 - PROC132 - Em uma das linhas, informar DT_MOVIMENTO D+35 da DT_AVISO CD_TIPO_MOVIMENTO=9");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.SINISTRO-EV-3319-20200325.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "DT_MOVIMENTO", SomarData("DT_AVISO", 35));
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "9");

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
        ///Em uma das linhas, informar DT_MOVIMENTO D+60 da DT_AVISO CD_TIPO_MOVIMENTO=30
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3269_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3269", "FG02 - PROC132 - Em uma das linhas, informar DT_MOVIMENTO D+60 da DT_AVISO CD_TIPO_MOVIMENTO=30");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.SINISTRO-EV-3329-20200326.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "DT_MOVIMENTO", SomarData("DT_AVISO", 60));
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "30");

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

        /// <summary>
        ///Em uma das linhas, informar DT_MOVIMENTO D+180 da DT_AVISO CD_TIPO_MOVIMENTO=11
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3270_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3270", "FG02 - PROC132 - Em uma das linhas, informar DT_MOVIMENTO D+180 da DT_AVISO CD_TIPO_MOVIMENTO=11");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01..SINISTRO-EV-3331-20200326.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "DT_MOVIMENTO", SomarData("DT_AVISO", 180));
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "11");

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

        /// <summary>
        ///Em uma das linhas, informar DT_MOVIMENTO D+365 da DT_AVISO CD_TIPO_MOVIMENTO=146
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3271_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3271", "FG02 - PROC132 - Em uma das linhas, informar DT_MOVIMENTO D+365 da DT_AVISO CD_TIPO_MOVIMENTO=146");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.SINISTRO-EV-3334-20200326.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "DT_MOVIMENTO", SomarData("DT_AVISO", 365));
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "146");

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
