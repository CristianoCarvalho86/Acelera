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
        /// Infomar CD_SEXO=K
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3820_ParcEmissao_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3820", "FG02 - PROC1039 - Infomar CD_SEXO=kInfomar CD_SEXO=K");

            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.PARCEMS-EV-1931-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "CD_SEXO", "K");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.POMPEIA.PARCEMS-EV-/*R*/-20200212.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(false);
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTeste();

        }

        /// <summary>
        /// Infomar CD_SEXO=1
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3818_ParcEmissao_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3818", "FG02 - PROC1039 - Infomar CD_SEXO=kInfomar CD_SEXO=1");

            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.PARCEMS-EV-1928-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "CD_SEXO", "1");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.POMPEIA.PARCEMS-EV-/*R*/-20200211.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(false);
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTeste();

        }

    }
}
