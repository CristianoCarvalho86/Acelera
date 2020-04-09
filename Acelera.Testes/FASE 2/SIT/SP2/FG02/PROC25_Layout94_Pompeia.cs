using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC25_Layout94_Pompeia : TestesFG02
    {

        /// <summary>
        /// Informar no campo CD_RAMO valor diferente do parametrizado na tabela TAB_PRM_RAMO_7002
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2748_PARC_EMISSAO_CD_RAMO_Inv()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "2748", "FG02 - PROC25 - Informar no campo CD_RAMO valor diferente do parametrizado na tabela TAB_PRM_RAMO_7002");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.PARCEMS-EV-1931-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(5, "CD_RAMO", dados.ObterRamo(false));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.POMPEIA.PARCEMS-EV-/*R*/-20200212.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "24");
            ValidarTeste();

        }

        /// <summary>
        /// Informar no campo CD_RAMO valor parametrizado na tabela TAB_PRM_RAMO_7002
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2749_PARC_EMISSAO_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "2749", "FG02 - PROC25 - Informar no campo CD_RAMO valor parametrizado na tabela TAB_PRM_RAMO_7002");
            
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.PARCEMS-EV-1931-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(5, "CD_RAMO", dados.ObterRamo(true));

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
