using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_3;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC26_Layout93_VIVO : TestesFG02
    {

        /// <summary>
        /// Informar no campo CD_PRODUTO valor diferente do parametrizado na tabela TAB_PRM_PRODUTO_7003
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2762_PARC_EMISSAO_CD_PRODUTO_Inv()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "2762", "FG02 - PROC26 - Informar no campo CD_PRODUTO valor diferente do parametrizado na tabela TAB_PRM_PRODUTO_7003");
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1864-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(7, "CD_PRODUTO", dados.ObterProduto(false));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.VIVO.PARCEMSAUTO-EV-/*R*/-20200211.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissaoAuto.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1,"26");
            ValidarTeste();

        }

        /// <summary>
        /// Informar no campo CD_PRODUTO valor parametrizado na tabela TAB_PRM_PRODUTO_7003
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2763_PARC_EMISSAO_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "2763", "FG02 - PROC26 - Informar no campo CD_PRODUTO valor parametrizado na tabela TAB_PRM_PRODUTO_7003");
            
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1864-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(7, "CD_PRODUTO", dados.ObterProduto(true));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.VIVO.PARCEMSAUTO-EV-/*R*/-20200211.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissaoAuto.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(false);
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTeste();

        }
        
    }
}
