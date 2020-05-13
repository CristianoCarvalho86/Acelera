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
    public class PROC127_Layout94_Softbox : TestesFG02
    {


        /// <summary>
        /// 	Duplicar linha que possua CD_TIPO_EMISSAO=1. Na linha duplicada, alterar: - ID TRANSACAO: Somar 1 unidade do numero anterior; - o CD_TIPO_EMISSAO para 10 (Cancelamento Segurado) - informar ID_TRANSACAO_CANC igual ao ID_TRANSACAO - Alterar CD_MOVTO_COBRANCA igual a 02
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3180_ID_TRANSACAO_CANC_IGUAL_ID_TRANSACAO_PARA()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3180", "FG02 - PROC127 - PARC AUTO- ID_TRANSACAO_CANC igual ID_TRANSACAO ");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.PARCEMS-EV-3325-20200326.txt"));

            //ALTERAR O VALOR SELECIONADO
            var idTransacao = SomarValores(ObterValorFormatado(0, "ID_TRANSACAO"), "1");
            var nrParcela = SomarValores(ObterValorFormatado(0, "NR_PARCELA"), "1");
            AlterarLinha(0, "CD_TIPO_EMISSAO", "18");

            ReplicarLinhaComCorrecao(0, 1);

            AlterarLinha(1, "NR_PARCELA", nrParcela);
            AlterarLinha(1, "CD_TIPO_EMISSAO", "10");
            AlterarLinha(1, "ID_TRANSACAO", idTransacao);
            AlterarLinha(1, "ID_TRANSACAO_CANC", idTransacao);
            AlterarLinha(1, "CD_MOVTO_COBRANCA", "02");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SOFTBOX.PARCEMS-EV-/*R*/-20200326.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "127");
            ValidarTeste();

        }

        /// <summary>
        /// 	Duplicar linha que possua CD_TIPO_EMISSAO=1. Na linha duplicada, alterar: - ID TRANSACAO: Somar 1 unidade do numero anterior; - o CD_TIPO_EMISSAO para 10 (Cancelamento Segurado) - informar ID_TRANSACAO_CANC igual ao ID_TRANSACAO - Alterar CD_MOVTO_COBRANCA igual a 02
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3181_ID_TRANSACAO_CANC_IGUAL_ID_TRANSACAO_PARA()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3172", "FG02 - PROC123 - PARC AUTO- ID_TRANSACAO_CANC igual ID_TRANSACAO ");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.PARCEMS-EV-3325-20200326.txt"));

            //ALTERAR O VALOR SELECIONADO
            var idTransacao = SomarValores(ObterValorFormatado(0, "ID_TRANSACAO"), "1");
            var nrParcela = SomarValores(ObterValorFormatado(0, "NR_PARCELA"), "1");
            AlterarLinha(0, "CD_TIPO_EMISSAO", "18");

            ReplicarLinhaComCorrecao(0, 1);

            AlterarLinha(1, "NR_PARCELA", nrParcela);
            AlterarLinha(1, "CD_TIPO_EMISSAO", "11");
            AlterarLinha(1, "ID_TRANSACAO", idTransacao);
            AlterarLinha(1, "ID_TRANSACAO_CANC", idTransacao);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SOFTBOX.PARCEMS-EV-/*R*/-20200326.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "127");
            ValidarTeste();

        }


        /// <summary>
        /// 	Duplicar linha que possua CD_TIPO_EMISSAO=1. Na linha duplicada, alterar: - ID TRANSACAO: Somar 1 unidade do numero anterior; - o CD_TIPO_EMISSAO para 10 (Cancelamento Segurado) - informar ID_TRANSACAO_CANC igual ao ID_TRANSACAO - Alterar CD_MOVTO_COBRANCA igual a 02
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3174_ID_TRANSACAO_CANC_IGUAL_ID_TRANSACAO_PARA()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3174", "FG02 - PROC127 - PARC AUTO- ID_TRANSACAO_CANC igual ID_TRANSACAO ");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.PARCEMS-EV-3325-20200326.txt"));

            //ALTERAR O VALOR SELECIONADO
            var idTransacao = SomarValores(ObterValorFormatado(0, "ID_TRANSACAO"), "1");
            var nrParcela = SomarValores(ObterValorFormatado(0, "NR_PARCELA"), "1");
            AlterarLinha(0, "CD_TIPO_EMISSAO", "18");

            ReplicarLinhaComCorrecao(0, 1);

            AlterarLinha(1, "NR_PARCELA", nrParcela);
            AlterarLinha(1, "CD_TIPO_EMISSAO", "10");
            AlterarLinha(1, "ID_TRANSACAO", idTransacao);
            AlterarLinha(1, "ID_TRANSACAO_CANC", ObterValorFormatado(0, "ID_TRANSACAO"));
            AlterarLinha(1, "CD_MOVTO_COBRANCA", "02");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SOFTBOX.PARCEMS-EV-/*R*/-20200326.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia, true);
            ValidarTabelaDeRetorno(true, "127");
            ValidarTeste();

        }
        /// <summary>
        /// 	Duplicar linha que possua CD_TIPO_EMISSAO=18 Na linha duplicada, alterar: - ID TRANSACAO: Somar 1 unidade do numero anterior; - o CD_TIPO_EMISSAO para 11 (Cancelamento por falta de pagamento) - informar ID_TRANSACAO_CANC igual ao ID_TRANSACAO
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3175_ID_TRANSACAO_CANC_IGUAL_ID_TRANSACAO_PARA()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3175", "FG02 - PROC127 - PARC AUTO- ID_TRANSACAO_CANC igual ID_TRANSACAO ");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.PARCEMS-EV-3325-20200326.txt"));

            //ALTERAR O VALOR SELECIONADO
            var idTransacao = SomarValores(ObterValorFormatado(0, "ID_TRANSACAO"), "1");
            var nrParcela = SomarValores(ObterValorFormatado(0, "NR_PARCELA"), "1");
            AlterarLinha(0, "CD_TIPO_EMISSAO", "18");

            ReplicarLinhaComCorrecao(0, 1);

            AlterarLinha(1, "NR_PARCELA", nrParcela);
            AlterarLinha(1, "CD_TIPO_EMISSAO", "11");
            AlterarLinha(1, "ID_TRANSACAO", idTransacao);
            AlterarLinha(1, "ID_TRANSACAO_CANC", ObterValorFormatado(0, "ID_TRANSACAO"));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SOFTBOX.PARCEMS-EV-/*R*/-20200326.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia, true);
            ValidarTabelaDeRetorno(true, "127");
            ValidarTeste();

        }
    }
}
