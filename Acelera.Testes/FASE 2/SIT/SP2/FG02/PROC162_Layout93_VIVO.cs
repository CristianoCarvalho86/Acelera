using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_3;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC162_Layout93_VIVO : TestesFG02
    {

        /// <summary>
        /// Enviar dois registro no mesmo arquivo, um com CD_TIPO_EMISSÃO=1 e o segundo com CD_TIPO_EMISSAO=5. No segundo, informar DT_EMISSAO anterior a data do primeiro
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3369_PARC_EMISSAO_VL_IS_negativo()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "3369", "FG02 - PROC162 - Enviar dois registro no mesmo arquivo, um com CD_TIPO_EMISSÃO=1 e o segundo com CD_TIPO_EMISSAO=5. No segundo, informar DT_EMISSAO anterior a data do primeiro	");
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1864-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            ReplicarLinha(0, 1);
            AlterarLinha(0, "CD_TIPO_EMISSAO", "1");
            AlterarLinha(1, "CD_TIPO_EMISSAO", "5");
            AlterarLinha(1, "ID_TRANSACAO_CANC", SomarData(ObterValor(0,"DT_EMISSAO"),-365));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.VIVO.PARCEMSAUTO-EV-/*R*/-20200211.TXT");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissaoAuto.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "162");
            ValidarTeste();

        }

        /// <summary>
        /// Enviar dois registro no mesmo arquivo, um com CD_TIPO_EMISSÃO=1 e o segundo com CD_TIPO_EMISSAO=6. No segundo, informar DT_EMISSAO anterior a data do primeiro
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3370_PARC_EMISSAO_VL_IS_negativo()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "3370", "FG02 - PROC162 - Enviar dois registro no mesmo arquivo, um com CD_TIPO_EMISSÃO=1 e o segundo com CD_TIPO_EMISSAO=6. No segundo, informar DT_EMISSAO anterior a data do primeiro	");
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1868-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            ReplicarLinha(0, 1);
            AlterarLinha(0, "CD_TIPO_EMISSAO", "1");
            AlterarLinha(1, "CD_TIPO_EMISSAO", "6");
            AlterarLinha(1, "ID_TRANSACAO_CANC", SomarData(ObterValor(0, "DT_EMISSAO"), -30));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.VIVO.PARCEMSAUTO-EV-/*R*/-20200212.TXT");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissaoAuto.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "162");
            ValidarTeste();

        }

        /// <summary>
        /// Enviar dois registro no mesmo arquivo, um com CD_TIPO_EMISSÃO=1 e o segundo com CD_TIPO_EMISSAO=7. No segundo, informar DT_EMISSAO anterior a data do primeiro
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3371_PARC_EMISSAO_VL_IS_negativo()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "3371", "FG02 - PROC162 - Enviar dois registro no mesmo arquivo, um com CD_TIPO_EMISSÃO=1 e o segundo com CD_TIPO_EMISSAO=7. No segundo, informar DT_EMISSAO anterior a data do primeiro	");
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1864-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            ReplicarLinha(0, 1);
            AlterarLinha(0, "CD_TIPO_EMISSAO", "1");
            AlterarLinha(1, "CD_TIPO_EMISSAO", "7");
            AlterarLinha(1, "ID_TRANSACAO_CANC", SomarData(ObterValor(0, "DT_EMISSAO"), -7));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.VIVO.PARCEMSAUTO-EV-/*R*/-20200211.TXT");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissaoAuto.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "162");
            ValidarTeste();

        }

        /// <summary>
        /// Enviar dois registro no mesmo arquivo, um com CD_TIPO_EMISSÃO=1 e o segundo com CD_TIPO_EMISSAO=8. No segundo, informar DT_EMISSAO anterior a data do primeiro
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3372_PARC_EMISSAO_VL_IS_negativo()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "3372", "FG02 - PROC162 - Enviar dois registro no mesmo arquivo, um com CD_TIPO_EMISSÃO=1 e o segundo com CD_TIPO_EMISSAO=8. No segundo, informar DT_EMISSAO anterior a data do primeiro	");
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1868-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            ReplicarLinha(0, 1);
            AlterarLinha(0, "CD_TIPO_EMISSAO", "1");
            AlterarLinha(1, "CD_TIPO_EMISSAO", "8");
            AlterarLinha(1, "ID_TRANSACAO_CANC", SomarData(ObterValor(0, "DT_EMISSAO"), -10));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.VIVO.PARCEMSAUTO-EV-/*R*/-20200212.TXT");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissaoAuto.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "162");
            ValidarTeste();

        }

        /// <summary>
        /// Enviar dois registro no mesmo arquivo, um com CD_TIPO_EMISSÃO=1 e o segundo com CD_TIPO_EMISSAO=11. No segundo, informar DT_EMISSAO anterior a data do primeiro
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3373_PARC_EMISSAO_VL_IS_negativo()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "3373", "FG02 - PROC162 - Enviar dois registro no mesmo arquivo, um com CD_TIPO_EMISSÃO=1 e o segundo com CD_TIPO_EMISSAO=11. No segundo, informar DT_EMISSAO anterior a data do primeiro	");
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1868-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            ReplicarLinha(0, 1);
            AlterarLinha(0, "CD_TIPO_EMISSAO", "1");
            AlterarLinha(1, "CD_TIPO_EMISSAO", "11");
            AlterarLinha(1, "ID_TRANSACAO_CANC", SomarData(ObterValor(0, "DT_EMISSAO"), -10));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("PROC162");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissaoAuto.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "162");
            ValidarTeste();

        }

        /// <summary>
        /// Enviar dois registro no mesmo arquivo, um com CD_TIPO_EMISSÃO=1 e o segundo com CD_TIPO_EMISSAO=19. No segundo, informar DT_EMISSAO anterior a data do primeiro
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3374_PARC_EMISSAO_VL_IS_negativo()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "3374", "FG02 - PROC162 - Enviar dois registro no mesmo arquivo, um com CD_TIPO_EMISSÃO=1 e o segundo com CD_TIPO_EMISSAO=19. No segundo, informar DT_EMISSAO anterior a data do primeiro	");
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1864-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            ReplicarLinha(0, 1);
            AlterarLinha(0, "CD_TIPO_EMISSAO", "1");
            AlterarLinha(1, "CD_TIPO_EMISSAO", "19");
            AlterarLinha(1, "ID_TRANSACAO_CANC", SomarData(ObterValor(0,"DT_EMISSAO"),-10));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.VIVO.PARCEMSAUTO-EV-/*R*/-20200211.TXT");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissaoAuto.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "162");
            ValidarTeste();

        }

        /// <summary>
        /// Enviar dois registro no mesmo arquivo, um com CD_TIPO_EMISSÃO=1 e o segundo com CD_TIPO_EMISSAO=5. No segundo, informar DT_EMISSAO igual a data do primeiro
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3375_PARC_EMISSAO_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "3375", "FG00 - PROC162 - Enviar dois registro no mesmo arquivo, um com CD_TIPO_EMISSÃO=1 e o segundo com CD_TIPO_EMISSAO=5. No segundo, informar DT_EMISSAO igual a data do primeiro");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1868-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            ReplicarLinha(0, 1);
            AlterarLinha(0, "CD_TIPO_EMISSAO", "1");
            AlterarLinha(1, "CD_TIPO_EMISSAO", "5");
            AlterarLinha(1, "ID_TRANSACAO_CANC", ObterValor(0, "DT_EMISSAO"));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.VIVO.PARCEMSAUTO-EV-/*R*/-20200212.TXT");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissaoAuto.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(false);
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTeste();

        }

        /// <summary>
        /// Enviar dois registro no mesmo arquivo, um com CD_TIPO_EMISSÃO=1 e o segundo com CD_TIPO_EMISSAO=6. No segundo, informar DT_EMISSAO igual a data do primeiro
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3376_PARC_EMISSAO_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "3376", "FG00 - PROC162 - Enviar dois registro no mesmo arquivo, um com CD_TIPO_EMISSÃO=1 e o segundo com CD_TIPO_EMISSAO=6. No segundo, informar DT_EMISSAO igual a data do primeiro");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1864-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            ReplicarLinha(0, 1);
            AlterarLinha(0, "CD_TIPO_EMISSAO", "1");
            AlterarLinha(1, "CD_TIPO_EMISSAO", "6");
            AlterarLinha(1, "ID_TRANSACAO_CANC", ObterValor(0, "DT_EMISSAO"));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.VIVO.PARCEMSAUTO-EV-/*R*/-20200211.TXT");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissaoAuto.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(false);
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTeste();

        }

        /// <summary>
        /// Enviar dois registro no mesmo arquivo, um com CD_TIPO_EMISSÃO=1 e o segundo com CD_TIPO_EMISSAO=7. No segundo, informar DT_EMISSAO igual a data do primeiro
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3377_PARC_EMISSAO_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "3377", "FG00 - PROC162 - Enviar dois registro no mesmo arquivo, um com CD_TIPO_EMISSÃO=1 e o segundo com CD_TIPO_EMISSAO=7. No segundo, informar DT_EMISSAO igual a data do primeiro");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1868-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            ReplicarLinha(0, 1);
            AlterarLinha(0, "CD_TIPO_EMISSAO", "1");
            AlterarLinha(1, "CD_TIPO_EMISSAO", "7");
            AlterarLinha(1, "ID_TRANSACAO_CANC", ObterValor(0, "DT_EMISSAO"));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.VIVO.PARCEMSAUTO-EV-/*R*/-20200212.TXT");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissaoAuto.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(false);
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTeste();

        }

        /// <summary>
        /// Enviar dois registro no mesmo arquivo, um com CD_TIPO_EMISSÃO=1 e o segundo com CD_TIPO_EMISSAO=8. No segundo, informar DT_EMISSAO igual a data do primeiro
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3378_PARC_EMISSAO_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "3378", "FG00 - PROC162 - Enviar dois registro no mesmo arquivo, um com CD_TIPO_EMISSÃO=1 e o segundo com CD_TIPO_EMISSAO=8. No segundo, informar DT_EMISSAO igual a data do primeiro");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1864-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            ReplicarLinha(0, 1);
            AlterarLinha(0, "CD_TIPO_EMISSAO", "1");
            AlterarLinha(1, "CD_TIPO_EMISSAO", "8");
            AlterarLinha(1, "ID_TRANSACAO_CANC", ObterValor(0, "DT_EMISSAO"));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.VIVO.PARCEMSAUTO-EV-/*R*/-20200211.TXT");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissaoAuto.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(false);
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTeste();

        }

        /// <summary>
        /// Enviar dois registro no mesmo arquivo, um com CD_TIPO_EMISSÃO=1 e o segundo com CD_TIPO_EMISSAO=11. No segundo, informar DT_EMISSAO igual a data do primeiro
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3379_PARC_EMISSAO_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "3379", "FG00 - PROC162 - Enviar dois registro no mesmo arquivo, um com CD_TIPO_EMISSÃO=1 e o segundo com CD_TIPO_EMISSAO=11. No segundo, informar DT_EMISSAO igual a data do primeiro");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1868-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            ReplicarLinha(0, 1);
            AlterarLinha(0, "CD_TIPO_EMISSAO", "1");
            AlterarLinha(1, "CD_TIPO_EMISSAO", "11");
            AlterarLinha(1, "ID_TRANSACAO_CANC", ObterValor(0, "DT_EMISSAO"));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.VIVO.PARCEMSAUTO-EV-/*R*/-20200212.TXT");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissaoAuto.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(false);
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTeste();

        }

        /// <summary>
        /// Enviar dois registro no mesmo arquivo, um com CD_TIPO_EMISSÃO=1 e o segundo com CD_TIPO_EMISSAO=19. No segundo, informar DT_EMISSAO igual a data do primeiro
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3380_PARC_EMISSAO_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "3380", "FG00 - PROC162 - Enviar dois registro no mesmo arquivo, um com CD_TIPO_EMISSÃO=1 e o segundo com CD_TIPO_EMISSAO=19. No segundo, informar DT_EMISSAO igual a data do primeiro");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1864-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            ReplicarLinha(0, 1);
            AlterarLinha(0, "CD_TIPO_EMISSAO", "1");
            AlterarLinha(1, "CD_TIPO_EMISSAO", "19");
            AlterarLinha(1, "ID_TRANSACAO_CANC", ObterValor(0, "DT_EMISSAO"));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.VIVO.PARCEMSAUTO-EV-/*R*/-20200211.TXT");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissaoAuto.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(false);
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTeste();

        }

        /// <summary>
        /// Enviar dois registro no mesmo arquivo, um com CD_TIPO_EMISSÃO=1 e o segundo com CD_TIPO_EMISSAO=5. No segundo, informar DT_EMISSAO superior a data do primeiro
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3381_PARC_EMISSAO_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "3381", "FG00 - PROC162 -Enviar dois registro no mesmo arquivo, um com CD_TIPO_EMISSÃO=1 e o segundo com CD_TIPO_EMISSAO=5. No segundo, informar DT_EMISSAO superior a data do primeiro");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1868-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            ReplicarLinha(0, 1);
            AlterarLinha(0, "CD_TIPO_EMISSAO", "1");
            AlterarLinha(1, "CD_TIPO_EMISSAO", "5");
            AlterarLinha(1, "ID_TRANSACAO_CANC", SomarData(ObterValor(0, "DT_EMISSAO"), 10));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.VIVO.PARCEMSAUTO-EV-/*R*/-20200212.TXT");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissaoAuto.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(false);
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTeste();

        }

        /// <summary>
        /// Enviar dois registro no mesmo arquivo, um com CD_TIPO_EMISSÃO=1 e o segundo com CD_TIPO_EMISSAO=6. No segundo, informar DT_EMISSAO superior a data do primeiro
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3382_PARC_EMISSAO_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "3382", "FG00 - PROC162 -Enviar dois registro no mesmo arquivo, um com CD_TIPO_EMISSÃO=1 e o segundo com CD_TIPO_EMISSAO65. No segundo, informar DT_EMISSAO superior a data do primeiro");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1864-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            ReplicarLinha(0, 1);
            AlterarLinha(0, "CD_TIPO_EMISSAO", "1");
            AlterarLinha(1, "CD_TIPO_EMISSAO", "6");
            AlterarLinha(1, "ID_TRANSACAO_CANC", SomarData(ObterValor(0, "DT_EMISSAO"), 10));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.VIVO.PARCEMSAUTO-EV-/*R*/-20200211.TXT");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissaoAuto.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(false);
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTeste();

        }

        /// <summary>
        /// Enviar dois registro no mesmo arquivo, um com CD_TIPO_EMISSÃO=1 e o segundo com CD_TIPO_EMISSAO=7. No segundo, informar DT_EMISSAO superior a data do primeiro
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3383_PARC_EMISSAO_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "3383", "FG00 - PROC162 -Enviar dois registro no mesmo arquivo, um com CD_TIPO_EMISSÃO=1 e o segundo com CD_TIPO_EMISSAO=7. No segundo, informar DT_EMISSAO superior a data do primeiro");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1868-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            ReplicarLinha(0, 1);
            AlterarLinha(0, "CD_TIPO_EMISSAO", "1");
            AlterarLinha(1, "CD_TIPO_EMISSAO", "7");
            AlterarLinha(1, "ID_TRANSACAO_CANC", SomarData(ObterValor(0, "DT_EMISSAO"), 10));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.VIVO.PARCEMSAUTO-EV-/*R*/-20200212.TXT");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissaoAuto.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(false);
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTeste();

        }

        /// <summary>
        /// Enviar dois registro no mesmo arquivo, um com CD_TIPO_EMISSÃO=1 e o segundo com CD_TIPO_EMISSAO=8. No segundo, informar DT_EMISSAO superior a data do primeiro
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3384_PARC_EMISSAO_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "3384", "FG00 - PROC162 -Enviar dois registro no mesmo arquivo, um com CD_TIPO_EMISSÃO=1 e o segundo com CD_TIPO_EMISSAO=8. No segundo, informar DT_EMISSAO superior a data do primeiro");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1864-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            ReplicarLinha(0, 1);
            AlterarLinha(0, "CD_TIPO_EMISSAO", "1");
            AlterarLinha(1, "CD_TIPO_EMISSAO", "8");
            AlterarLinha(1, "ID_TRANSACAO_CANC", SomarData(ObterValor(0, "DT_EMISSAO"), 7));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.VIVO.PARCEMSAUTO-EV-/*R*/-20200211.TXT");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissaoAuto.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(false);
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTeste();

        }

        /// <summary>
        /// Enviar dois registro no mesmo arquivo, um com CD_TIPO_EMISSÃO=1 e o segundo com CD_TIPO_EMISSAO=11. No segundo, informar DT_EMISSAO superior a data do primeiro
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3385_PARC_EMISSAO_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "3385", "FG00 - PROC162 -Enviar dois registro no mesmo arquivo, um com CD_TIPO_EMISSÃO=1 e o segundo com CD_TIPO_EMISSAO=1. No segundo, informar DT_EMISSAO superior a data do primeiro");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1868-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            ReplicarLinha(0, 1);
            AlterarLinha(0, "CD_TIPO_EMISSAO", "1");
            AlterarLinha(1, "CD_TIPO_EMISSAO", "11");
            AlterarLinha(1, "ID_TRANSACAO_CANC", SomarData(ObterValor(0, "DT_EMISSAO"),30));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.VIVO.PARCEMSAUTO-EV-/*R*/-20200212.TXT");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissaoAuto.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(false);
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTeste();

        }

        /// <summary>
        /// Enviar dois registro no mesmo arquivo, um com CD_TIPO_EMISSÃO=1 e o segundo com CD_TIPO_EMISSAO=19. No segundo, informar DT_EMISSAO superior a data do primeiro
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3386_PARC_EMISSAO_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "3386", "FG00 - PROC162 -Enviar dois registro no mesmo arquivo, um com CD_TIPO_EMISSÃO=1 e o segundo com CD_TIPO_EMISSAO=19. No segundo, informar DT_EMISSAO superior a data do primeiro");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1864-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            ReplicarLinha(0, 1);
            AlterarLinha(0, "CD_TIPO_EMISSAO", "1");
            AlterarLinha(1, "CD_TIPO_EMISSAO", "19");
            AlterarLinha(1, "ID_TRANSACAO_CANC", SomarData(ObterValor(0, "DT_EMISSAO"),365));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.VIVO.PARCEMSAUTO-EV-/*R*/-20200211.TXT");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissaoAuto.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(false);
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTeste();

        }
    }
}
