using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_3;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC1041_Layout93_VIVO : TestesFG02
    {
        /// <summary>
        /// Informar TP_PESSOA=J
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3826_Cliente_semcritica()
        {
            IniciarTeste(TipoArquivo.Cliente, "3826", "FG02 - PROC1041 - Informar TP_PESSOA=J");

            arquivo = new Arquivo_Layout_9_3_Cliente();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.CLIENTE-EV-1871-20200213.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "TP_PESSOA", "J");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.VIVO.CLIENTE-EV-/*R*/-20200213.txt");

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
