using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP5.FG02
{
    [TestClass]
    public class PROC23_Layout94_COOP : TestesFG02
    {

        /// <summary>
        /// Informar no campo CD_MOEDA valor diferente do parametrizado na tabela TAB_PRM_MOEDA_7030
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3992_PARC_EMISSAO_CD_MOEDA_Inv()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3992", "FG02 - PROC23 - Informar no campo CD_MOEDA valor diferente do parametrizado na tabela TAB_PRM_MOEDA_7030");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.COOP.PARCEMS-EV-1931-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(9, "CD_MOEDA", dados.ObterCDMoeda(false));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.COOP.PARCEMS-EV-/*R*/-20200212.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "23");
            ValidarTeste();

        }

        /// <summary>
        /// Informar no campo CD_MOEDA valor diferente do parametrizado na tabela TAB_PRM_MOEDA_7030
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3993_SINISTRO_CD_MOEDA_Inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3993", "FG02 - PROC23 - Informar no campo CD_MOEDA valor diferente do parametrizado na tabela TAB_PRM_MOEDA_7030");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.COOP.SINISTRO-EV-0001-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "CD_MOEDA", dados.ObterCDMoeda(false));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.COOP.SINISTRO-EV-/*R*/-20200211.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "23");
            ValidarTeste();

        }

        /// <summary>
        /// Informar no campo CD_MOEDA valor parametrizado na tabela TAB_PRM_MOEDA_7030
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3994_PARC_EMISSAO_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3994", "FG02 - PROC23 - Informar no campo CD_MOEDA valor parametrizado na tabela TAB_PRM_MOEDA_7030");
            
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.COOP.PARCEMS-EV-1931-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(9, "CD_MOEDA", dados.ObterCDMoeda(true));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.COOP.PARCEMS-EV-/*R*/-20200212.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(true, "23");
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia, true);
            ValidarTeste();

        }

        /// <summary>
        /// Informar no campo CD_MOEDA valor diferente do parametrizado na tabela TAB_PRM_MOEDA_7030
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3995_SINISTRO_CD_MOEDA_Inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3995", "FG02 - PROC23 - Informar no campo CD_MOEDA valor diferente do parametrizado na tabela TAB_PRM_MOEDA_7030");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.COOP.SINISTRO-EV-0002-20191220.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "CD_MOEDA", dados.ObterCDMoeda(false));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(true, "23");
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia, true);
            ValidarTeste();

        }

    }
}
