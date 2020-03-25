using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP1.FG01
{
    [TestClass]
    public class PROC15_Layout94_TIM : TestesFG01
    {

        /// <summary>
        /// No Body do arquivo PARC_EMISSAO nos campos abaixo informado o código 1234567 respeitando a tamanho do campos: ID_TRANSACAO_CANC Premissa: CD_TIPO_EMISSAO do registro ser 9 ou 10 ou 11 ou 12 ou 13 ou 21
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2347_PARC_EMISSAO_ID_TRANSACAO_CANC_Dif()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "2347", "FG01 - PROC15 - No Body do arquivo PARC_EMISSAO nos campos abaixo informado o código 1234567");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.TIM.PARCEMS-EV-0001-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "ID_TRANSACAO_CANC", "");
            AlterarLinha(0, "CD_TIPO_EMISSAO", "9");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("C01.TIM.PARCEMS-EV-/*R*/-20200212.TXT");

            //VALIDAR NA FG00
            ValidarFGsAnteriores();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("15");
            ValidarTeste();
        }

        /// <summary>
        /// Importar arquivo com ID_TRANSACAO_CANC correto
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2546_PARC_EMISSAO_ID_TRANSACAO_CANC()
        {
        }

    }
}
