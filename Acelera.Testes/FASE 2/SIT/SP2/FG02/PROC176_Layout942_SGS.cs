using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4_2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC176_Layout942_SGS : TestesFG02
    {

        /// <summary>
        /// Não informar NR_DOCUMENTO para sinistro com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=01 D_FORMA_PGTO=C	
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3465_NR_DOCUMENTO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3465", "FG02 - PROC176 - Não informar NR_DOCUMENTO para sinistro com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=01 D_FORMA_PGTO=C	");
            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "146");
            AlterarLinha(0, "NR_DOCUMENTO", "");
            AlterarLinha(0, "TP_SINISTRO", "01");
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
            ValidarTabelaDeRetorno(1, "176");
            ValidarTeste();
        }

        /// <summary>
        /// Não informar NR_DOCUMENTO para sinistro com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=02; CD_FORMA_PAGTO=C
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3466_NR_DOCUMENTO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3466", "FG02 - PROC176 - Não informar NR_DOCUMENTO para sinistro com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=02; CD_FORMA_PAGTO=C");
            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "146");
            AlterarLinha(0, "NR_DOCUMENTO", "");
            AlterarLinha(0, "TP_SINISTRO", "02");
            AlterarLinha(0, "CD_FORMA_PAGTO", "C");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SGS.SINISTRO-EV-/*R*/-20200212.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "176");
            ValidarTeste();
        }

        /// <summary>
        /// Não informar NR_DOCUMENTO para sinistro com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=03; CD_FORMA_PAGTO=C
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3467_NR_DOCUMENTO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3467", "FG02 - PROC176 - Não informar NR_DOCUMENTO para sinistro com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=03; CD_FORMA_PAGTO=C");
            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200213.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "146");
            AlterarLinha(0, "NR_DOCUMENTO", "");
            AlterarLinha(0, "TP_SINISTRO", "03");
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
            ValidarTabelaDeRetorno(1, "176");
            ValidarTeste();
        }

        /// <summary>
        /// Não informar NR_DOCUMENTO para sinistro com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=04; CD_FORMA_PAGTO=C
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3468_NR_DOCUMENTO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3468", "FG02 - PROC176 - Não informar NR_DOCUMENTO para sinistro com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=04; CD_FORMA_PAGTO=C");
            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200209.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "146");
            AlterarLinha(0, "NR_DOCUMENTO", "");
            AlterarLinha(0, "TP_SINISTRO", "04");
            AlterarLinha(0, "CD_FORMA_PAGTO", "C");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SGS.SINISTRO-EV-/*R*/-20200209.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "176");
            ValidarTeste();
        }

        /// <summary>
        /// Não informar NR_DOCUMENTO para sinistro com: CD_TIPO_MOVIMENTO=7; TP_SINISTRO=01; CD_FORMA_PAGTO=C
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3469_NR_DOCUMENTO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3469", "FG02 - PROC176 - Não informar NR_DOCUMENTO para sinistro com: CD_TIPO_MOVIMENTO=7; TP_SINISTRO=01; CD_FORMA_PAGTO=C");
            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "7");
            AlterarLinha(0, "NR_DOCUMENTO", "");
            AlterarLinha(0, "TP_SINISTRO", "01");
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
            ValidarTabelaDeRetorno(1, "176");
            ValidarTeste();
        }

        /// <summary>
        /// Não informar NR_DOCUMENTO para sinistro com: CD_TIPO_MOVIMENTO=7; TP_SINISTRO=02; CD_FORMA_PAGTO=C
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3470_NR_DOCUMENTO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3470", "FG02 - PROC176 - Não informar NR_DOCUMENTO para sinistro com: CD_TIPO_MOVIMENTO=7; TP_SINISTRO=02; CD_FORMA_PAGTO=C");
            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "7");
            AlterarLinha(0, "NR_DOCUMENTO", "");
            AlterarLinha(0, "TP_SINISTRO", "02");
            AlterarLinha(0, "CD_FORMA_PAGTO", "C");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SGS.SINISTRO-EV-/*R*/-20200212.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "176");
            ValidarTeste();
        }

        /// <summary>
        /// Não informar NR_DOCUMENTO para sinistro com: CD_TIPO_MOVIMENTO=7; TP_SINISTRO=03; CD_FORMA_PAGTO=C
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3471_NR_DOCUMENTO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3471", "FG02 - PROC176 - Não informar NR_DOCUMENTO para sinistro com: CD_TIPO_MOVIMENTO=7; TP_SINISTRO=03; CD_FORMA_PAGTO=C");
            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200213.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "7");
            AlterarLinha(0, "NR_DOCUMENTO", "");
            AlterarLinha(0, "TP_SINISTRO", "03");
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
            ValidarTabelaDeRetorno(1, "176");
            ValidarTeste();
        }

        /// <summary>
        /// Não informar NR_DOCUMENTO para sinistro com: CD_TIPO_MOVIMENTO=7; TP_SINISTRO=04; CD_FORMA_PAGTO=C
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3472_NR_DOCUMENTO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3472", "FG02 - PROC176 - Não informar NR_DOCUMENTO para sinistro com: CD_TIPO_MOVIMENTO=7; TP_SINISTRO=04; CD_FORMA_PAGTO=C");
            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200209.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "7");
            AlterarLinha(0, "NR_DOCUMENTO", "");
            AlterarLinha(0, "TP_SINISTRO", "04");
            AlterarLinha(0, "CD_FORMA_PAGTO", "C");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SGS.SINISTRO-EV-/*R*/-20200209.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "176");
            ValidarTeste();
        }

        /// <summary>
        ///Informar NR_DOCUMENTO para sinistro com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=01; CD_FORMA_PAGTO=C
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3473_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3473", "FG02 - PROC176 - Informar NR_DOCUMENTO para sinistro com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=01; CD_FORMA_PAGTO=C");

            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "146");
            AlterarLinha(0, "NR_DOCUMENTO", "123456");
            AlterarLinha(0, "TP_SINISTRO", "01");
            AlterarLinha(0, "CD_FORMA_PAGTO", "C");

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
        ///Informar NR_DOCUMENTO para sinistro com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=02; CD_FORMA_PAGTO=C
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3474_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3474", "FG02 - PROC176 - Informar NR_DOCUMENTO para sinistro com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=02; CD_FORMA_PAGTO=C");

            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "146");
            AlterarLinha(0, "NR_DOCUMENTO", "123456");
            AlterarLinha(0, "TP_SINISTRO", "02");
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
        ///Informar NR_DOCUMENTO para sinistro com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=03; CD_FORMA_PAGTO=C
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3475_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3475", "FG02 - PROC176 - Informar NR_DOCUMENTO para sinistro com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=03; CD_FORMA_PAGTO=C");

            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200213.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "146");
            AlterarLinha(0, "NR_DOCUMENTO", "123456");
            AlterarLinha(0, "TP_SINISTRO", "03");
            AlterarLinha(0, "CD_FORMA_PAGTO", "C");

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
        ///Informar NR_DOCUMENTO para sinistro com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=04; CD_FORMA_PAGTO=C
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3476_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3476", "FG02 - PROC176 - Informar NR_DOCUMENTO para sinistro com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=04; CD_FORMA_PAGTO=C");

            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200209.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "146");
            AlterarLinha(0, "NR_DOCUMENTO", "123456");
            AlterarLinha(0, "TP_SINISTRO", "04");
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
        ///Informar NR_DOCUMENTO para sinistro com: CD_TIPO_MOVIMENTO=7; TP_SINISTRO=01; CD_FORMA_PAGTO=C
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3377_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3377", "FG02 - PROC176 - Informar NR_DOCUMENTO para sinistro com: CD_TIPO_MOVIMENTO=7; TP_SINISTRO=01; CD_FORMA_PAGTO=C");

            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "7");
            AlterarLinha(0, "NR_DOCUMENTO", "123456");
            AlterarLinha(0, "TP_SINISTRO", "01");
            AlterarLinha(0, "CD_FORMA_PAGTO", "C");

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
        ///Informar NR_DOCUMENTO para sinistro com: CD_TIPO_MOVIMENTO=7; TP_SINISTRO=02; CD_FORMA_PAGTO=C
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3478_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3378", "FG02 - PROC176 - Informar NR_DOCUMENTO para sinistro com: CD_TIPO_MOVIMENTO=7; TP_SINISTRO=02; CD_FORMA_PAGTO=C");

            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "7");
            AlterarLinha(0, "NR_DOCUMENTO", "123456");
            AlterarLinha(0, "TP_SINISTRO", "02");
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
        ///Informar NR_DOCUMENTO para sinistro com: CD_TIPO_MOVIMENTO=7; TP_SINISTRO=03; CD_FORMA_PAGTO=C
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3479_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3379", "FG02 - PROC176 - Informar NR_DOCUMENTO para sinistro com: CD_TIPO_MOVIMENTO=7; TP_SINISTRO=03; CD_FORMA_PAGTO=C");

            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200213.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "7");
            AlterarLinha(0, "NR_DOCUMENTO", "123456");
            AlterarLinha(0, "TP_SINISTRO", "03");
            AlterarLinha(0, "CD_FORMA_PAGTO", "C");

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
        ///Informar NR_DOCUMENTO para sinistro com: CD_TIPO_MOVIMENTO=7; TP_SINISTRO=04; CD_FORMA_PAGTO=C
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3480_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3380", "FG02 - PROC176 - Informar NR_DOCUMENTO para sinistro com: CD_TIPO_MOVIMENTO=7; TP_SINISTRO=04; CD_FORMA_PAGTO=C");

            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200209.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "7");
            AlterarLinha(0, "NR_DOCUMENTO", "123456");
            AlterarLinha(0, "TP_SINISTRO", "04");
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
    }
}
