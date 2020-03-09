using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP1.FG01
{
    [TestClass]
    public class PROC14_Layout94_TIM : TestesFG01
    {

        /// <summary>
        /// No Body do arquivo PARC_EMISSAO no campo ID_TRANSACAO informar o número na sequência: CD_RAMO, NR_PARCELA, NR_ENDOSSO, NR_APOLICE
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2346_PARC_EMISSAO_ID_TRANSACAO_Dif()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "2346", "FG01 - PROC14 - No Body do arquivo PARC_EMISSAO no campo ID_TRANSACAO informar o número na sequência: CD_RAMO, NR_PARCELA, NR_ENDOSSO, NR_APOLICE");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.TIM.PARCEMS-EV-0001-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "ID_TRANSACAO", "7700797700210057146");

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino("C01.TIM.PARCEMS-EV-/*R*/-20200212.TXT"));

            //VALIDAR NA FG00
            ValidarFG00();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages<LinhaParcEmissaoStage>(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("14");
        }

        /// <summary>
        /// No Body do arquivo PARC_EMISSAO nos campos abaixo informado o código 1234567 respeitando a tamanho do campos: ID_TRANSACAO (Será criiticado pela PROC 5)
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2345_PARC_EMISSAO_ID_TRANSACAO_Dif()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "2345", "FG01 - PROC14 - No Body do arquivo PARC_EMISSAO nos campos abaixo informado o código 1234567");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.TIM.PARCEMS-EV-0001-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "ID_TRANSACAO", "1234567");

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino("C01.TIM.PARCEMS-EV-/*R*/-20200212.TXT"));

            //VALIDAR NA FG00
            ValidarFG00();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages<LinhaParcEmissaoStage>(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("14");
        }

        /// <summary>
        /// Importar arquivo com ID_TRANSACAO correto
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2543_PARC_EMISSAO_ID_TRANSACAO()
        {
        }

    }
}
