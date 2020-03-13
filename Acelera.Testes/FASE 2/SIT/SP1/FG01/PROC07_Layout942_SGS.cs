using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4_2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP1.FG01
{
    [TestClass]
    public class PROC07_Layout942_SGS : TestesFG01
    {

        /// <summary>
        /// No Body do arquivo SINISTRO não informar valor nos seguintes campos, ou seja, campos em branco, respeitando a tamanho do campos 
        /// CD_TIPO_MOVIMENTO CD_AVISO CD_RAMO CD_CLIENTE CD_MOVIMENTO VL_MOVIMENTO VL_TAXA_PAGTO 
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2289_SINISTRO_SemCampoNum_Header_Body_Trailler()
        {
            IniciarTeste(TipoArquivo.Sinistro, "2415", "FG01 - PROC7 - No Body do arquivo SINISTRO não informar valor nos seguintes campos, ou seja, campos em branco, respeitando a tamanho do campos CD_TIPO_MOVIMENTO CD_AVISO CD_RAMO CD_CLIENTE CD_MOVIMENTO VL_MOVIMENTO VL_TAXA_PAGTO ");
            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "");
            AlterarLinha(0, "CD_AVISO", "");
            AlterarLinha(0, "CD_RAMO", "");
            AlterarLinha(0, "CD_CLIENTE", "");
            AlterarLinha(0, "CD_MOVIMENTO", "");
            AlterarLinha(0, "VL_MOVIMENTO", "");
            AlterarLinha(0, "VL_TAXA_PAGTO", "");

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino("C01.SGS.SINISTRO-EV-/*R*/-20200211.TXT"));

            //VALIDAR NA FG00
            ValidarFG00();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("7");
            ValidarTeste();
        }
               
        /// <summary>
        /// Arquivo c/ tds campos numéricos válidos
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2531_SINISTRO()
        {
        }

    }
}
