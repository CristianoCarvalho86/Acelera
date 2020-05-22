using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC223_Layout94_LASA : TestesFG02
    {

        /// <summary>
        /// Informar CD_TIPO_EMISSAO igual 10 e CD_MOVTO_COBRANCA igual 01. Tambem preencher campo ID_TRANSACAO_CANC
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3765_CANC_Inv()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3765", "FG02 - PROC223 - Informar CD_TIPO_EMISSAO igual 10 e CD_MOVTO_COBRANCA igual 01. Tambem preencher campo ID_TRANSACAO_CANC");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.PARCEMS-EV-3158-20200316.txt"));

            //ALTERAR O VALOR SELECIONADO
            var idTransacao = SomarValores(ObterValorFormatado(0, "ID_TRANSACAO"), "1");
            ReplicarLinhaComCorrecao(0, 1);

            AlterarLinha(1, "NR_ENDOSSO", SomarValor(0, "NR_ENDOSSO", 1));
            AlterarLinha(1, "NR_SEQUENCIAL_EMISSAO", SomarValor(0, "NR_SEQUENCIAL_EMISSAO", 1));
            AlterarLinha(1, "CD_TIPO_EMISSAO", "10");
            AlterarLinha(1, "CD_MOVTO_COBRANCA", "01");
            AlterarLinha(1, "ID_TRANSACAO_CANC", idTransacao);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.PARCEMS-EV-/*R*/-20200316.txt");

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
        public void SAP_3766_CANC_Inv()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3766", "FG02 - PROC223 - Informar CD_TIPO_EMISSAO igual 11 e CD_MOVTO_COBRANCA igual 01. Tambem preencher campo ID_TRANSACAO_CANC");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.PARCEMS-EV-3175-20200317.txt"));

            //ALTERAR O VALOR SELECIONADO
            var idTransacao = SomarValores(ObterValorFormatado(0, "ID_TRANSACAO"), "1");
            ReplicarLinhaComCorrecao(0, 1);

            AlterarLinha(1, "NR_ENDOSSO", SomarValor(0, "NR_ENDOSSO", 1));
            AlterarLinha(1, "NR_SEQUENCIAL_EMISSAO", SomarValor(0, "NR_SEQUENCIAL_EMISSAO", 1));
            AlterarLinha(1, "CD_TIPO_EMISSAO", "11");
            AlterarLinha(1, "CD_MOVTO_COBRANCA", "01");
            AlterarLinha(1, "ID_TRANSACAO_CANC", idTransacao);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("PROC223");

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
        public void SAP_3767_PARC_EMISSAO_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3767", "FG02 - PROC223 - Informar CD_TIPO_EMISSAO=9 e CD_MOVTO_COBRANCA=10. Tambem preencher campo ID_TRANSACAO_CANC");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.PARCEMS-EV-3192-20200318.txt"));

            //ALTERAR O VALOR SELECIONADO
            var idTransacao = SomarValores(ObterValorFormatado(0, "ID_TRANSACAO"), "1");
            ReplicarLinhaComCorrecao(0, 1);

            AlterarLinha(1, "NR_ENDOSSO", SomarValor(0, "NR_ENDOSSO", 1));
            AlterarLinha(1, "NR_SEQUENCIAL_EMISSAO", SomarValor(0, "NR_SEQUENCIAL_EMISSAO", 1));
            AlterarLinha(1, "CD_TIPO_EMISSAO", "9");
            AlterarLinha(1, "CD_MOVTO_COBRANCA", "02");
            AlterarLinha(1, "ID_TRANSACAO_CANC", idTransacao);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.PARCEMS-EV-/*R*/-20200318.txt");

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
        public void SAP_3768_PARC_EMISSAO_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3768", "FG02 - PROC223 - Informar CD_TIPO_EMISSAO=11 e CD_MOVTO_COBRANCA=02. Tambem preencher campo ID_TRANSACAO_CANC");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.PARCEMS-EV-3208-20200319.txt"));

            //ALTERAR O VALOR SELECIONADO
            var idTransacao = SomarValores(ObterValorFormatado(0, "ID_TRANSACAO"), "1");
            ReplicarLinhaComCorrecao(0, 1);

            AlterarLinha(1, "NR_ENDOSSO", SomarValor(0, "NR_ENDOSSO", 1));
            AlterarLinha(1, "NR_SEQUENCIAL_EMISSAO", SomarValor(0, "NR_SEQUENCIAL_EMISSAO", 1));
            AlterarLinha(1, "CD_TIPO_EMISSAO", "11");
            AlterarLinha(1, "CD_MOVTO_COBRANCA", "02");
            AlterarLinha(1, "ID_TRANSACAO_CANC", idTransacao);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.PARCEMS-EV-/*R*/-20200319.txt");

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
