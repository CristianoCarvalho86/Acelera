using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC23_Layout94_Pompeia : TestesFG02
    {

        /// <summary>
        /// Informar no campo CD_MOEDA valor diferente do parametrizado na tabela TAB_PRM_MOEDA_7030
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2708_PARC_EMISSAO_CD_MOEDA_Inv()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "2708", "FG02 - PROC23 - Informar no campo CD_MOEDA valor diferente do parametrizado na tabela TAB_PRM_MOEDA_7030");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.PARCEMS-EV-1931-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(9, "CD_MOEDA", dados.ObterCDMoeda(false));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.POMPEIA.PARCEMS-EV-/*R*/-20200212.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno("23");
            ValidarTeste();

        }

        /// <summary>
        /// Informar no campo CD_MOEDA valor parametrizado na tabela TAB_PRM_MOEDA_7030
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2709_PARC_EMISSAO_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "2709", "FG02 - PROC23 - Informar no campo CD_MOEDA valor parametrizado na tabela TAB_PRM_MOEDA_7030");
            
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.PARCEMS-EV-1931-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(9, "CD_MOEDA", dados.ObterCDMoeda(true));

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
        
    }
}
