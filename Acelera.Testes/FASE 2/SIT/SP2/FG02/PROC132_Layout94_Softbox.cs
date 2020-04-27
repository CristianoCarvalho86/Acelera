using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC132_Layout94_Softbox : TestesFG02
    {

        /// <summary>
        /// Em uma das linhas, informar DT_MOVIMENTO=01/04/2020 e DT_AVISO=02/04/2020 CD_TIPO_MOVIMENTO=1
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3272_DT_REGISTRO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3272", "FG02 - PROC132 - Em uma das linhas, informar DT_MOVIMENTO=01/04/2020 e DT_AVISO=02/04/2020 CD_TIPO_MOVIMENTO=1");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.SINISTRO-EV-3191-20200317.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "DT_MOVIMENTO", "20200401");
            AlterarLinha(0, "DT_AVISO", "20200402");
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "1");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SOFTBOX.SINISTRO-EV-/*R*/-20200317.txt");

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
        public void SAP_3273_DT_REGISTRO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3273", "FG02 - PROC132 - Em uma das linhas, informar DT_MOVIMENTO igual a D-10 da do DT_AVISO CD_TIPO_MOVIMENTO=2");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.SINISTRO-EV-3217-20200319.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "DT_MOVIMENTO", SomarData(ObterValor(0,"DT_AVISO"), -10));
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "2");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SOFTBOX.SINISTRO-EV-/*R*/-20200319.txt");

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
        public void SAP_3274_DT_REGISTRO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3274", "FG02 - PROC132 - Em uma das linhas, informar DT_MOVIMENTO igual a D-30 da do DT_AVISO CD_TIPO_MOVIMENTO=7");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.SINISTRO-EV-3220-20200319.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "DT_MOVIMENTO", SomarData(ObterValor(0,"DT_AVISO"), -30));
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "7");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SOFTBOX.SINISTRO-EV-/*R*/-20200319.txt");

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
        public void SAP_3275_DT_REGISTRO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3275", "FG02 - PROC132 - Em uma das linhas, informar DT_MOVIMENTO igual a D-35 da do DT_AVISO CD_TIPO_MOVIMENTO=9");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.SINISTRO-EV-3222-20200319.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "DT_MOVIMENTO", SomarData(ObterValor(0,"DT_AVISO"), -35));
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "9");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SOFTBOX.SINISTRO-EV-/*R*/-20200319.txt");

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
        public void SAP_3276_DT_REGISTRO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3276", "FG02 - PROC132 - Em uma das linhas, informar DT_MOVIMENTO igual a D-60 da do DT_AVISO CD_TIPO_MOVIMENTO=30");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.SINISTRO-EV-3231-20200320.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "DT_MOVIMENTO", SomarData(ObterValor(0,"DT_AVISO"), -60));
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "30");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SOFTBOX.SINISTRO-EV-/*R*/-20200320.txt");

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
        public void SAP_3277_DT_REGISTRO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3277", "FG02 - PROC132 - Em uma das linhas, informar DT_MOVIMENTO igual a D-180 da do DT_AVISO CD_TIPO_MOVIMENTO=11");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.SINISTRO-EV-3232-20200320.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "DT_MOVIMENTO", SomarData(ObterValor(0,"DT_AVISO"), -180));
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "11");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SOFTBOX.SINISTRO-EV-/*R*/-20200320.txt");

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
        public void SAP_3278_DT_REGISTRO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3278", "FG02 - PROC132 - Em uma das linhas, informar DT_MOVIMENTO igual a D-365 da do DT_AVISO CD_TIPO_MOVIMENTO=146");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.SINISTRO-EV-3238-20200320.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "DT_MOVIMENTO", SomarData(ObterValor(0,"DT_AVISO"), -365));
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "146");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SOFTBOX.SINISTRO-EV-/*R*/-20200320.txt");

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
        public void SAP_3279_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3279", "FG02 - PROC132 - Em uma das linhas, informar DT_MOVIMENTO D+1 da DT_AVISO CD_TIPO_MOVIMENTO=1");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.SINISTRO-EV-3248-20200321.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "DT_MOVIMENTO", SomarData(ObterValor(0,"DT_AVISO"), 1));
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "1");

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
        ///Em uma das linhas, informar DT_MOVIMENTO D+10 da DT_AVISO CD_TIPO_MOVIMENTO=2
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3280_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3280", "FG02 - PROC132 - Em uma das linhas, informar DT_MOVIMENTO D+10 da DT_AVISO CD_TIPO_MOVIMENTO=2");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.SINISTRO-EV-3254-20200321.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "DT_MOVIMENTO", SomarData(ObterValor(0,"DT_AVISO"), 10));
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "2");

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
        ///Em uma das linhas, informar DT_MOVIMENTO D+30 da DT_AVISO CD_TIPO_MOVIMENTO=7
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3281_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3281", "FG02 - PROC132 - Em uma das linhas, informar DT_MOVIMENTO D+30 da DT_AVISO CD_TIPO_MOVIMENTO=7");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.SINISTRO-EV-3280-20200323.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "DT_MOVIMENTO", SomarData(ObterValor(0,"DT_AVISO"), 30));
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "7");

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
        ///Em uma das linhas, informar DT_MOVIMENTO D+35 da DT_AVISO CD_TIPO_MOVIMENTO=9
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3282_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3282", "FG02 - PROC132 - Em uma das linhas, informar DT_MOVIMENTO D+35 da DT_AVISO CD_TIPO_MOVIMENTO=9");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.SINISTRO-EV-3297-20200324.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "DT_MOVIMENTO", SomarData(ObterValor(0,"DT_AVISO"), 35));
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "9");

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
        ///Em uma das linhas, informar DT_MOVIMENTO D+60 da DT_AVISO CD_TIPO_MOVIMENTO=30
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3283_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3283", "FG02 - PROC132 - Em uma das linhas, informar DT_MOVIMENTO D+60 da DT_AVISO CD_TIPO_MOVIMENTO=30");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.SINISTRO-EV-3300-20200324.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "DT_MOVIMENTO", SomarData(ObterValor(0,"DT_AVISO"), 60));
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "30");

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
        ///Em uma das linhas, informar DT_MOVIMENTO D+180 da DT_AVISO CD_TIPO_MOVIMENTO=11
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3284_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3284", "FG02 - PROC132 - Em uma das linhas, informar DT_MOVIMENTO D+180 da DT_AVISO CD_TIPO_MOVIMENTO=11");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.SINISTRO-EV-3302-20200324.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "DT_MOVIMENTO", SomarData(ObterValor(0,"DT_AVISO"), 180));
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "11");

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
        ///Em uma das linhas, informar DT_MOVIMENTO D+365 da DT_AVISO CD_TIPO_MOVIMENTO=146
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3285_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3285", "FG02 - PROC132 - Em uma das linhas, informar DT_MOVIMENTO D+365 da DT_AVISO CD_TIPO_MOVIMENTO=146");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.SINISTRO-EV-3318-20200325.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "DT_MOVIMENTO", SomarData(ObterValor(0,"DT_AVISO"), 365));
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "146");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SOFTBOX.SINISTRO-EV-/*R*/-20200325.txt");

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
