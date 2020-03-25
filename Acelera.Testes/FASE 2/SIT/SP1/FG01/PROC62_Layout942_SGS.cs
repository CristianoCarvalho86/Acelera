using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4_2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP1.FG01
{
    [TestClass]
    public class PROC62_Layout942_SGS : TestesFG01
    {

        /// <summary>
        /// No Body do arquivo SINISTRO no campo CD_SINISTRO não informar o número do sinistro (Será criiticado também plea PROC 5)
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2291_SINISTRO_SemCD_SINISTRO()
        {
            IniciarTeste(TipoArquivo.Sinistro, "2291", "FG01 - PROC62 - No Body do arquivo SINISTRO no campo CD_SINISTRO não informar o número do sinistro");
            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200209.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_SINISTRO", "");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("C01.SGS.SINISTRO-EV-/*R*/-20200209.TXT");

            //VALIDAR NA FG00
            ValidarFGsAnteriores();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("62");
            ValidarTeste();
        }

        /// <summary>
        ///  Importar arquivo com NR_SINISTRO valido
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2554_SINISTRO()
        {
        }

    }
}
