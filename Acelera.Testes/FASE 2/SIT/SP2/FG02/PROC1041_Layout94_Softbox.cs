using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC1041_Layout94_Softbox : TestesFG02
    {

        /// <summary>
        /// Informar TIPO=J
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3823_NR_CNPJ_CPF_inv()
        {
            IniciarTeste(TipoArquivo.Cliente, "3823", "FG02 - PROC1041 - Informar TIPO=J");
            arquivo = new Arquivo_Layout_9_4_Cliente();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.CLIENTE-EV-3259-20200322.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "TIPO", "J");
            AlterarLinha(1, "NR_CNPJ_CPF", "77812487000131");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

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
        /// Informar TIPO=F
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3824_Cliente_semcritica()
        {
            IniciarTeste(TipoArquivo.Cliente, "3824", "FG02 - PROC1041 - Informar TIPO=F");

            arquivo = new Arquivo_Layout_9_4_Cliente();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.CLIENTE-EV-3211-20200319.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "TIPO", "F");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SOFTBOX.CLIENTE-EV-/*R*/-20200319.txt");

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
