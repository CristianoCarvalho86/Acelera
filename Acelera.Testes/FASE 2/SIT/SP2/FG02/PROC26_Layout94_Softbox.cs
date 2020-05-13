using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC26_Layout94_Softbox : TestesFG02
    {

        /// <summary>
        /// Informar no campo CD_PRODUTO valor diferente do parametrizado na tabela TAB_PRM_PRODUTO_7003
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4078_PARC_EMISSAO_CD_PRODUTO_Inv()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "4078", "FG02 - PROC26 - Informar no campo CD_PRODUTO valor diferente do parametrizado na tabela TAB_PRM_PRODUTO_7003");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.PARCEMS-EV-3244-20200321.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(9, "CD_PRODUTO", dados.ObterProduto(false));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SOFTBOX.PARCEMS-EV-/*R*/-20200321.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1,"26");
            ValidarTeste();

        }

        /// <summary>
        /// Informar no campo CD_PRODUTO valor diferente do parametrizado na tabela TAB_PRM_PRODUTO_7003
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4081_SINISTRO_CD_PRODUTO_Inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "4081", "FG02 - PROC26 - Informar no campo CD_PRODUTO valor diferente do parametrizado na tabela TAB_PRM_PRODUTO_7003");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.SINISTRO-EV-3333-20200326.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_PRODUTO", dados.ObterProduto(false));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "26");
            ValidarTeste();

        }

        /// <summary>
        /// Informar no campo CD_PRODUTO valor parametrizado na tabela TAB_PRM_PRODUTO_7003
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4082_PARC_EMISSAO_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "4082", "FG02 - PROC26 - Informar no campo CD_PRODUTO valor parametrizado na tabela TAB_PRM_PRODUTO_7003");
            
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.PARCEMS-EV-3244-20200321.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(9, "CD_PRODUTO", dados.ObterProduto(true));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SOFTBOX.PARCEMS-EV-/*R*/-20200321.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(true, "26");
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia, true);
            ValidarTeste();

        }

        /// <summary>
        /// Informar no campo CD_PRODUTO valor diferente do parametrizado na tabela TAB_PRM_PRODUTO_7003
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4085_SINISTRO_Sem_Critica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "4085", "FG02 - PROC26 - Informar no campo CD_PRODUTO valor diferente do parametrizado na tabela TAB_PRM_PRODUTO_7003");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.SINISTRO-EV-3333-20200326.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_PRODUTO", dados.ObterProduto(true));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(true, "26");
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia, true);
            ValidarTeste();

        }

    }
}
