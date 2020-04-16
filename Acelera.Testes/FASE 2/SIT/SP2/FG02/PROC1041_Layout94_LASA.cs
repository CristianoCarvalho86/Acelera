using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC1041_Layout94_LASA : TestesFG02
    {

        /// <summary>
        /// Informar TP_PESSOA=J
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3821_NR_CNPJ_CPF_inv()
        {
            IniciarTeste(TipoArquivo.Cliente, "3821", "FG02 - PROC1041 - Informar TP_PESSOA=J");
            arquivo = new Arquivo_Layout_9_4_Cliente();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.CLIENTE-EV-3209-20200319.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "TP_PESSOA", "J");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.CLIENTE-EV-/*R*/-20200319.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Cliente.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "1041");
            ValidarTeste();

        }

        /// <summary>
        /// Informar TP_PESSOA=F
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3822_Cliente_semcritica()
        {
            IniciarTeste(TipoArquivo.Cliente, "3822", "FG02 - PROC1041 - Informar TP_PESSOA=F");

            arquivo = new Arquivo_Layout_9_4_Cliente();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.CLIENTE-EV-3225-20200320.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "TP_PESSOA", "F");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.CLIENTE-EV-/*R*/-20200320.txt");

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
