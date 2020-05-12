using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC1041_Layout94_Pompeia : TestesFG02
    {
        /// <summary>
        /// Informar TIPO=J
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3825_Cliente_semcritica()
        {
            IniciarTeste(TipoArquivo.Cliente, "3824", "FG02 - PROC1041 - Informar TIPO=J");

            arquivo = new Arquivo_Layout_9_4_Cliente();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.CLIENTE-EV-1927-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "TIPO", "J");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.POMPEIA.CLIENTE-EV-/*R*/-20200211.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Cliente.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(true, "1041");
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia, true);
            ValidarTeste();

        }
    }
}
