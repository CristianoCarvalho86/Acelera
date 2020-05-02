using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_3;
using Acelera.Domain.Layouts._9_4;
using Acelera.Domain.Layouts._9_4_2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC127_Layout93_VIVO : TestesFG02
    {

        /// <summary>
        /// 	Duplicar linha que possua CD_TIPO_EMISSAO=1. Na linha duplicada, alterar: - ID TRANSACAO: Somar 1 unidade do numero anterior; - o CD_TIPO_EMISSAO para 9 (Cancelamento Seguradora) - informar ID_TRANSACAO_CANC igual ao ID_TRANSACAO
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3162_ID_TRANSACAO_CANC_IGUAL_ID_TRANSACAO_PARA()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "3162", "FG02 - PROC111 - PARC AUTO- ID_TRANSACAO_CANC igual ID_TRANSACAO ");
            arquivo = new Arquivo_Layout_9_4_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1864-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            var idTransacao = SomarValores(ObterValorFormatado(0, "ID_TRANSACAO"), "1");
            AlterarLinha(0, "CD_TIPO_EMISSAO", "1");

            ReplicarLinhaComCorrecao(0, 1);


            AlterarLinha(1, "CD_TIPO_EMISSAO", "9");
            AlterarLinha(1, "ID_TRANSACAO", idTransacao);
            AlterarLinha(1, "ID_TRANSACAO_CANC", idTransacao);


            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissaoAuto.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1,"127");
            ValidarTeste();

        }

        /// <summary>
        /// 	Duplicar linha que possua CD_TIPO_EMISSAO=1. Na linha duplicada, alterar: - ID TRANSACAO: Somar 1 unidade do numero anterior; - o CD_TIPO_EMISSAO para 10 (Cancelamento Segurado) - informar ID_TRANSACAO_CANC igual ao ID_TRANSACAO - Alterar CD_MOVTO_COBRANCA igual a 02
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3163_ID_TRANSACAO_CANC_IGUAL_ID_TRANSACAO_PARA()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "3163", "FG02 - PROC111 - PARC AUTO- ID_TRANSACAO_CANC igual ID_TRANSACAO ");
            arquivo = new Arquivo_Layout_9_4_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1868-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            var idTransacao = SomarValores(ObterValorFormatado(0, "ID_TRANSACAO"), "1");
            AlterarLinha(0, "CD_TIPO_EMISSAO", "1");

            ReplicarLinhaComCorrecao(0, 1);


            AlterarLinha(1, "CD_TIPO_EMISSAO", "10");
            AlterarLinha(1, "ID_TRANSACAO", idTransacao);
            AlterarLinha(1, "ID_TRANSACAO_CANC", idTransacao);
            AlterarLinha(1, "CD_MOVTO_COBRANCA", "02");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissaoAuto.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "127");
            ValidarTeste();

        }

        /// <summary>
        /// 	Duplicar linha que possua CD_TIPO_EMISSAO=1. Na linha duplicada, alterar: - ID TRANSACAO: Somar 1 unidade do numero anterior; - o CD_TIPO_EMISSAO para 12 (Cancelamento Sinistro) - informar ID_TRANSACAO_CANC igual ao ID_TRANSACAO
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3164_ID_TRANSACAO_CANC_IGUAL_ID_TRANSACAO_PARA()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "3164", "FG02 - PROC127 - PARC AUTO- ID_TRANSACAO_CANC igual ID_TRANSACAO ");
            arquivo = new Arquivo_Layout_9_4_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1864-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            var idTransacao = SomarValores(ObterValorFormatado(0, "ID_TRANSACAO"), "1");
            AlterarLinha(0, "CD_TIPO_EMISSAO", "1");

            ReplicarLinhaComCorrecao(0, 1);


            AlterarLinha(1, "CD_TIPO_EMISSAO", "12");
            AlterarLinha(1, "NR_PARCELA", "2");
            AlterarLinha(1, "ID_TRANSACAO", idTransacao);
            AlterarLinha(1, "ID_TRANSACAO_CANC", idTransacao);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("PROC127");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissaoAuto.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "127");
            ValidarTeste();

        }

        /// <summary>
        /// 	Duplicar linha que possua CD_TIPO_EMISSAO=1. Na linha duplicada, alterar: - ID TRANSACAO: Somar 1 unidade do numero anterior; - o CD_TIPO_EMISSAO para 13 (Cancelamento Erro de Emissão) - informar ID_TRANSACAO_CANC igual ao ID_TRANSACAO
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3165_ID_TRANSACAO_CANC_IGUAL_ID_TRANSACAO_PARA()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "3165", "FG02 - PROC111 - PARC AUTO- ID_TRANSACAO_CANC igual ID_TRANSACAO ");
            arquivo = new Arquivo_Layout_9_4_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1868-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            var idTransacao = SomarValores(ObterValorFormatado(0, "ID_TRANSACAO"), "1");
            AlterarLinha(0, "CD_TIPO_EMISSAO", "1");

            ReplicarLinhaComCorrecao(0, 1);


            AlterarLinha(1, "CD_TIPO_EMISSAO", "13");
            AlterarLinha(1, "ID_TRANSACAO", idTransacao);
            AlterarLinha(1, "ID_TRANSACAO_CANC", idTransacao);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissaoAuto.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "127");
            ValidarTeste();

        }

        /// <summary>
        /// 	Duplicar linha que possua CD_TIPO_EMISSAO=1. Na linha duplicada, alterar: - ID TRANSACAO: Somar 1 unidade do numero anterior; - o CD_TIPO_EMISSAO para 21 (Cancelamento de Item) - informar ID_TRANSACAO_CANC igual ao ID_TRANSACAO
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3166_ID_TRANSACAO_CANC_IGUAL_ID_TRANSACAO_PARA()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "3166", "FG02 - PROC111 - PARC AUTO- ID_TRANSACAO_CANC igual ID_TRANSACAO ");
            arquivo = new Arquivo_Layout_9_4_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1864-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            var idTransacao = SomarValores(ObterValorFormatado(0, "ID_TRANSACAO"), "1");
            AlterarLinha(0, "CD_TIPO_EMISSAO", "1");

            ReplicarLinhaComCorrecao(0, 1);


            AlterarLinha(1, "CD_TIPO_EMISSAO", "21");
            AlterarLinha(1, "ID_TRANSACAO", idTransacao);
            AlterarLinha(1, "ID_TRANSACAO_CANC", idTransacao);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissaoAuto.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "127");
            ValidarTeste();

        }

        /// <summary>
        /// 	Duplicar linha que possua CD_TIPO_EMISSAO=1. Na linha duplicada, alterar: - ID TRANSACAO: Somar 1 unidade do numero anterior; - o CD_TIPO_EMISSAO para 9 (Cancelamento Seguradora) - informar ID_TRANSACAO_CANC igual ao ID_TRANSACAO da linha original (e não da linha replicada)
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3167_ID_TRANSACAO_CANC_IGUAL_ID_TRANSACAO_PARA()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "3167", "FG02 - PROC111 - PARC AUTO- ID_TRANSACAO_CANC igual ID_TRANSACAO ");
            arquivo = new Arquivo_Layout_9_4_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1868-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            var idTransacao = SomarValores(ObterValorFormatado(0, "ID_TRANSACAO"), "1");
            AlterarLinha(0, "CD_TIPO_EMISSAO", "1");

            ReplicarLinhaComCorrecao(0, 1);


            AlterarLinha(1, "CD_TIPO_EMISSAO", "21");
            AlterarLinha(1, "ID_TRANSACAO", idTransacao);
            AlterarLinha(1, "ID_TRANSACAO_CANC", ObterValorFormatado(0, "ID_TRANSACAO"));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissaoAuto.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno();
            ValidarTeste();

        }

        /// <summary>
        /// 	Duplicar linha que possua CD_TIPO_EMISSAO=1. Na linha duplicada, alterar: - ID TRANSACAO: Somar 1 unidade do numero anterior; - o CD_TIPO_EMISSAO para 10 (Cancelamento Segurado) - informar ID_TRANSACAO_CANC igual ao ID_TRANSACAO - Alterar CD_MOVTO_COBRANCA igual a 02
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3168_ID_TRANSACAO_CANC_IGUAL_ID_TRANSACAO_PARA()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "3168", "FG02 - PROC111 - PARC AUTO- ID_TRANSACAO_CANC igual ID_TRANSACAO ");
            arquivo = new Arquivo_Layout_9_4_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1864-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            var idTransacao = SomarValores(ObterValorFormatado(0, "ID_TRANSACAO"), "1");
            AlterarLinha(0, "CD_TIPO_EMISSAO", "1");

            ReplicarLinhaComCorrecao(0, 1);


            AlterarLinha(1, "CD_TIPO_EMISSAO", "10");
            AlterarLinha(1, "ID_TRANSACAO", idTransacao);
            AlterarLinha(1, "ID_TRANSACAO_CANC", ObterValorFormatado(0, "ID_TRANSACAO"));
            AlterarLinha(1, "CD_MOVTO_COBRANCA", "02");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissaoAuto.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno();
            ValidarTeste();

        }

        /// <summary>
        /// 	Duplicar linha que possua CD_TIPO_EMISSAO=1. Na linha duplicada, alterar: - ID TRANSACAO: Somar 1 unidade do numero anterior; - o CD_TIPO_EMISSAO para 12 (Cancelamento Sinistro) - informar ID_TRANSACAO_CANC igual ao ID_TRANSACAO
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3169_ID_TRANSACAO_CANC_IGUAL_ID_TRANSACAO_PARA()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "3169", "FG02 - PROC111 - PARC AUTO- ID_TRANSACAO_CANC igual ID_TRANSACAO ");
            arquivo = new Arquivo_Layout_9_4_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1868-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            var idTransacao = SomarValores(ObterValorFormatado(0, "ID_TRANSACAO"), "1");
            AlterarLinha(0, "CD_TIPO_EMISSAO", "1");

            ReplicarLinhaComCorrecao(0, 1);


            AlterarLinha(1, "CD_TIPO_EMISSAO", "12");
            AlterarLinha(1, "ID_TRANSACAO", idTransacao);
            AlterarLinha(1, "ID_TRANSACAO_CANC", ObterValorFormatado(0, "ID_TRANSACAO"));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissaoAuto.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno();
            ValidarTeste();

        }

        /// <summary>
        /// 	Duplicar linha que possua CD_TIPO_EMISSAO=1. Na linha duplicada, alterar: - ID TRANSACAO: Somar 1 unidade do numero anterior; - o CD_TIPO_EMISSAO para 13 (Cancelamento Erro de Emissão) - informar ID_TRANSACAO_CANC igual ao ID_TRANSACAO
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3170_ID_TRANSACAO_CANC_IGUAL_ID_TRANSACAO_PARA()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "3170", "FG02 - PROC111 - PARC AUTO- ID_TRANSACAO_CANC igual ID_TRANSACAO ");
            arquivo = new Arquivo_Layout_9_4_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1864-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            var idTransacao = SomarValores(ObterValorFormatado(0, "ID_TRANSACAO"), "1");
            AlterarLinha(0, "CD_TIPO_EMISSAO", "1");

            ReplicarLinhaComCorrecao(0, 1);


            AlterarLinha(1, "CD_TIPO_EMISSAO", "13");
            AlterarLinha(1, "ID_TRANSACAO", idTransacao);
            AlterarLinha(1, "ID_TRANSACAO_CANC", ObterValorFormatado(0, "ID_TRANSACAO"));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissaoAuto.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno();
            ValidarTeste();

        }

        /// <summary>
        /// 	Duplicar linha que possua CD_TIPO_EMISSAO=1. Na linha duplicada, alterar: - ID TRANSACAO: Somar 1 unidade do numero anterior; - o CD_TIPO_EMISSAO para 21 (Cancelamento de Item) - informar ID_TRANSACAO_CANC igual ao ID_TRANSACAO
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3171_ID_TRANSACAO_CANC_IGUAL_ID_TRANSACAO_PARA()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "3171", "FG02 - PROC111 - PARC AUTO- ID_TRANSACAO_CANC igual ID_TRANSACAO ");
            arquivo = new Arquivo_Layout_9_4_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1868-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            var idTransacao = SomarValores(ObterValorFormatado(0, "ID_TRANSACAO"), "1");
            AlterarLinha(0, "CD_TIPO_EMISSAO", "1");

            ReplicarLinhaComCorrecao(0, 1);


            AlterarLinha(1, "CD_TIPO_EMISSAO", "21");
            AlterarLinha(1, "ID_TRANSACAO", idTransacao);
            AlterarLinha(1, "ID_TRANSACAO_CANC", ObterValorFormatado(0, "ID_TRANSACAO"));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissaoAuto.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno();
            ValidarTeste();

        }
    }
}
