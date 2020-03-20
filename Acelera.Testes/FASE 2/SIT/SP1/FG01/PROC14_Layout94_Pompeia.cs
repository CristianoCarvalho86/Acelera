using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP1.FG01
{
    [TestClass]
    public class PROC14_Layout94_Pompeia : TestesFG01
    {
        /// <summary>
        /// No Body do arquivo PARC_EMISSAO no campo ID_TRANSACAO informar o número na sequência: NR_ENDOSSO, CD_RAMO, NR_PARCELA, NR_APOLICE
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2420_PARC_EMISSAO_ID_TRANSACAO_Dif()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "2420", "FG01 - PROC14 - No Body do arquivo PARC_EMISSAO no campo ID_TRANSACAO informar o número na sequência: NR_ENDOSSO, CD_RAMO, NR_PARCELA, NR_APOLICE");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.PARCEMS-EV-1925-20200210.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "ID_TRANSACAO", "0771717702500789349");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("C01.POMPEIA.PARCEMS-EV-/*R*/-20200210.TXT");

            //VALIDAR NA FG00
            ValidarFG00();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("14");
            ValidarTeste();
        }

        /// <summary>
        /// Importar arquivo com ID_TRANSACAO correto
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2544_PARC_EMISSAO_ID_TRANSACAO()
        {
        }

    }
}
