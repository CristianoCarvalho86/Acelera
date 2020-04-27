using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC1039_Layout94_Pompeia : TestesFG02
    {
        /// <summary>
        /// Infomar SEXO=K
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3820_Cliente_semcritica()
        {
            IniciarTeste(TipoArquivo.Cliente, "3820", "FG02 - PROC1039 - Infomar SEXO=kInfomar SEXO=K");

            arquivo = new Arquivo_Layout_9_4_Cliente();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.CLIENTE-EV-1924-20200210.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "SEXO", "K");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

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

        /// <summary>
        /// Infomar SEXO=1
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3818_Cliente_semcritica()
        {
            IniciarTeste(TipoArquivo.Cliente, "3818", "FG02 - PROC1039 - Infomar SEXO=kInfomar SEXO=1");

            arquivo = new Arquivo_Layout_9_4_Cliente();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.CLIENTE-EV-1927-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "SEXO", "1");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

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
