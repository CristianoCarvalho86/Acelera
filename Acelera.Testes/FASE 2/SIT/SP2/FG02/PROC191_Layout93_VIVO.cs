using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_3;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC191_Layout93_VIVO : TestesFG02
    {

        /// <summary>
        /// Informar CD_TIPO_EMISSAO=12 e CD_MOVTO_COBRANCA=02. Tambem preencher campo ID_TRANSACAO_CANC
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3705_CANC_Inv()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "3705", "FG02 - PROC191 - Informar CD_TIPO_EMISSAO=12 e CD_MOVTO_COBRANCA=02. Tambem preencher campo ID_TRANSACAO_CANC");
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1868-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            var idTransacao = SomarValores(ObterValorFormatado(0, "ID_TRANSACAO"), "1");
            ReplicarLinha(0, 1);
            AumentarLinhasNoFooter(1);
            AlterarLinha(1, "CD_TIPO_EMISSAO", "12");
            AlterarLinha(1, "CD_MOVTO_COBRANCA", "02");
            AlterarLinha(1, "ID_TRANSACAO_CANC", idTransacao);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.VIVO.PARCEMSAUTO-EV-/*R*/-20200212.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissaoAuto.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "191");
            ValidarTeste();

        }

        /// <summary>
        /// Informar CD_TIPO_EMISSAO=12 e CD_MOVTO_COBRANCA=03. Tambem preencher campo ID_TRANSACAO_CANC
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3706_PARC_EMISSAO_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "3706", "FG02 - PROC191 - Informar CD_TIPO_EMISSAO=12 e CD_MOVTO_COBRANCA=03. Tambem preencher campo ID_TRANSACAO_CANC");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1864-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            var idTransacao = SomarValores(ObterValorFormatado(0, "ID_TRANSACAO"), "1");
            ReplicarLinha(0, 1);
            AumentarLinhasNoFooter(1);
            AlterarLinha(1, "CD_TIPO_EMISSAO", "12");
            AlterarLinha(1, "CD_MOVTO_COBRANCA", "03");
            AlterarLinha(1, "ID_TRANSACAO_CANC", idTransacao);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.VIVO.PARCEMSAUTO-EV-/*R*/-20200211.txt");

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
        /// Informar CD_TIPO_EMISSAO=9 e CD_MOVTO_COBRANCA=02. Tambem preencher campo ID_TRANSACAO_CANC
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3707_PARC_EMISSAO_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "3707", "FG02 - PROC191 - Informar CD_TIPO_EMISSAO=9 e CD_MOVTO_COBRANCA=02. Tambem preencher campo ID_TRANSACAO_CANC");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1868-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            var idTransacao = SomarValores(ObterValorFormatado(0, "ID_TRANSACAO"), "1");
            ReplicarLinha(0, 1);
            AumentarLinhasNoFooter(1);
            AlterarLinha(1, "CD_TIPO_EMISSAO", "9");
            AlterarLinha(1, "CD_MOVTO_COBRANCA", "02");
            AlterarLinha(1, "ID_TRANSACAO_CANC", idTransacao);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.VIVO.PARCEMSAUTO-EV-/*R*/-20200212.txt");

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
        /// Informar CD_TIPO_EMISSAO=10 e CD_MOVTO_COBRANCA=02. Tambem preencher campo ID_TRANSACAO_CANC
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3708_PARC_EMISSAO_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "3708", "FG02 - PROC191 - Informar CD_TIPO_EMISSAO=10 e CD_MOVTO_COBRANCA=02. Tambem preencher campo ID_TRANSACAO_CANC");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1864-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            var idTransacao = SomarValores(ObterValorFormatado(0, "ID_TRANSACAO"), "1");
            ReplicarLinha(0, 1);
            AumentarLinhasNoFooter(1);
            AlterarLinha(1, "CD_TIPO_EMISSAO", "10");
            AlterarLinha(1, "CD_MOVTO_COBRANCA", "02");
            AlterarLinha(1, "ID_TRANSACAO_CANC", idTransacao);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.VIVO.PARCEMSAUTO-EV-/*R*/-20200211.txt");

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
        /// Informar CD_TIPO_EMISSAO=13 e CD_MOVTO_COBRANCA=02. Tambem preencher campo ID_TRANSACAO_CANC
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3709_PARC_EMISSAO_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "3709", "FG02 - PROC191 - Informar CD_TIPO_EMISSAO=13 e CD_MOVTO_COBRANCA=02. Tambem preencher campo ID_TRANSACAO_CANC");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1868-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            var idTransacao = SomarValores(ObterValorFormatado(0, "ID_TRANSACAO"), "1");
            ReplicarLinha(0, 1);
            AumentarLinhasNoFooter(1);
            AlterarLinha(1, "CD_TIPO_EMISSAO", "13");
            AlterarLinha(1, "CD_MOVTO_COBRANCA", "02");
            AlterarLinha(1, "ID_TRANSACAO_CANC", idTransacao);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.VIVO.PARCEMSAUTO-EV-/*R*/-20200212.txt");

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
        /// Informar CD_TIPO_EMISSAO=21 e CD_MOVTO_COBRANCA=02. Tambem preencher campo ID_TRANSACAO_CANC
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3710_PARC_EMISSAO_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "3710", "FG02 - PROC191 - Informar CD_TIPO_EMISSAO=21 e CD_MOVTO_COBRANCA=02. Tambem preencher campo ID_TRANSACAO_CANC");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1864-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            var idTransacao = SomarValores(ObterValorFormatado(0, "ID_TRANSACAO"), "1");
            ReplicarLinha(0, 1);
            AumentarLinhasNoFooter(1);
            AlterarLinha(1, "CD_TIPO_EMISSAO", "21");
            AlterarLinha(1, "CD_MOVTO_COBRANCA", "02");
            AlterarLinha(1, "ID_TRANSACAO_CANC", idTransacao);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.VIVO.PARCEMSAUTO-EV-/*R*/-20200211.txt");

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
