using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4_2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC164_Layout942_SGS : TestesFG02
    {

        /// <summary>
        /// Não informar NR_DOCUMENTO para sinistro com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=02; CD_FORMA_PAGTO=B
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3343_NR_DOCUMENTO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3343", "FG02 - PROC164 - Não informar NR_DOCUMENTO para sinistro com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=02; CD_FORMA_PAGTO=B");
            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "146");
            AlterarLinha(0, "NR_DOCUMENTO", "");
            AlterarLinha(0, "TP_SINISTRO", "02");
            AlterarLinha(0, "CD_FORMA_PAGTO", "B");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SGS.SINISTRO-EV-/*R*/-20200211.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "164");
            ValidarTeste();
        }

        /// <summary>
        /// Não informar NR_DOCUMENTO para sinistro com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=02; CD_FORMA_PAGTO=N
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3344_NR_DOCUMENTO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3344", "FG02 - PROC164 - Não informar NR_DOCUMENTO para sinistro com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=02; CD_FORMA_PAGTO=N");
            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "146");
            AlterarLinha(0, "NR_DOCUMENTO", "");
            AlterarLinha(0, "TP_SINISTRO", "02");
            AlterarLinha(0, "CD_FORMA_PAGTO", "N");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SGS.SINISTRO-EV-/*R*/-20200212.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "164");
            ValidarTeste();
        }

        /// <summary>
        /// Não informar NR_DOCUMENTO para sinistro com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=02; CD_FORMA_PAGTO=C
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3345_NR_DOCUMENTO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3345", "FG02 - PROC164 - Não informar NR_DOCUMENTO para sinistro com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=02; CD_FORMA_PAGTO=C");
            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200213.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "146");
            AlterarLinha(0, "NR_DOCUMENTO", "");
            AlterarLinha(0, "TP_SINISTRO", "02");
            AlterarLinha(0, "CD_FORMA_PAGTO", "C");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SGS.SINISTRO-EV-/*R*/-20200213.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "164");
            ValidarTeste();
        }

        /// <summary>
        /// Não informar NR_DOCUMENTO para sinistro com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=02; CD_FORMA_PAGTO=D
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3346_NR_DOCUMENTO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3346", "FG02 - PROC164 - Não informar NR_DOCUMENTO para sinistro com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=02; CD_FORMA_PAGTO=D");
            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200209.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "146");
            AlterarLinha(0, "NR_DOCUMENTO", "");
            AlterarLinha(0, "TP_SINISTRO", "02");
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
            ValidarTabelaDeRetorno(1, "164");
            ValidarTeste();
        }

        /// <summary>
        /// Não informar NR_DOCUMENTO para sinistro com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=02; CD_FORMA_PAGTO=R
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3347_NR_DOCUMENTO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3347", "FG02 - PROC164 - Não informar NR_DOCUMENTO para sinistro com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=02; CD_FORMA_PAGTO=R");
            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "146");
            AlterarLinha(0, "NR_DOCUMENTO", "");
            AlterarLinha(0, "TP_SINISTRO", "02");
            AlterarLinha(0, "CD_FORMA_PAGTO", "R");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SGS.SINISTRO-EV-/*R*/-20200211.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "164");
            ValidarTeste();
        }

        /// <summary>
        /// Não informar NR_DOCUMENTO para sinistro com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=02; CD_FORMA_PAGTO=M
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3348_NR_DOCUMENTO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3348", "FG02 - PROC164 - Não informar NR_DOCUMENTO para sinistro com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=02; CD_FORMA_PAGTO=M");
            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "146");
            AlterarLinha(0, "NR_DOCUMENTO", "");
            AlterarLinha(0, "TP_SINISTRO", "02");
            AlterarLinha(0, "CD_FORMA_PAGTO", "M");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SGS.SINISTRO-EV-/*R*/-20200212.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "164");
            ValidarTeste();
        }

        /// <summary>
        /// Não informar NR_DOCUMENTO para sinistro com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=04; CD_FORMA_PAGTO=B
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3349_NR_DOCUMENTO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3349", "FG02 - PROC164 - Não informar NR_DOCUMENTO para sinistro com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=04; CD_FORMA_PAGTO=B");
            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200213.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "146");
            AlterarLinha(0, "NR_DOCUMENTO", "");
            AlterarLinha(0, "TP_SINISTRO", "04");
            AlterarLinha(0, "CD_FORMA_PAGTO", "B");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SGS.SINISTRO-EV-/*R*/-20200213.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "164");
            ValidarTeste();
        }

        /// <summary>
        /// Não informar NR_DOCUMENTO para sinistro com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=04; CD_FORMA_PAGTO=N
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3350_NR_DOCUMENTO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3350", "FG02 - PROC164 - Não informar NR_DOCUMENTO para sinistro com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=04; CD_FORMA_PAGTO=N");
            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200209.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "146");
            AlterarLinha(0, "NR_DOCUMENTO", "");
            AlterarLinha(0, "TP_SINISTRO", "04");
            AlterarLinha(0, "CD_FORMA_PAGTO", "N");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SGS.SINISTRO-EV-/*R*/-20200209.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "164");
            ValidarTeste();
        }

        /// <summary>
        /// Não informar NR_DOCUMENTO para sinistro com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=04; CD_FORMA_PAGTO=C
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3351_NR_DOCUMENTO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3351", "FG02 - PROC164 - Não informar NR_DOCUMENTO para sinistro com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=04; CD_FORMA_PAGTO=C");
            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "146");
            AlterarLinha(0, "NR_DOCUMENTO", "");
            AlterarLinha(0, "TP_SINISTRO", "04");
            AlterarLinha(0, "CD_FORMA_PAGTO", "C");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SGS.SINISTRO-EV-/*R*/-20200211.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "164");
            ValidarTeste();
        }

        /// <summary>
        /// Não informar NR_DOCUMENTO para sinistro com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=04; CD_FORMA_PAGTO=D
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3352_NR_DOCUMENTO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3352", "FG02 - PROC164 - Não informar NR_DOCUMENTO para sinistro com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=04; CD_FORMA_PAGTO=D");
            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "146");
            AlterarLinha(0, "NR_DOCUMENTO", "");
            AlterarLinha(0, "TP_SINISTRO", "04");
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
            ValidarTabelaDeRetorno(1, "164");
            ValidarTeste();
        }

        /// <summary>
        /// Não informar NR_DOCUMENTO para sinistro com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=04; CD_FORMA_PAGTO=R
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3353_NR_DOCUMENTO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3353", "FG02 - PROC164 - Não informar NR_DOCUMENTO para sinistro com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=04; CD_FORMA_PAGTO=R");
            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200213.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "146");
            AlterarLinha(0, "NR_DOCUMENTO", "");
            AlterarLinha(0, "TP_SINISTRO", "04");
            AlterarLinha(0, "CD_FORMA_PAGTO", "R");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SGS.SINISTRO-EV-/*R*/-20200213.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "164");
            ValidarTeste();
        }

        /// <summary>
        /// Não informar NR_DOCUMENTO para sinistro com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=04; CD_FORMA_PAGTO=M
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3354_NR_DOCUMENTO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3354", "FG02 - PROC164 - Não informar NR_DOCUMENTO para sinistro com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=04; CD_FORMA_PAGTO=M");
            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200209.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "146");
            AlterarLinha(0, "NR_DOCUMENTO", "");
            AlterarLinha(0, "TP_SINISTRO", "04");
            AlterarLinha(0, "CD_FORMA_PAGTO", "M");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SGS.SINISTRO-EV-/*R*/-20200209.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "164");
            ValidarTeste();
        }

        /// <summary>
        ///Informar NR_DOCUMENTO para sinistro com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=02; CD_FORMA_PAGTO=B
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3355_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3355", "FG02 - PROC164 - Informar NR_DOCUMENTO para sinistro com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=02; CD_FORMA_PAGTO=B");

            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "146");
            AlterarLinha(0, "NR_DOCUMENTO", "123456");
            AlterarLinha(0, "TP_SINISTRO", "02");
            AlterarLinha(0, "CD_FORMA_PAGTO", "B");

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
        ///Informar NR_DOCUMENTO para sinistro com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=02; CD_FORMA_PAGTO=N
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3356_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3356", "FG02 - PROC164 - Informar NR_DOCUMENTO para sinistro com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=02; CD_FORMA_PAGTO=N");

            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200213.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "146");
            AlterarLinha(0, "NR_DOCUMENTO", "123456");
            AlterarLinha(0, "TP_SINISTRO", "02");
            AlterarLinha(0, "CD_FORMA_PAGTO", "N");

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
        ///Informar NR_DOCUMENTO para sinistro com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=02; CD_FORMA_PAGTO=C
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3357_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3357", "FG02 - PROC164 - Informar NR_DOCUMENTO para sinistro com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=02; CD_FORMA_PAGTO=C");

            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200209.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "146");
            AlterarLinha(0, "NR_DOCUMENTO", "123456");
            AlterarLinha(0, "TP_SINISTRO", "02");
            AlterarLinha(0, "CD_FORMA_PAGTO", "C");

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
        ///Informar NR_DOCUMENTO para sinistro com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=02; CD_FORMA_PAGTO=D
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3358_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3358", "FG02 - PROC164 - Informar NR_DOCUMENTO para sinistro com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=02; CD_FORMA_PAGTO=D");

            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "146");
            AlterarLinha(0, "NR_DOCUMENTO", "123456");
            AlterarLinha(0, "TP_SINISTRO", "02");
            AlterarLinha(0, "CD_FORMA_PAGTO", "D");

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
        ///Informar NR_DOCUMENTO para sinistro com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=02; CD_FORMA_PAGTO=R
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3359_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3359", "FG02 - PROC164 - Informar NR_DOCUMENTO para sinistro com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=02; CD_FORMA_PAGTO=R");

            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "146");
            AlterarLinha(0, "NR_DOCUMENTO", "123456");
            AlterarLinha(0, "TP_SINISTRO", "02");
            AlterarLinha(0, "CD_FORMA_PAGTO", "R");

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
        ///Informar NR_DOCUMENTO para sinistro com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=02; CD_FORMA_PAGTO=M
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3360_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3360", "FG02 - PROC164 - Informar NR_DOCUMENTO para sinistro com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=02; CD_FORMA_PAGTO=M");

            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200213.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "146");
            AlterarLinha(0, "NR_DOCUMENTO", "123456");
            AlterarLinha(0, "TP_SINISTRO", "02");
            AlterarLinha(0, "CD_FORMA_PAGTO", "M");

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
        ///Informar NR_DOCUMENTO para sinistro com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=04; CD_FORMA_PAGTO=B
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3361_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3361", "FG02 - PROC164 - Informar NR_DOCUMENTO para sinistro com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=04; CD_FORMA_PAGTO=B");

            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200209.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "146");
            AlterarLinha(0, "NR_DOCUMENTO", "123456");
            AlterarLinha(0, "TP_SINISTRO", "04");
            AlterarLinha(0, "CD_FORMA_PAGTO", "B");

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
        ///Informar NR_DOCUMENTO para sinistro com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=04; CD_FORMA_PAGTO=N
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3362_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3362", "FG02 - PROC164 - Informar NR_DOCUMENTO para sinistro com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=04; CD_FORMA_PAGTO=N");

            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "146");
            AlterarLinha(0, "NR_DOCUMENTO", "123456");
            AlterarLinha(0, "TP_SINISTRO", "04");
            AlterarLinha(0, "CD_FORMA_PAGTO", "N");

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
        ///Informar NR_DOCUMENTO para sinistro com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=04; CD_FORMA_PAGTO=C
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3363_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3363", "FG02 - PROC164 - Informar NR_DOCUMENTO para sinistro com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=04; CD_FORMA_PAGTO=C");

            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "146");
            AlterarLinha(0, "NR_DOCUMENTO", "123456");
            AlterarLinha(0, "TP_SINISTRO", "04");
            AlterarLinha(0, "CD_FORMA_PAGTO", "C");

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
        ///Informar NR_DOCUMENTO para sinistro com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=04; CD_FORMA_PAGTO=D
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3364_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3364", "FG02 - PROC164 - Informar NR_DOCUMENTO para sinistro com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=04; CD_FORMA_PAGTO=D");

            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200213.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "146");
            AlterarLinha(0, "NR_DOCUMENTO", "123456");
            AlterarLinha(0, "TP_SINISTRO", "04");
            AlterarLinha(0, "CD_FORMA_PAGTO", "D");

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
        ///Informar NR_DOCUMENTO para sinistro com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=04; CD_FORMA_PAGTO=R
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3365_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3365", "FG02 - PROC164 - Informar NR_DOCUMENTO para sinistro com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=04; CD_FORMA_PAGTO=R");

            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200209.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "146");
            AlterarLinha(0, "NR_DOCUMENTO", "123456");
            AlterarLinha(0, "TP_SINISTRO", "04");
            AlterarLinha(0, "CD_FORMA_PAGTO", "R");

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
        ///Informar NR_DOCUMENTO para sinistro com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=04; CD_FORMA_PAGTO=M
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3366_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3366", "FG02 - PROC164 - Informar NR_DOCUMENTO para sinistro com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=04; CD_FORMA_PAGTO=M");

            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "146");
            AlterarLinha(0, "NR_DOCUMENTO", "123456");
            AlterarLinha(0, "TP_SINISTRO", "04");
            AlterarLinha(0, "CD_FORMA_PAGTO", "M");

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
        ///Não Informar NR_DOCUMENTO para sinistro com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=01; CD_FORMA_PAGTO=M
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3367_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3367", "FG02 - PROC164 - Não Informar NR_DOCUMENTO para sinistro com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=01; CD_FORMA_PAGTO=M");

            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "146");
            AlterarLinha(0, "NR_DOCUMENTO", "123456");
            AlterarLinha(0, "TP_SINISTRO", "01");
            AlterarLinha(0, "CD_FORMA_PAGTO", "M");

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
        ///Não Informar NR_DOCUMENTO para sinistro com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=03; CD_FORMA_PAGTO=M
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3368_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3368", "FG02 - PROC164 - Não Informar NR_DOCUMENTO para sinistro com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=03; CD_FORMA_PAGTO=M");

            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200213.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "146");
            AlterarLinha(0, "NR_DOCUMENTO", "123456");
            AlterarLinha(0, "TP_SINISTRO", "03");
            AlterarLinha(0, "CD_FORMA_PAGTO", "M");

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
