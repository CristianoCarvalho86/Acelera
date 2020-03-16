using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4_2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP1.FG00
{
    [TestClass]
    public class PROC401_Layout942_SGS : TestesFG00
    {
        /// <summary>
        /// Importar arquivo com campo Tipo Nome do Arquivo (segundo campo da nomenclatura) diferente do parametrizado na tabela TAB_PRM_LAYOUT_7016. Ex.: C01.POMPEIA.ARQUIVO-EV-1927-20200211.TXT
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2623_SINISTRO_TipoNomeArq_Dif()
        {
            IniciarTeste(TipoArquivo.Sinistro, "2623", "FG00 - PROC401 - Importar arquivo com campo Tipo Nome do Arquivo (segundo campo da nomenclatura) diferente do parametrizado");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200209.txt"));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SGS.ARQUIVO-EV-/*R*/-20200209.TXT");

            AlterarNomeArquivo();

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Estrutura da Mascara do arquivo não é a esperada.");
            ValidarTabelaDeRetorno("401");
            ValidarStages(false);
            ValidarTeste();
        }


        /// <summary>
        ///  Importar arquivo com nomenclatura correta
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2654_SINISTRO_()
        {
        }

    }
}
