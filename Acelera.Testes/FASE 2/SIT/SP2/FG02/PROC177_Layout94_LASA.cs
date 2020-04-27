using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC177_Layout94_LASA : TestesFG02
    {

        /// <summary>
        /// Informar CD_BANCO_SEG inválido para sinistor com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=01 D_FORMA_PGTO=D	
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3513_CD_BANCO_SEG_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3513", "FG02 - PROC177 - Informar CD_BANCO_SEG inválido para sinistor com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=01 D_FORMA_PGTO=D");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.SINISTRO-EV-2757-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "146");
            AlterarLinha(0, "CD_BANCO_SEG", dados.ObterCDBancoSeg(false));
            AlterarLinha(0, "TP_SINISTRO", "01");
            AlterarLinha(0, "CD_FORMA_PAGTO", "D");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.SINISTRO-EV-/*R*/-20200211.txt");

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
        public void SAP_3514_CD_BANCO_SEG_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3514", "FG02 - PROC177 - Informar CD_BANCO_SEG inválido para sinistor com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=02 D_FORMA_PGTO=D");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.SINISTRO-EV-2758-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "146");
            AlterarLinha(0, "CD_BANCO_SEG", dados.ObterCDBancoSeg(false));
            AlterarLinha(0, "TP_SINISTRO", "02");
            AlterarLinha(0, "CD_FORMA_PAGTO", "D");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.SINISTRO-EV-/*R*/-20200211.txt");

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
        public void SAP_3515_CD_BANCO_SEG_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3515", "FG02 - PROC177 - Informar CD_BANCO_SEG inválido para sinistor com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=03 D_FORMA_PGTO=D");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.SINISTRO-EV-3287-20200323.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "146");
            AlterarLinha(0, "CD_BANCO_SEG", dados.ObterCDBancoSeg(false));
            AlterarLinha(0, "TP_SINISTRO", "03");
            AlterarLinha(0, "CD_FORMA_PAGTO", "D");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.SINISTRO-EV-/*R*/-20200323.txt");

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
        public void SAP_3516_CD_BANCO_SEG_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3516", "FG02 - PROC177 - Informar CD_BANCO_SEG inválido para sinistor com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=04 D_FORMA_PGTO=D");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.SINISTRO-EV-3296-20200324.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "146");
            AlterarLinha(0, "CD_BANCO_SEG", dados.ObterCDBancoSeg(false));
            AlterarLinha(0, "TP_SINISTRO", "04");
            AlterarLinha(0, "CD_FORMA_PAGTO", "D");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.SINISTRO-EV-/*R*/-20200324.txt");

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
        public void SAP_3517_CD_BANCO_SEG_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3517", "FG02 - PROC177 - Informar CD_BANCO_SEG inválido para sinistor com: CD_TIPO_MOVIMENTO=7; TP_SINISTRO=01 D_FORMA_PGTO=D");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.SINISTRO-EV-3298-20200324.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "7");
            AlterarLinha(0, "CD_BANCO_SEG", dados.ObterCDBancoSeg(false));
            AlterarLinha(0, "TP_SINISTRO", "01");
            AlterarLinha(0, "CD_FORMA_PAGTO", "D");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.SINISTRO-EV-/*R*/-20200324.txt");

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
        public void SAP_3518_CD_BANCO_SEG_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3518", "FG02 - PROC177 - Informar CD_BANCO_SEG inválido para sinistor com: CD_TIPO_MOVIMENTO=7; TP_SINISTRO=02 D_FORMA_PGTO=D");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.SINISTRO-EV-3301-20200324.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "7");
            AlterarLinha(0, "CD_BANCO_SEG", dados.ObterCDBancoSeg(false));
            AlterarLinha(0, "TP_SINISTRO", "02");
            AlterarLinha(0, "CD_FORMA_PAGTO", "D");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.SINISTRO-EV-/*R*/-20200324.txt");

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
        public void SAP_3519_CD_BANCO_SEG_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3519", "FG02 - PROC177 - Informar CD_BANCO_SEG inválido para sinistor com: CD_TIPO_MOVIMENTO=7; TP_SINISTRO=03 D_FORMA_PGTO=D");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.SINISTRO-EV-3303-20200324.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "7");
            AlterarLinha(0, "CD_BANCO_SEG", dados.ObterCDBancoSeg(false));
            AlterarLinha(0, "TP_SINISTRO", "03");
            AlterarLinha(0, "CD_FORMA_PAGTO", "D");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.SINISTRO-EV-/*R*/-20200324.txt");

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
        public void SAP_3520_CD_BANCO_SEG_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3520", "FG02 - PROC177 - Informar CD_BANCO_SEG inválido para sinistor com: CD_TIPO_MOVIMENTO=7; TP_SINISTRO=04 D_FORMA_PGTO=D");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.SINISTRO-EV-3312-20200325.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "7");
            AlterarLinha(0, "CD_BANCO_SEG", dados.ObterCDBancoSeg(false));
            AlterarLinha(0, "TP_SINISTRO", "04");
            AlterarLinha(0, "CD_FORMA_PAGTO", "D");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.SINISTRO-EV-/*R*/-20200325.txt");

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
        public void SAP_3521_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3521", "FG02 - PROC177 - Informar CD_BANCO_SEG válido para sinistor com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=01 D_FORMA_PGTO=D	");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.SINISTRO-EV-3314-20200325.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "146");
            AlterarLinha(0, "CD_BANCO_SEG", dados.ObterCDBancoSeg(true));
            AlterarLinha(0, "TP_SINISTRO", "01");
            AlterarLinha(0, "CD_FORMA_PAGTO", "D");

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
        ///Informar CD_BANCO_SEG válido para sinistor com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=02 D_FORMA_PGTO=D	
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3522_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3522", "FG02 - PROC177 - Informar CD_BANCO_SEG válido para sinistor com: CD_TIPO_MOVIMENTO=7; TP_SINISTRO=02 D_FORMA_PGTO=D	");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.SINISTRO-EV-3317-20200325.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "146");
            AlterarLinha(0, "CD_BANCO_SEG", dados.ObterCDBancoSeg(true));
            AlterarLinha(0, "TP_SINISTRO", "02");
            AlterarLinha(0, "CD_FORMA_PAGTO", "D");

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
        ///Informar CD_BANCO_SEG válido para sinistor com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=03 D_FORMA_PGTO=D	
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3523_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3523", "FG02 - PROC177 - Informar CD_BANCO_SEG válido para sinistor com: CD_TIPO_MOVIMENTO=7; TP_SINISTRO=03 D_FORMA_PGTO=D	");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.SINISTRO-EV-3319-20200325.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "146");
            AlterarLinha(0, "CD_BANCO_SEG", dados.ObterCDBancoSeg(true));
            AlterarLinha(0, "TP_SINISTRO", "03");
            AlterarLinha(0, "CD_FORMA_PAGTO", "D");

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
        ///Informar CD_BANCO_SEG válido para sinistor com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=04 D_FORMA_PGTO=D	
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3524_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3524", "FG02 - PROC177 - Informar CD_BANCO_SEG válido para sinistor com: CD_TIPO_MOVIMENTO=7; TP_SINISTRO=04 D_FORMA_PGTO=D	");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.SINISTRO-EV-3329-20200326.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "146");
            AlterarLinha(0, "CD_BANCO_SEG", dados.ObterCDBancoSeg(true));
            AlterarLinha(0, "TP_SINISTRO", "04");
            AlterarLinha(0, "CD_FORMA_PAGTO", "D");

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
        ///Informar CD_BANCO_SEG válido para sinistor com: CD_TIPO_MOVIMENTO=7; TP_SINISTRO=01 D_FORMA_PGTO=D	
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3525_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3525", "FG02 - PROC177 - Informar CD_BANCO_SEG válido para sinistor com: CD_TIPO_MOVIMENTO=7; TP_SINISTRO=01 D_FORMA_PGTO=D	");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.SINISTRO-EV-3331-20200326.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "7");
            AlterarLinha(0, "CD_BANCO_SEG", dados.ObterCDBancoSeg(true));
            AlterarLinha(0, "TP_SINISTRO", "01");
            AlterarLinha(0, "CD_FORMA_PAGTO", "D");

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
        ///Informar CD_BANCO_SEG válido para sinistor com: CD_TIPO_MOVIMENTO=7; TP_SINISTRO=02 D_FORMA_PGTO=D	
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3526_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3526", "FG02 - PROC177 - Informar CD_BANCO_SEG válido para sinistor com: CD_TIPO_MOVIMENTO=7; TP_SINISTRO=02 D_FORMA_PGTO=D	");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.SINISTRO-EV-3334-20200326.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "7");
            AlterarLinha(0, "CD_BANCO_SEG", dados.ObterCDBancoSeg(true));
            AlterarLinha(0, "TP_SINISTRO", "02");
            AlterarLinha(0, "CD_FORMA_PAGTO", "D");

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
        ///Informar CD_BANCO_SEG válido para sinistor com: CD_TIPO_MOVIMENTO=7; TP_SINISTRO=03 D_FORMA_PGTO=D	
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3527_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3527", "FG02 - PROC177 - Informar CD_BANCO_SEG válido para sinistor com: CD_TIPO_MOVIMENTO=7; TP_SINISTRO=03 D_FORMA_PGTO=D	");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.SINISTRO-EV-3336-20200326.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "7");
            AlterarLinha(0, "CD_BANCO_SEG", dados.ObterCDBancoSeg(true));
            AlterarLinha(0, "TP_SINISTRO", "03");
            AlterarLinha(0, "CD_FORMA_PAGTO", "D");

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
        ///Informar CD_BANCO_SEG válido para sinistor com: CD_TIPO_MOVIMENTO=7; TP_SINISTRO=04 D_FORMA_PGTO=D	
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3528_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3528", "FG02 - PROC177 - Informar CD_BANCO_SEG válido para sinistor com: CD_TIPO_MOVIMENTO=7; TP_SINISTRO=04 D_FORMA_PGTO=D	");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.SINISTRO-EV-3317-20200325.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "7");
            AlterarLinha(0, "CD_BANCO_SEG", dados.ObterCDBancoSeg(true));
            AlterarLinha(0, "TP_SINISTRO", "04");
            AlterarLinha(0, "CD_FORMA_PAGTO", "D");

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
    }
}
