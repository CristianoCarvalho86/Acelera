using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4_2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP1.FG01
{
    [TestClass]
    public class PROC92_Layout942_SGS : TestesFG01
    {

        /// <summary>
        ///  No Header do arquivo SINISTRO no campo VERSAO informar o código 9
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2293_SINISTRO_VERSAO_9()
        {
            IniciarTeste(TipoArquivo.Sinistro, "2293", "FG01 - PROC92 - No Header do arquivo SINISTRO no campo VERSAO informar o código 9");
            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200209.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarHeader("VERSAO", "9");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo(ObterArquivoDestino("C01.SGS.SINISTRO-EV-/*R*/-20200209.TXT"));

            //VALIDAR NA FG00
            ValidarFG00();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("92");
            ValidarTeste();
        }

        /// <summary>
        ///  Importar arquivo com Versão Layout correta
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2581_SINISTRO()
        {
        }
    }
}
