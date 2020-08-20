using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_3;
using Acelera.Domain.Layouts._9_4;
using Acelera.Domain.Layouts._9_4_2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP5.FG02
{
    [TestClass]
    public class PROC107_Layout94_PAPCARD : TestesFG02
    {

        /// <summary>
        /// 	Informar cobertura, ramo e produto não associados nas tabelas TAB_PRM_COBERTURA_7007, TAB_PRM_PRODUTO_7003
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2910_COB_RAMO_PROD_NAO_ASSOCIADOS()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "2910", "FG02 - PROC107 - Informar cobertura, ramo e produto não associados nas tabelas TAB_PRM_COBERTURA_7007, TAB_PRM_PRODUTO_7003");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.PAPCARD.PARCEMS-EV-1928-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            var cobertura = dados.ObterCoberturaSimples(ObterValorHeader("CD_TPA"));
            AlterarLinha(0, "CD_COBERTURA", cobertura.CdCobertura);
            AlterarLinha(0, "CD_RAMO", dados.ObterRamoNaoRelacionadoACobertura(cobertura.CdCobertura));
            AlterarLinha(0, "CD_PRODUTO", dados.ObterProdutoNaoRelacionadoACobertura(cobertura.CdCobertura));
            RemoverLinhasExcetoAsPrimeiras(1);
            //AlterarLinha(0, "CD_PRODUTO", dados.ObterProdutoNaoRelacionadoACobertura("01770"));
            //AlterarLinha(0, "CD_RAMO", dados.ObterRamoNaoRelacionadoACobertura("01770"));
            //AlterarLinha(0, "CD_COBERTURA", "01770");


            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1,"107");
            ValidarTeste();

        }

        /// <summary>
        /// 	Informar cobertura, ramo e produto não associados nas tabelas TAB_PRM_COBERTURA_7007, TAB_PRM_PRODUTO_7003
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2911_COB_RAMO_PROD_NAO_ASSOCIADOS()
        {
            IniciarTeste(TipoArquivo.Sinistro, "2911", "FG02 - PROC107 - Informar cobertura, ramo e produto não associados nas tabelas TAB_PRM_COBERTURA_7007, TAB_PRM_PRODUTO_7003");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.PAPCARD.SINISTRO-EV-0001-20191128.txt"));

            //ALTERAR O VALOR SELECIONADO
            var cobertura = dados.ObterCoberturaSimples(ObterValorHeader("CD_TPA"));
            AlterarLinha(0, "CD_COBERTURA", cobertura.CdCobertura);
            AlterarLinha(0, "CD_RAMO", dados.ObterRamoNaoRelacionadoACobertura(cobertura.CdCobertura));
            AlterarLinha(0, "CD_PRODUTO", dados.ObterProdutoNaoRelacionadoACobertura(cobertura.CdCobertura));


            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.PAPCARD.SINISTRO-EV-/*R*/-20191128.txt");

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
        public void SAP_2912_SEM_CRITICA()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "2912", "FG02 - PROC107 - Informar cobertura, ramo e produto não associados nas tabelas TAB_PRM_COBERTURA_7007, TAB_PRM_PRODUTO_7003");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.PAPCARD.PARCEMS-EV-1982-20200302.txt"));

            //ALTERAR O VALOR SELECIONADO
            var cobertura = dados.ObterCoberturaSimples(ObterValorHeader("CD_TPA"));
            AlterarLinha(0, "CD_COBERTURA", cobertura.CdCobertura);
            AlterarLinha(0, "CD_RAMO", cobertura.CdRamo);
            AlterarLinha(0, "CD_PRODUTO", cobertura.CdProduto);
            RemoverLinhasExcetoAsPrimeiras(1);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.PAPCARD.PARCEMS-EV-/*R*/-20200302.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStagesSemGerarErro(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(true,"107");
            ValidarTeste();

        }

        /// <summary>
        /// 	Sem Critica
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
            public void SAP_2913_SEM_CRITICA()
        {
            IniciarTeste(TipoArquivo.Sinistro, "2913", "FG02 - PROC107 - sem critica");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.PAPCARD.SINISTRO-EV-0001-20200117.txt"));

            //ALTERAR O VALOR SELECIONADO
            var cobertura = dados.ObterCoberturaSimples(ObterValorHeader("CD_TPA"));
            AlterarLinha(0, "CD_COBERTURA", cobertura.CdCobertura);
            AlterarLinha(0, "CD_RAMO", cobertura.CdRamo);
            AlterarLinha(0, "CD_PRODUTO", cobertura.CdProduto);


            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

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
