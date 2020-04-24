using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC177_Layout94_Softbox : TestesFG02
    {

        /// <summary>
        /// Informar CD_BANCO_SEG inválido para sinistor com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=01 D_FORMA_PGTO=D	
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3529_CD_BANCO_SEG_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3529", "FG02 - PROC177 - Informar CD_BANCO_SEG inválido para sinistor com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=01 D_FORMA_PGTO=D");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.SINISTRO-EV-3191-20200317.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "146");
            AlterarLinha(0, "CD_BANCO_SEG", dados.ObterCDBancoSeg(false));
            AlterarLinha(0, "TP_SINISTRO", "01");
            AlterarLinha(0, "CD_FORMA_PAGTO", "D");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SOFTBOX.SINISTRO-EV-/*R*/-20200317.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "177");
            ValidarTeste();
        }

        /// <summary>
        /// Informar CD_BANCO_SEG inválido para sinistor com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=02 D_FORMA_PGTO=D	
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3530_CD_BANCO_SEG_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3530", "FG02 - PROC177 - Informar CD_BANCO_SEG inválido para sinistor com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=02 D_FORMA_PGTO=D");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.SINISTRO-EV-3217-20200319.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "146");
            AlterarLinha(0, "CD_BANCO_SEG", dados.ObterCDBancoSeg(false));
            AlterarLinha(0, "TP_SINISTRO", "02");
            AlterarLinha(0, "CD_FORMA_PAGTO", "D");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SOFTBOX.SINISTRO-EV-/*R*/-20200319.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "177");
            ValidarTeste();
        }

        /// <summary>
        /// Informar CD_BANCO_SEG inválido para sinistor com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=03 D_FORMA_PGTO=D	
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3531_CD_BANCO_SEG_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3531", "FG02 - PROC177 - Informar CD_BANCO_SEG inválido para sinistor com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=03 D_FORMA_PGTO=D");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.SINISTRO-EV-3220-20200319.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "146");
            AlterarLinha(0, "CD_BANCO_SEG", dados.ObterCDBancoSeg(false));
            AlterarLinha(0, "TP_SINISTRO", "03");
            AlterarLinha(0, "CD_FORMA_PAGTO", "D");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SOFTBOX.SINISTRO-EV-/*R*/-20200319.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "177");
            ValidarTeste();
        }

        /// <summary>
        /// Informar CD_BANCO_SEG inválido para sinistor com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=04 D_FORMA_PGTO=D	
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3532_CD_BANCO_SEG_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3532", "FG02 - PROC177 - Informar CD_BANCO_SEG inválido para sinistor com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=04 D_FORMA_PGTO=D");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.SINISTRO-EV-3222-20200319.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "146");
            AlterarLinha(0, "CD_BANCO_SEG", dados.ObterCDBancoSeg(false));
            AlterarLinha(0, "TP_SINISTRO", "04");
            AlterarLinha(0, "CD_FORMA_PAGTO", "D");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SOFTBOX.SINISTRO-EV-/*R*/-20200319.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "177");
            ValidarTeste();
        }

        /// <summary>
        /// Informar CD_BANCO_SEG inválido para sinistor com: CD_TIPO_MOVIMENTO=7; TP_SINISTRO=01 D_FORMA_PGTO=D	
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3533_CD_BANCO_SEG_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3533", "FG02 - PROC177 - Informar CD_BANCO_SEG inválido para sinistor com: CD_TIPO_MOVIMENTO=7; TP_SINISTRO=01 D_FORMA_PGTO=D");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.SINISTRO-EV-3231-20200320.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "7");
            AlterarLinha(0, "CD_BANCO_SEG", dados.ObterCDBancoSeg(false));
            AlterarLinha(0, "TP_SINISTRO", "01");
            AlterarLinha(0, "CD_FORMA_PAGTO", "D");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SOFTBOX.SINISTRO-EV-/*R*/-20200320.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "177");
            ValidarTeste();
        }

        /// <summary>
        /// Informar CD_BANCO_SEG inválido para sinistor com: CD_TIPO_MOVIMENTO=7; TP_SINISTRO=02 D_FORMA_PGTO=D	
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3534_CD_BANCO_SEG_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3534", "FG02 - PROC177 - Informar CD_BANCO_SEG inválido para sinistor com: CD_TIPO_MOVIMENTO=7; TP_SINISTRO=02 D_FORMA_PGTO=D");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.SINISTRO-EV-3232-20200320.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "7");
            AlterarLinha(0, "CD_BANCO_SEG", dados.ObterCDBancoSeg(false));
            AlterarLinha(0, "TP_SINISTRO", "02");
            AlterarLinha(0, "CD_FORMA_PAGTO", "D");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SOFTBOX.SINISTRO-EV-/*R*/-20200320.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "177");
            ValidarTeste();
        }

        /// <summary>
        /// Informar CD_BANCO_SEG inválido para sinistor com: CD_TIPO_MOVIMENTO=7; TP_SINISTRO=03 D_FORMA_PGTO=D	
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3535_CD_BANCO_SEG_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3535", "FG02 - PROC177 - Informar CD_BANCO_SEG inválido para sinistor com: CD_TIPO_MOVIMENTO=7; TP_SINISTRO=03 D_FORMA_PGTO=D");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.SINISTRO-EV-3238-20200320.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "7");
            AlterarLinha(0, "CD_BANCO_SEG", dados.ObterCDBancoSeg(false));
            AlterarLinha(0, "TP_SINISTRO", "03");
            AlterarLinha(0, "CD_FORMA_PAGTO", "D");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SOFTBOX.SINISTRO-EV-/*R*/-20200320.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "177");
            ValidarTeste();
        }

        /// <summary>
        /// Informar CD_BANCO_SEG inválido para sinistor com: CD_TIPO_MOVIMENTO=7; TP_SINISTRO=04 D_FORMA_PGTO=D	
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3536_CD_BANCO_SEG_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3536", "FG02 - PROC177 - Informar CD_BANCO_SEG inválido para sinistor com: CD_TIPO_MOVIMENTO=7; TP_SINISTRO=04 D_FORMA_PGTO=D");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.SINISTRO-EV-3248-20200321.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "7");
            AlterarLinha(0, "CD_BANCO_SEG", dados.ObterCDBancoSeg(false));
            AlterarLinha(0, "TP_SINISTRO", "04");
            AlterarLinha(0, "CD_FORMA_PAGTO", "D");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SOFTBOX.SINISTRO-EV-/*R*/-20200321.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "177");
            ValidarTeste();
        }

        /// <summary>
        ///Informar CD_BANCO_SEG válido para sinistor com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=01 D_FORMA_PGTO=D	
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3537_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3537", "FG02 - PROC177 - Informar CD_BANCO_SEG válido para sinistor com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=01 D_FORMA_PGTO=D	");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.SINISTRO-EV-3254-20200321.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "146");
            AlterarLinha(0, "CD_BANCO_SEG", dados.ObterCDBancoSeg(true));
            AlterarLinha(0, "TP_SINISTRO", "01");
            AlterarLinha(0, "CD_FORMA_PAGTO", "D");

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
        ///Informar CD_BANCO_SEG válido para sinistor com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=02 D_FORMA_PGTO=D	
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3538_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3538", "FG02 - PROC177 - Informar CD_BANCO_SEG válido para sinistor com: CD_TIPO_MOVIMENTO=7; TP_SINISTRO=02 D_FORMA_PGTO=D	");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.SINISTRO-EV-3280-20200323.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "146");
            AlterarLinha(0, "CD_BANCO_SEG", dados.ObterCDBancoSeg(true));
            AlterarLinha(0, "TP_SINISTRO", "02");
            AlterarLinha(0, "CD_FORMA_PAGTO", "D");

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
        ///Informar CD_BANCO_SEG válido para sinistor com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=03 D_FORMA_PGTO=D	
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3539_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3539", "FG02 - PROC177 - Informar CD_BANCO_SEG válido para sinistor com: CD_TIPO_MOVIMENTO=7; TP_SINISTRO=03 D_FORMA_PGTO=D	");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.SINISTRO-EV-3297-20200324.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "146");
            AlterarLinha(0, "CD_BANCO_SEG", dados.ObterCDBancoSeg(true));
            AlterarLinha(0, "TP_SINISTRO", "03");
            AlterarLinha(0, "CD_FORMA_PAGTO", "D");

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
        ///Informar CD_BANCO_SEG válido para sinistor com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=04 D_FORMA_PGTO=D	
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3540_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3540", "FG02 - PROC177 - Informar CD_BANCO_SEG válido para sinistor com: CD_TIPO_MOVIMENTO=7; TP_SINISTRO=04 D_FORMA_PGTO=D	");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.SINISTRO-EV-3300-20200324.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "146");
            AlterarLinha(0, "CD_BANCO_SEG", dados.ObterCDBancoSeg(true));
            AlterarLinha(0, "TP_SINISTRO", "04");
            AlterarLinha(0, "CD_FORMA_PAGTO", "D");

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
        ///Informar CD_BANCO_SEG válido para sinistor com: CD_TIPO_MOVIMENTO=7; TP_SINISTRO=01 D_FORMA_PGTO=D	
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3541_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3541", "FG02 - PROC177 - Informar CD_BANCO_SEG válido para sinistor com: CD_TIPO_MOVIMENTO=7; TP_SINISTRO=01 D_FORMA_PGTO=D	");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.SINISTRO-EV-3302-20200324.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "7");
            AlterarLinha(0, "CD_BANCO_SEG", dados.ObterCDBancoSeg(true));
            AlterarLinha(0, "TP_SINISTRO", "01");
            AlterarLinha(0, "CD_FORMA_PAGTO", "D");

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
        ///Informar CD_BANCO_SEG válido para sinistor com: CD_TIPO_MOVIMENTO=7; TP_SINISTRO=02 D_FORMA_PGTO=D	
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3542_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3542", "FG02 - PROC177 - Informar CD_BANCO_SEG válido para sinistor com: CD_TIPO_MOVIMENTO=7; TP_SINISTRO=02 D_FORMA_PGTO=D	");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.SINISTRO-EV-3318-20200325.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "7");
            AlterarLinha(0, "CD_BANCO_SEG", dados.ObterCDBancoSeg(true));
            AlterarLinha(0, "TP_SINISTRO", "02");
            AlterarLinha(0, "CD_FORMA_PAGTO", "D");

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

        /// <summary>
        ///Informar CD_BANCO_SEG válido para sinistor com: CD_TIPO_MOVIMENTO=7; TP_SINISTRO=03 D_FORMA_PGTO=D	
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3543_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3543", "FG02 - PROC177 - Informar CD_BANCO_SEG válido para sinistor com: CD_TIPO_MOVIMENTO=7; TP_SINISTRO=03 D_FORMA_PGTO=D	");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.SINISTRO-EV-3330-20200326.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "7");
            AlterarLinha(0, "CD_BANCO_SEG", dados.ObterCDBancoSeg(true));
            AlterarLinha(0, "TP_SINISTRO", "03");
            AlterarLinha(0, "CD_FORMA_PAGTO", "D");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SOFTBOX.SINISTRO-EV-/*R*/-20200326.txt");

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
        ///Informar CD_BANCO_SEG válido para sinistor com: CD_TIPO_MOVIMENTO=7; TP_SINISTRO=04 D_FORMA_PGTO=D	
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3544_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3544", "FG02 - PROC177 - Informar CD_BANCO_SEG válido para sinistor com: CD_TIPO_MOVIMENTO=7; TP_SINISTRO=04 D_FORMA_PGTO=D	");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.SINISTRO-EV-3333-20200326.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "7");
            AlterarLinha(0, "CD_BANCO_SEG", dados.ObterCDBancoSeg(true));
            AlterarLinha(0, "TP_SINISTRO", "04");
            AlterarLinha(0, "CD_FORMA_PAGTO", "D");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SOFTBOX.SINISTRO-EV-/*R*/-20200326.txt");

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
