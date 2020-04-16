using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC178_Layout94_Softbox : TestesFG02
    {

        /// <summary>
        /// Informar CD_BANCO inválido para sinistor com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=01 D_FORMA_PGTO=D	
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3595_CD_BANCO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3595", "FG02 - PROC178 - Informar CD_BANCO inválido para sinistor com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=01 D_FORMA_PGTO=D");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.SINISTRO-EV-3191-20200317.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "146");
            AlterarLinha(0, "CD_BANCO", dados.ObterCDBancoSeg(false));
            AlterarLinha(0, "TP_SINISTRO", "01");
            AlterarLinha(0, "CD_FORMA_PGTO", "D");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SOFTBOX.SINISTRO-EV-/*R*/-20200317.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "178");
            ValidarTeste();
        }

        /// <summary>
        /// Informar CD_BANCO inválido para sinistor com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=02 D_FORMA_PGTO=D	
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3596_CD_BANCO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3596", "FG02 - PROC178 - Informar CD_BANCO inválido para sinistor com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=02 D_FORMA_PGTO=D");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.SINISTRO-EV-3217-20200319.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "146");
            AlterarLinha(0, "CD_BANCO", dados.ObterCDBancoSeg(false));
            AlterarLinha(0, "TP_SINISTRO", "02");
            AlterarLinha(0, "CD_FORMA_PGTO", "D");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SOFTBOX.SINISTRO-EV-/*R*/-20200319.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "178");
            ValidarTeste();
        }

        /// <summary>
        /// Informar CD_BANCO inválido para sinistor com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=03 D_FORMA_PGTO=D	
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3597_CD_BANCO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3597", "FG02 - PROC178 - Informar CD_BANCO inválido para sinistor com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=03 D_FORMA_PGTO=D");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.SINISTRO-EV-3220-20200319.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "146");
            AlterarLinha(0, "CD_BANCO", dados.ObterCDBancoSeg(false));
            AlterarLinha(0, "TP_SINISTRO", "03");
            AlterarLinha(0, "CD_FORMA_PGTO", "D");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SOFTBOX.SINISTRO-EV-/*R*/-20200319.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "178");
            ValidarTeste();
        }

        /// <summary>
        /// Informar CD_BANCO inválido para sinistor com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=04 D_FORMA_PGTO=D	
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3598_CD_BANCO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3598", "FG02 - PROC178 - Informar CD_BANCO inválido para sinistor com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=04 D_FORMA_PGTO=D");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.SINISTRO-EV-3222-20200319.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "146");
            AlterarLinha(0, "CD_BANCO", dados.ObterCDBancoSeg(false));
            AlterarLinha(0, "TP_SINISTRO", "04");
            AlterarLinha(0, "CD_FORMA_PGTO", "D");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SOFTBOX.SINISTRO-EV-/*R*/-20200319.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "178");
            ValidarTeste();
        }

        /// <summary>
        /// Informar CD_BANCO inválido para sinistor com: CD_TIPO_MOVIMENTO=7; TP_SINISTRO=01 D_FORMA_PGTO=D	
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3599_CD_BANCO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3599", "FG02 - PROC178 - Informar CD_BANCO inválido para sinistor com: CD_TIPO_MOVIMENTO=7; TP_SINISTRO=01 D_FORMA_PGTO=D");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.SINISTRO-EV-3231-20200320.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "7");
            AlterarLinha(0, "CD_BANCO", dados.ObterCDBancoSeg(false));
            AlterarLinha(0, "TP_SINISTRO", "01");
            AlterarLinha(0, "CD_FORMA_PGTO", "D");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SOFTBOX.SINISTRO-EV-/*R*/-20200320.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "178");
            ValidarTeste();
        }

        /// <summary>
        /// Informar CD_BANCO inválido para sinistor com: CD_TIPO_MOVIMENTO=7; TP_SINISTRO=02 D_FORMA_PGTO=D	
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3600_CD_BANCO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3600", "FG02 - PROC178 - Informar CD_BANCO inválido para sinistor com: CD_TIPO_MOVIMENTO=7; TP_SINISTRO=02 D_FORMA_PGTO=D");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.SINISTRO-EV-3232-20200320.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "7");
            AlterarLinha(0, "CD_BANCO", dados.ObterCDBancoSeg(false));
            AlterarLinha(0, "TP_SINISTRO", "02");
            AlterarLinha(0, "CD_FORMA_PGTO", "D");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SOFTBOX.SINISTRO-EV-/*R*/-20200320.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "178");
            ValidarTeste();
        }

        /// <summary>
        /// Informar CD_BANCO inválido para sinistor com: CD_TIPO_MOVIMENTO=7; TP_SINISTRO=03 D_FORMA_PGTO=D	
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3601_CD_BANCO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3601", "FG02 - PROC178 - Informar CD_BANCO inválido para sinistor com: CD_TIPO_MOVIMENTO=7; TP_SINISTRO=03 D_FORMA_PGTO=D");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.SINISTRO-EV-3238-20200320.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "7");
            AlterarLinha(0, "CD_BANCO", dados.ObterCDBancoSeg(false));
            AlterarLinha(0, "TP_SINISTRO", "03");
            AlterarLinha(0, "CD_FORMA_PGTO", "D");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SOFTBOX.SINISTRO-EV-/*R*/-20200320.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "178");
            ValidarTeste();
        }

        /// <summary>
        /// Informar CD_BANCO inválido para sinistor com: CD_TIPO_MOVIMENTO=7; TP_SINISTRO=04 D_FORMA_PGTO=D	
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3602_CD_BANCO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3602", "FG02 - PROC178 - Informar CD_BANCO inválido para sinistor com: CD_TIPO_MOVIMENTO=7; TP_SINISTRO=04 D_FORMA_PGTO=D");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.SINISTRO-EV-3248-20200321.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "7");
            AlterarLinha(0, "CD_BANCO", dados.ObterCDBancoSeg(false));
            AlterarLinha(0, "TP_SINISTRO", "04");
            AlterarLinha(0, "CD_FORMA_PGTO", "D");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SOFTBOX.SINISTRO-EV-/*R*/-20200321.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "178");
            ValidarTeste();
        }

        /// <summary>
        /// Informar CD_BANCO NULO para sinistor com: CD_TIPO_MOVIMENTO=7; TP_SINISTRO=04 D_FORMA_PGTO=D	
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3603_CD_BANCO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3603", "FG02 - PROC178 - Informar CD_BANCO inválido para sinistor com: CD_TIPO_MOVIMENTO=7; TP_SINISTRO=04 D_FORMA_PGTO=D");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.SINISTRO-EV-3248-20200321.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "7");
            AlterarLinha(0, "CD_BANCO", "");
            AlterarLinha(0, "TP_SINISTRO", "04");
            AlterarLinha(0, "CD_FORMA_PGTO", "D");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SOFTBOX.SINISTRO-EV-/*R*/-20200321.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "178");
            ValidarTeste();
        }

        /// <summary>
        ///Informar CD_BANCO válido para sinistor com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=01 D_FORMA_PGTO=D	
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3604_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3604", "FG02 - PROC178 - Informar CD_BANCO válido para sinistor com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=01 D_FORMA_PGTO=D	");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.SINISTRO-EV-3254-20200321.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "146");
            AlterarLinha(0, "CD_BANCO", dados.ObterCDBancoSeg(true));
            AlterarLinha(0, "TP_SINISTRO", "01");
            AlterarLinha(0, "CD_FORMA_PGTO", "D");

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
        ///Informar CD_BANCO válido para sinistor com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=02 D_FORMA_PGTO=D	
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3605_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3605", "FG02 - PROC178 - Informar CD_BANCO válido para sinistor com: CD_TIPO_MOVIMENTO=7; TP_SINISTRO=02 D_FORMA_PGTO=D	");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.SINISTRO-EV-3280-20200323.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "146");
            AlterarLinha(0, "CD_BANCO", dados.ObterCDBancoSeg(true));
            AlterarLinha(0, "TP_SINISTRO", "02");
            AlterarLinha(0, "CD_FORMA_PGTO", "D");

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
        ///Informar CD_BANCO válido para sinistor com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=03 D_FORMA_PGTO=D	
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3606_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3606", "FG02 - PROC178 - Informar CD_BANCO válido para sinistor com: CD_TIPO_MOVIMENTO=7; TP_SINISTRO=03 D_FORMA_PGTO=D	");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.SINISTRO-EV-3297-20200324.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "146");
            AlterarLinha(0, "CD_BANCO", dados.ObterCDBancoSeg(true));
            AlterarLinha(0, "TP_SINISTRO", "03");
            AlterarLinha(0, "CD_FORMA_PGTO", "D");

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
        ///Informar CD_BANCO válido para sinistor com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=04 D_FORMA_PGTO=D	
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3607_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3607", "FG02 - PROC178 - Informar CD_BANCO válido para sinistor com: CD_TIPO_MOVIMENTO=7; TP_SINISTRO=04 D_FORMA_PGTO=D	");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.SINISTRO-EV-3300-20200324.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "146");
            AlterarLinha(0, "CD_BANCO", dados.ObterCDBancoSeg(true));
            AlterarLinha(0, "TP_SINISTRO", "04");
            AlterarLinha(0, "CD_FORMA_PGTO", "D");

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
        ///Informar CD_BANCO válido para sinistor com: CD_TIPO_MOVIMENTO=7; TP_SINISTRO=01 D_FORMA_PGTO=D	
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3608_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3608", "FG02 - PROC178 - Informar CD_BANCO válido para sinistor com: CD_TIPO_MOVIMENTO=7; TP_SINISTRO=01 D_FORMA_PGTO=D	");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.SINISTRO-EV-3302-20200324.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "7");
            AlterarLinha(0, "CD_BANCO", dados.ObterCDBancoSeg(true));
            AlterarLinha(0, "TP_SINISTRO", "01");
            AlterarLinha(0, "CD_FORMA_PGTO", "D");

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
        ///Informar CD_BANCO válido para sinistor com: CD_TIPO_MOVIMENTO=7; TP_SINISTRO=02 D_FORMA_PGTO=D	
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3609_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3609", "FG02 - PROC178 - Informar CD_BANCO válido para sinistor com: CD_TIPO_MOVIMENTO=7; TP_SINISTRO=02 D_FORMA_PGTO=D	");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.SINISTRO-EV-3318-20200325.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "7");
            AlterarLinha(0, "CD_BANCO", dados.ObterCDBancoSeg(true));
            AlterarLinha(0, "TP_SINISTRO", "02");
            AlterarLinha(0, "CD_FORMA_PGTO", "D");

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
        ///Informar CD_BANCO válido para sinistor com: CD_TIPO_MOVIMENTO=7; TP_SINISTRO=03 D_FORMA_PGTO=D	
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3610_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3610", "FG02 - PROC178 - Informar CD_BANCO válido para sinistor com: CD_TIPO_MOVIMENTO=7; TP_SINISTRO=03 D_FORMA_PGTO=D	");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.SINISTRO-EV-3330-20200326.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "7");
            AlterarLinha(0, "CD_BANCO", dados.ObterCDBancoSeg(true));
            AlterarLinha(0, "TP_SINISTRO", "03");
            AlterarLinha(0, "CD_FORMA_PGTO", "D");

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
        ///Informar CD_BANCO válido para sinistor com: CD_TIPO_MOVIMENTO=7; TP_SINISTRO=04 D_FORMA_PGTO=D	
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3611_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3611", "FG02 - PROC178 - Informar CD_BANCO válido para sinistor com: CD_TIPO_MOVIMENTO=7; TP_SINISTRO=04 D_FORMA_PGTO=D	");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.SINISTRO-EV-3333-20200326.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "7");
            AlterarLinha(0, "CD_BANCO", dados.ObterCDBancoSeg(true));
            AlterarLinha(0, "TP_SINISTRO", "04");
            AlterarLinha(0, "CD_FORMA_PGTO", "D");

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
