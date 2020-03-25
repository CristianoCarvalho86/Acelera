using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4_2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP1.FG01
{
    [TestClass]
    public class PROC05_Layout942_SGS : TestesFG01
    {
        /// <summary>
        /// No Body do arquivo SINISTRO não informar valor nos seguintes campos: 
        /// CD_INTERNO_RESSEGURADOR CD_SEGURADORA CD_CORRETOR CD_RAMO CD_CONTRATO NR_SEQUENCIAL_EMISSAO NR_PARCELA CD_ITEM
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2285_SINISTRO_SemCampObrig_Body()
        {
            IniciarTeste(TipoArquivo.Sinistro, "2285", "FG01 - PROC5 - No Body do arquivo SINISTRO não informar valor nos seguintes campos: CD_INTERNO_RESSEGURADOR CD_SEGURADORA CD_CORRETOR CD_RAMO CD_CONTRATO NR_SEQUENCIAL_EMISSAO NR_PARCELA CD_ITEM");
            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200209.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_INTERNO_RESSEGURADOR", "");
            AlterarLinha(0, "CD_SEGURADORA", "");
            //AlterarLinha(0, "CD_CORRETOR", "");
            AlterarLinha(0, "CD_RAMO", "");
            AlterarLinha(0, "CD_CONTRATO", "");
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", "");
            //AlterarLinha(0, "NR_PARCELA", "");
            AlterarLinha(0, "CD_ITEM", "");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("C01.SGS.SINISTRO-EV-/*R*/-20200209.TXT");

            //VALIDAR NA FG00
            ValidarFGsAnteriores();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("5");
            ValidarTeste();
        }

        /// <summary>
        /// Arquivo c/ tds os campos obrig. preenchidos
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2493_SINISTRO()
        {
        }

    }
}
