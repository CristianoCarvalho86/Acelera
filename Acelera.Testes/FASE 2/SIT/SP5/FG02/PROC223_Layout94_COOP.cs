using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP5.FG02
{
    [TestClass]
    public class PROC223_Layout94_COOP : TestesFG02
    {

        /// <summary>
        /// Informar CD_TIPO_EMISSAO igual 10 e CD_MOVTO_COBRANCA igual 01. Tambem preencher campo ID_TRANSACAO_CANC
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3773_CANC_Inv()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3773", "FG02 - PROC223 - Informar CD_TIPO_EMISSAO igual 10 e CD_MOVTO_COBRANCA igual 01. Tambem preencher campo ID_TRANSACAO_CANC");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.COOP.PARCEMS-EV-1925-20200210.txt"));

            //ALTERAR O VALOR SELECIONADO
            var idTransacao = SomarValores(ObterValorFormatado(0, "ID_TRANSACAO"), "1");
            ReplicarLinhaComCorrecao(0, 1);

            AlterarLinha(1, "NR_ENDOSSO", SomarValor(0, "NR_ENDOSSO", 1));
            AlterarLinha(1, "NR_SEQUENCIAL_EMISSAO", SomarValor(0, "NR_SEQUENCIAL_EMISSAO", 1));
            AlterarLinha(1, "CD_TIPO_EMISSAO", "10");
            AlterarLinha(1, "CD_MOVTO_COBRANCA", "01");
            AlterarLinha(1, "ID_TRANSACAO_CANC", idTransacao);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.COOP.PARCEMS-EV-/*R*/-20200210.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "223");
            ValidarTeste();

        }

        /// <summary>
        /// Informar CD_TIPO_EMISSAO igual 11 e CD_MOVTO_COBRANCA igual 01. Tambem preencher campo ID_TRANSACAO_CANC
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3774_CANC_Inv()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3774", "FG02 - PROC223 - Informar CD_TIPO_EMISSAO igual 11 e CD_MOVTO_COBRANCA igual 01. Tambem preencher campo ID_TRANSACAO_CANC");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.COOP.PARCEMS-EV-1928-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            var idTransacao = SomarValores(ObterValorFormatado(0, "ID_TRANSACAO"), "1");
            ReplicarLinhaComCorrecao(0, 1);

            AlterarLinha(1, "NR_ENDOSSO", SomarValor(0, "NR_ENDOSSO", 1));
            AlterarLinha(1, "NR_SEQUENCIAL_EMISSAO", SomarValor(0, "NR_SEQUENCIAL_EMISSAO", 1));
            AlterarLinha(1, "CD_TIPO_EMISSAO", "11");
            AlterarLinha(1, "CD_MOVTO_COBRANCA", "01");
            AlterarLinha(1, "ID_TRANSACAO_CANC", idTransacao);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.COOP.PARCEMS-EV-/*R*/-20200211.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "223");
            ValidarTeste();

        }

        
        /// <summary>
        /// Informar CD_TIPO_EMISSAO=10 e CD_MOVTO_COBRANCA=02. Tambem preencher campo ID_TRANSACAO_CANC
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3775_PARC_EMISSAO_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3775", "FG02 - PROC223 - Informar CD_TIPO_EMISSAO=9 e CD_MOVTO_COBRANCA=10. Tambem preencher campo ID_TRANSACAO_CANC");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.COOP.PARCEMS-EV-1931-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            var idTransacao = SomarValores(ObterValorFormatado(0, "ID_TRANSACAO"), "1");
            ReplicarLinhaComCorrecao(0, 1);

            AlterarLinha(1, "NR_ENDOSSO", SomarValor(0, "NR_ENDOSSO", 1));
            AlterarLinha(1, "NR_SEQUENCIAL_EMISSAO", SomarValor(0, "NR_SEQUENCIAL_EMISSAO", 1));
            AlterarLinha(1, "CD_TIPO_EMISSAO", "9");
            AlterarLinha(1, "CD_MOVTO_COBRANCA", "02");
            AlterarLinha(1, "ID_TRANSACAO_CANC", idTransacao);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.COOP.PARCEMS-EV-/*R*/-20200212.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(true, "223");
            ValidarStagesSemGerarErro(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTeste();

        }

        /// <summary>
        /// Informar CD_TIPO_EMISSAO=11 e CD_MOVTO_COBRANCA=02. Tambem preencher campo ID_TRANSACAO_CANC
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3776_PARC_EMISSAO_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3776", "FG02 - PROC223 - Informar CD_TIPO_EMISSAO=11 e CD_MOVTO_COBRANCA=02. Tambem preencher campo ID_TRANSACAO_CANC");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.COOP.PARCEMS-EV-1934-20200213.txt"));

            //ALTERAR O VALOR SELECIONADO
            var idTransacao = SomarValores(ObterValorFormatado(0, "ID_TRANSACAO"), "1");
            ReplicarLinhaComCorrecao(0, 1);

            AlterarLinha(1, "NR_ENDOSSO", SomarValor(0, "NR_ENDOSSO", 1));
            AlterarLinha(1, "NR_SEQUENCIAL_EMISSAO", SomarValor(0, "NR_SEQUENCIAL_EMISSAO", 1));
            AlterarLinha(1, "CD_TIPO_EMISSAO", "11");
            AlterarLinha(1, "CD_MOVTO_COBRANCA", "02");
            AlterarLinha(1, "ID_TRANSACAO_CANC", idTransacao);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.COOP.PARCEMS-EV-/*R*/-20200213.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(true, "223");
            ValidarStagesSemGerarErro(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTeste();

        }
    }
}
