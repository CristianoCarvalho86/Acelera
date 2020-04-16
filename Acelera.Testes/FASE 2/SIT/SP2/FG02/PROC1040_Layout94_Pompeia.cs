using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC1040_Layout94_Pompeia : TestesFG02
    {
        /// <summary>
        /// Informar CNPJ no campo NR_CNPJ_CPF
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3831_Cliente_semcritica()
        {
            IniciarTeste(TipoArquivo.Cliente, "3831", "FG02 - PROC1040 - Informar CPF no campo NR_CNPJ_CPF");

            arquivo = new Arquivo_Layout_9_4_Cliente();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.CLIENTE-EV-1924-20200210.txt"));

            //ALTERAR O VALOR SELECIONADO
            SalvarArquivo($"C01.SOFTBOX.CLIENTE-EV-/*R*/-20200211.txt");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.POMPEIA.CLIENTE-EV-/*R*/-20200210.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Cliente.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(false);
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTeste();

        }
    }
}
