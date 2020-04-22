using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC177_Layout94_Pompeia : TestesFG02
    {

        /// <summary>
        /// Informar CD_BANCO_SEG inválido para sinistor com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=01 D_FORMA_PGTO=D	
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3545_CD_BANCO_SEG_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3545", "FG02 - PROC177 - Informar CD_BANCO_SEG inválido para sinistor com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=01 D_FORMA_PGTO=D");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.SINISTRO-EV-0001-20191223.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "146");
            AlterarLinha(0, "CD_BANCO_SEG", dados.ObterCDBancoSeg(false));
            AlterarLinha(0, "TP_SINISTRO", "01");
            AlterarLinha(0, "CD_FORMA_PAGTO", "D");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.POMPEIA.SINISTRO-EV-/*R*/-20191223.txt");

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
        public void SAP_3546_CD_BANCO_SEG_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3546", "FG02 - PROC177 - Informar CD_BANCO_SEG inválido para sinistor com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=02 D_FORMA_PGTO=D");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.SINISTRO-EV-0001-20200117.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "146");
            AlterarLinha(0, "CD_BANCO_SEG", dados.ObterCDBancoSeg(false));
            AlterarLinha(0, "TP_SINISTRO", "02");
            AlterarLinha(0, "CD_FORMA_PAGTO", "D");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.POMPEIA.SINISTRO-EV-/*R*/-20200117.txt");

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
        public void SAP_3547_CD_BANCO_SEG_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3547", "FG02 - PROC177 - Informar CD_BANCO_SEG inválido para sinistor com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=03 D_FORMA_PGTO=D");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.SINISTRO-EV-0001-20200127.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "146");
            AlterarLinha(0, "CD_BANCO_SEG", dados.ObterCDBancoSeg(false));
            AlterarLinha(0, "TP_SINISTRO", "03");
            AlterarLinha(0, "CD_FORMA_PAGTO", "D");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.POMPEIA.SINISTRO-EV-/*R*/-20200127.txt");

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
        public void SAP_3548_CD_BANCO_SEG_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3548", "FG02 - PROC177 - Informar CD_BANCO_SEG inválido para sinistor com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=04 D_FORMA_PGTO=D");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.SINISTRO-EV-0001-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "146");
            AlterarLinha(0, "CD_BANCO_SEG", dados.ObterCDBancoSeg(false));
            AlterarLinha(0, "TP_SINISTRO", "04");
            AlterarLinha(0, "CD_FORMA_PAGTO", "D");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.POMPEIA.SINISTRO-EV-/*R*/-20200211.txt");

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
        public void SAP_3549_CD_BANCO_SEG_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3549", "FG02 - PROC177 - Informar CD_BANCO_SEG inválido para sinistor com: CD_TIPO_MOVIMENTO=7; TP_SINISTRO=01 D_FORMA_PGTO=D");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.SINISTRO-EV-0002-20191220.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "7");
            AlterarLinha(0, "CD_BANCO_SEG", dados.ObterCDBancoSeg(false));
            AlterarLinha(0, "TP_SINISTRO", "01");
            AlterarLinha(0, "CD_FORMA_PAGTO", "D");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.POMPEIA.SINISTRO-EV-/*R*/-20191220.txt");

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
        public void SAP_3550_CD_BANCO_SEG_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3550", "FG02 - PROC177 - Informar CD_BANCO_SEG inválido para sinistor com: CD_TIPO_MOVIMENTO=7; TP_SINISTRO=02 D_FORMA_PGTO=D");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.SINISTRO-EV-0001-20191223.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "7");
            AlterarLinha(0, "CD_BANCO_SEG", dados.ObterCDBancoSeg(false));
            AlterarLinha(0, "TP_SINISTRO", "02");
            AlterarLinha(0, "CD_FORMA_PAGTO", "D");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.POMPEIA.SINISTRO-EV-/*R*/-20191223.txt");

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
        public void SAP_3551_CD_BANCO_SEG_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3551", "FG02 - PROC177 - Informar CD_BANCO_SEG inválido para sinistor com: CD_TIPO_MOVIMENTO=7; TP_SINISTRO=03 D_FORMA_PGTO=D");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.SINISTRO-EV-0001-20200117.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "7");
            AlterarLinha(0, "CD_BANCO_SEG", dados.ObterCDBancoSeg(false));
            AlterarLinha(0, "TP_SINISTRO", "03");
            AlterarLinha(0, "CD_FORMA_PAGTO", "D");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.POMPEIA.SINISTRO-EV-/*R*/-20200117.txt");

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
        public void SAP_3552_CD_BANCO_SEG_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3552", "FG02 - PROC177 - Informar CD_BANCO_SEG inválido para sinistor com: CD_TIPO_MOVIMENTO=7; TP_SINISTRO=04 D_FORMA_PGTO=D");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.SINISTRO-EV-0001-20200127.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "7");
            AlterarLinha(0, "CD_BANCO_SEG", dados.ObterCDBancoSeg(false));
            AlterarLinha(0, "TP_SINISTRO", "04");
            AlterarLinha(0, "CD_FORMA_PAGTO", "D");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.POMPEIA.SINISTRO-EV-/*R*/-20200127.txt");

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
        public void SAP_3553_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3553", "FG02 - PROC177 - Informar CD_BANCO_SEG válido para sinistor com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=01 D_FORMA_PGTO=D	");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.SINISTRO-EV-0001-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "146");
            AlterarLinha(0, "CD_BANCO_SEG", dados.ObterCDBancoSeg(true));
            AlterarLinha(0, "TP_SINISTRO", "01");
            AlterarLinha(0, "CD_FORMA_PAGTO", "D");

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
        ///Informar CD_BANCO_SEG válido para sinistor com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=02 D_FORMA_PGTO=D	
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3554_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3554", "FG02 - PROC177 - Informar CD_BANCO_SEG válido para sinistor com: CD_TIPO_MOVIMENTO=7; TP_SINISTRO=02 D_FORMA_PGTO=D	");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.SINISTRO-EV-0002-20191220.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "146");
            AlterarLinha(0, "CD_BANCO_SEG", dados.ObterCDBancoSeg(true));
            AlterarLinha(0, "TP_SINISTRO", "02");
            AlterarLinha(0, "CD_FORMA_PAGTO", "D");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.POMPEIA.SINISTRO-EV-/*R*/-20191220.txt");

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
        public void SAP_3555_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3555", "FG02 - PROC177 - Informar CD_BANCO_SEG válido para sinistor com: CD_TIPO_MOVIMENTO=7; TP_SINISTRO=03 D_FORMA_PGTO=D	");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.SINISTRO-EV-0001-20191223.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "146");
            AlterarLinha(0, "CD_BANCO_SEG", dados.ObterCDBancoSeg(true));
            AlterarLinha(0, "TP_SINISTRO", "03");
            AlterarLinha(0, "CD_FORMA_PAGTO", "D");

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
        ///Informar CD_BANCO_SEG válido para sinistor com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=04 D_FORMA_PGTO=D	
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3556_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3556", "FG02 - PROC177 - Informar CD_BANCO_SEG válido para sinistor com: CD_TIPO_MOVIMENTO=7; TP_SINISTRO=04 D_FORMA_PGTO=D	");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.SINISTRO-EV-0001-20200117.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "146");
            AlterarLinha(0, "CD_BANCO_SEG", dados.ObterCDBancoSeg(true));
            AlterarLinha(0, "TP_SINISTRO", "04");
            AlterarLinha(0, "CD_FORMA_PAGTO", "D");

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
        ///Informar CD_BANCO_SEG válido para sinistor com: CD_TIPO_MOVIMENTO=7; TP_SINISTRO=01 D_FORMA_PGTO=D	
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3557_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3557", "FG02 - PROC177 - Informar CD_BANCO_SEG válido para sinistor com: CD_TIPO_MOVIMENTO=7; TP_SINISTRO=01 D_FORMA_PGTO=D	");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.SINISTRO-EV-0001-20200127.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "7");
            AlterarLinha(0, "CD_BANCO_SEG", dados.ObterCDBancoSeg(true));
            AlterarLinha(0, "TP_SINISTRO", "01");
            AlterarLinha(0, "CD_FORMA_PAGTO", "D");

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
        ///Informar CD_BANCO_SEG válido para sinistor com: CD_TIPO_MOVIMENTO=7; TP_SINISTRO=02 D_FORMA_PGTO=D	
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3558_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3558", "FG02 - PROC177 - Informar CD_BANCO_SEG válido para sinistor com: CD_TIPO_MOVIMENTO=7; TP_SINISTRO=02 D_FORMA_PGTO=D	");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.SINISTRO-EV-0001-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "7");
            AlterarLinha(0, "CD_BANCO_SEG", dados.ObterCDBancoSeg(true));
            AlterarLinha(0, "TP_SINISTRO", "02");
            AlterarLinha(0, "CD_FORMA_PAGTO", "D");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("PROC177");

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
        public void SAP_3559_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3559", "FG02 - PROC177 - Informar CD_BANCO_SEG válido para sinistor com: CD_TIPO_MOVIMENTO=7; TP_SINISTRO=03 D_FORMA_PGTO=D	");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.SINISTRO-EV-0002-20191220.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "7");
            AlterarLinha(0, "CD_BANCO_SEG", dados.ObterCDBancoSeg(true));
            AlterarLinha(0, "TP_SINISTRO", "03");
            AlterarLinha(0, "CD_FORMA_PAGTO", "D");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.POMPEIA.SINISTRO-EV-/*R*/-20191220.txt");

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
        public void SAP_3560_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3560", "FG02 - PROC177 - Informar CD_BANCO_SEG válido para sinistor com: CD_TIPO_MOVIMENTO=7; TP_SINISTRO=04 D_FORMA_PGTO=D	");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.SINISTRO-EV-0001-20191223.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "7");
            AlterarLinha(0, "CD_BANCO_SEG", dados.ObterCDBancoSeg(true));
            AlterarLinha(0, "TP_SINISTRO", "04");
            AlterarLinha(0, "CD_FORMA_PAGTO", "D");

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
    }
}
