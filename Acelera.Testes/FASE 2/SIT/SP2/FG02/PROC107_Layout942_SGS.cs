using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_3;
using Acelera.Domain.Layouts._9_4;
using Acelera.Domain.Layouts._9_4_2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC107_Layout942_SGS : TestesFG02
    {

        /// <summary>
        /// 	Informar cobertura, ramo e produto não associados nas tabelas TAB_PRM_COBERTURA_7007, TAB_PRM_PRODUTO_7003
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2922_COB_RAMO_PROD_NAO_ASSOCIADOS()
        {
            IniciarTeste(TipoArquivo.Sinistro, "2922", "FG02 - PROC107 - Informar cobertura, ramo e produto não associados nas tabelas TAB_PRM_COBERTURA_7007, TAB_PRM_PRODUTO_7003");
            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            SelecionarLinhaParaValidacao(0);
            var cobertura = dados.ObterCoberturaSimples(ObterValorHeader("CD_TPA"));
            AlterarLinha(0, "CD_COBERTURA", cobertura.CdCobertura);
            AlterarLinha(0, "CD_RAMO", dados.ObterRamoNaoRelacionadoACobertura(cobertura.CdCobertura));
            AlterarLinha(0, "CD_PRODUTO", dados.ObterProdutoNaoRelacionadoACobertura(cobertura.CdCobertura));
            //AlterarLinha(0, "CD_PRODUTO", dados.ObterProdutoNaoRelacionadoACobertura("01770"));
            //AlterarLinha(0, "CD_RAMO", dados.ObterRamoNaoRelacionadoACobertura("01770"));
            //AlterarLinha(0, "CD_COBERTURA", "01770");
            RemoverLinhasExcetoAsPrimeiras(1);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("PROC107");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "107");
            ValidarTeste();

        }

        /// <summary>
        /// 	Sem Critica
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2923_COB_RAMO_PROD_NAO_ASSOCIADOS()
        {
            IniciarTeste(TipoArquivo.Sinistro, "2923", "FG02 - PROC107 - SEM CRITICA");
            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            var cobertura = dados.ObterCoberturaSimples(ObterValorHeader("CD_TPA"));
            AlterarLinha(0, "CD_COBERTURA", cobertura.CdCobertura);
            AlterarLinha(0, "CD_RAMO", cobertura.CdRamo);
            AlterarLinha(0, "CD_PRODUTO", cobertura.CdProduto);
            RemoverLinhasExcetoAsPrimeiras(1);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SGS.SINISTRO-EV-/*R*/-20200212.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStagesSemGerarErro(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(true, "107");
            ValidarTeste();

        }

    }
}
