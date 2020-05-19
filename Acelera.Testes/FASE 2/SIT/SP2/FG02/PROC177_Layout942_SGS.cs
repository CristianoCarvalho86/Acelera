using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4_2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC177_Layout942_SGS : TestesFG02
    {

        /// <summary>
        /// Informar CD_BANCO_SEG inválido para sinistor com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=01 D_FORMA_PGTO=D	
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3497_CD_BANCO_SEG_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3497", "FG02 - PROC177 - Informar CD_BANCO_SEG inválido para sinistor com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=01 D_FORMA_PGTO=D");
            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "146");
            AlterarLinha(0, "CD_BANCO_SEG", dados.ObterCDBancoSeg(false));
            AlterarLinha(0, "TP_SINISTRO", "01");
            AlterarLinha(0, "CD_FORMA_PAGTO", "D");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SGS.SINISTRO-EV-/*R*/-20200211.txt");

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
        public void SAP_3498_CD_BANCO_SEG_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3498", "FG02 - PROC177 - Informar CD_BANCO_SEG inválido para sinistor com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=02 D_FORMA_PGTO=D");
            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "146");
            AlterarLinha(0, "CD_BANCO_SEG", dados.ObterCDBancoSeg(false));
            AlterarLinha(0, "TP_SINISTRO", "02");
            AlterarLinha(0, "CD_FORMA_PAGTO", "D");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SGS.SINISTRO-EV-/*R*/-20200212.txt");

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
        public void SAP_3499_CD_BANCO_SEG_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3499", "FG02 - PROC177 - Informar CD_BANCO_SEG inválido para sinistor com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=03 D_FORMA_PGTO=D");
            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200213.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "146");
            AlterarLinha(0, "CD_BANCO_SEG", dados.ObterCDBancoSeg(false));
            AlterarLinha(0, "TP_SINISTRO", "03");
            AlterarLinha(0, "CD_FORMA_PAGTO", "D");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SGS.SINISTRO-EV-/*R*/-20200213.txt");

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
        public void SAP_3500_CD_BANCO_SEG_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3500", "FG02 - PROC177 - Informar CD_BANCO_SEG inválido para sinistor com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=04 D_FORMA_PGTO=D");
            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200209.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "146");
            AlterarLinha(0, "CD_BANCO_SEG", dados.ObterCDBancoSeg(false));
            AlterarLinha(0, "TP_SINISTRO", "04");
            AlterarLinha(0, "CD_FORMA_PAGTO", "D");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SGS.SINISTRO-EV-/*R*/-20200209.txt");

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
        public void SAP_3501_CD_BANCO_SEG_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3501", "FG02 - PROC177 - Informar CD_BANCO_SEG inválido para sinistor com: CD_TIPO_MOVIMENTO=7; TP_SINISTRO=01 D_FORMA_PGTO=D");
            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "7");
            AlterarLinha(0, "CD_BANCO_SEG", dados.ObterCDBancoSeg(false));
            AlterarLinha(0, "TP_SINISTRO", "01");
            AlterarLinha(0, "CD_FORMA_PAGTO", "D");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SGS.SINISTRO-EV-/*R*/-20200211.txt");

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
        public void SAP_3502_CD_BANCO_SEG_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3502", "FG02 - PROC177 - Informar CD_BANCO_SEG inválido para sinistor com: CD_TIPO_MOVIMENTO=7; TP_SINISTRO=02 D_FORMA_PGTO=D");
            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "7");
            AlterarLinha(0, "CD_BANCO_SEG", dados.ObterCDBancoSeg(false));
            AlterarLinha(0, "TP_SINISTRO", "02");
            AlterarLinha(0, "CD_FORMA_PAGTO", "D");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SGS.SINISTRO-EV-/*R*/-20200212.txt");

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
        public void SAP_3503_CD_BANCO_SEG_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3503", "FG02 - PROC177 - Informar CD_BANCO_SEG inválido para sinistor com: CD_TIPO_MOVIMENTO=7; TP_SINISTRO=03 D_FORMA_PGTO=D");
            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200213.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "7");
            AlterarLinha(0, "CD_BANCO_SEG", dados.ObterCDBancoSeg(false));
            AlterarLinha(0, "TP_SINISTRO", "03");
            AlterarLinha(0, "CD_FORMA_PAGTO", "D");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SGS.SINISTRO-EV-/*R*/-20200213.txt");

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
        public void SAP_3504_CD_BANCO_SEG_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3504", "FG02 - PROC177 - Informar CD_BANCO_SEG inválido para sinistor com: CD_TIPO_MOVIMENTO=7; TP_SINISTRO=04 D_FORMA_PGTO=D");
            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200209.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "7");
            AlterarLinha(0, "CD_BANCO_SEG", dados.ObterCDBancoSeg(false));
            AlterarLinha(0, "TP_SINISTRO", "04");
            AlterarLinha(0, "CD_FORMA_PAGTO", "D");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SGS.SINISTRO-EV-/*R*/-20200209.txt");

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
        public void SAP_3505_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3505", "FG02 - PROC177 - Informar CD_BANCO_SEG válido para sinistor com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=01 D_FORMA_PGTO=D	");

            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "146");
            AlterarLinha(0, "CD_BANCO_SEG", dados.ObterCDBancoSeg(true));
            AlterarLinha(0, "TP_SINISTRO", "01");
            AlterarLinha(0, "CD_FORMA_PAGTO", "D");
            RemoverLinhasExcetoAsPrimeiras(1);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SGS.SINISTRO-EV-/*R*/-20200211.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(true, "177");
            ValidarStagesSemGerarErro(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTeste();
        }

        /// <summary>
        ///Informar CD_BANCO_SEG válido para sinistor com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=02 D_FORMA_PGTO=D	
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3506_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3506", "FG02 - PROC177 - Informar CD_BANCO_SEG válido para sinistor com: CD_TIPO_MOVIMENTO=7; TP_SINISTRO=02 D_FORMA_PGTO=D	");

            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "146");
            AlterarLinha(0, "CD_BANCO_SEG", dados.ObterCDBancoSeg(true));
            AlterarLinha(0, "TP_SINISTRO", "02");
            AlterarLinha(0, "CD_FORMA_PAGTO", "D");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SGS.SINISTRO-EV-/*R*/-20200212.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(true, "177");
            ValidarStagesSemGerarErro(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTeste();
        }

        /// <summary>
        ///Informar CD_BANCO_SEG válido para sinistor com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=03 D_FORMA_PGTO=D	
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3507_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3507", "FG02 - PROC177 - Informar CD_BANCO_SEG válido para sinistor com: CD_TIPO_MOVIMENTO=7; TP_SINISTRO=03 D_FORMA_PGTO=D	");

            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200213.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "146");
            AlterarLinha(0, "CD_BANCO_SEG", dados.ObterCDBancoSeg(true));
            AlterarLinha(0, "TP_SINISTRO", "03");
            AlterarLinha(0, "CD_FORMA_PAGTO", "D");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SGS.SINISTRO-EV-/*R*/-20200213.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(true, "177");
            ValidarStagesSemGerarErro(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTeste();
        }

        /// <summary>
        ///Informar CD_BANCO_SEG válido para sinistor com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=04 D_FORMA_PGTO=D	
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3508_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3508", "FG02 - PROC177 - Informar CD_BANCO_SEG válido para sinistor com: CD_TIPO_MOVIMENTO=7; TP_SINISTRO=04 D_FORMA_PGTO=D	");

            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200209.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "146");
            AlterarLinha(0, "CD_BANCO_SEG", dados.ObterCDBancoSeg(true));
            AlterarLinha(0, "TP_SINISTRO", "04");
            AlterarLinha(0, "CD_FORMA_PAGTO", "D");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SGS.SINISTRO-EV-/*R*/-20200209.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(true, "177");
            ValidarStagesSemGerarErro(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTeste();
        }

        /// <summary>
        ///Informar CD_BANCO_SEG válido para sinistor com: CD_TIPO_MOVIMENTO=7; TP_SINISTRO=01 D_FORMA_PGTO=D	
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3509_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3509", "FG02 - PROC177 - Informar CD_BANCO_SEG válido para sinistor com: CD_TIPO_MOVIMENTO=7; TP_SINISTRO=01 D_FORMA_PGTO=D	");

            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "7");
            AlterarLinha(0, "CD_BANCO_SEG", dados.ObterCDBancoSeg(true));
            AlterarLinha(0, "TP_SINISTRO", "01");
            AlterarLinha(0, "CD_FORMA_PAGTO", "D");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SGS.SINISTRO-EV-/*R*/-20200211.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(true, "177");
            ValidarStagesSemGerarErro(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTeste();
        }

        /// <summary>
        ///Informar CD_BANCO_SEG válido para sinistor com: CD_TIPO_MOVIMENTO=7; TP_SINISTRO=02 D_FORMA_PGTO=D	
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3510_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3510", "FG02 - PROC177 - Informar CD_BANCO_SEG válido para sinistor com: CD_TIPO_MOVIMENTO=7; TP_SINISTRO=02 D_FORMA_PGTO=D	");

            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "7");
            AlterarLinha(0, "CD_BANCO_SEG", dados.ObterCDBancoSeg(true));
            AlterarLinha(0, "TP_SINISTRO", "02");
            AlterarLinha(0, "CD_FORMA_PAGTO", "D");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SGS.SINISTRO-EV-/*R*/-20200212.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(true, "177");
            ValidarStagesSemGerarErro(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTeste();
        }

        /// <summary>
        ///Informar CD_BANCO_SEG válido para sinistor com: CD_TIPO_MOVIMENTO=7; TP_SINISTRO=03 D_FORMA_PGTO=D	
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3511_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3511", "FG02 - PROC177 - Informar CD_BANCO_SEG válido para sinistor com: CD_TIPO_MOVIMENTO=7; TP_SINISTRO=03 D_FORMA_PGTO=D	");

            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200213.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "7");
            AlterarLinha(0, "CD_BANCO_SEG", dados.ObterCDBancoSeg(true));
            AlterarLinha(0, "TP_SINISTRO", "03");
            AlterarLinha(0, "CD_FORMA_PAGTO", "D");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SGS.SINISTRO-EV-/*R*/-20200213.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(true, "177");
            ValidarStagesSemGerarErro(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTeste();
        }

        /// <summary>
        ///Informar CD_BANCO_SEG válido para sinistor com: CD_TIPO_MOVIMENTO=7; TP_SINISTRO=04 D_FORMA_PGTO=D	
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3512_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3512", "FG02 - PROC177 - Informar CD_BANCO_SEG válido para sinistor com: CD_TIPO_MOVIMENTO=7; TP_SINISTRO=04 D_FORMA_PGTO=D	");

            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200209.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "7");
            AlterarLinha(0, "CD_BANCO_SEG", dados.ObterCDBancoSeg(true));
            AlterarLinha(0, "TP_SINISTRO", "04");
            AlterarLinha(0, "CD_FORMA_PAGTO", "D");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SGS.SINISTRO-EV-/*R*/-20200209.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(true, "177");
            ValidarStagesSemGerarErro(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTeste();
        }
    }
}
