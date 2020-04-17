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
        public void SAP_4058_PARC_EMISSAO_AUTO_CD_PRODUTO_Inv()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "4058", "FG02 - PROC26 - Informar no campo CD_PRODUTO valor diferente do parametrizado na tabela TAB_PRM_PRODUTO_7003");
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
        /// Informar no campo CD_PRODUTO valor diferente do parametrizado na tabela TAB_PRM_PRODUTO_7003
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4059_COMISSAO_CD_PRODUTO_Inv()
        {
            IniciarTeste(TipoArquivo.Comissao, "4059", "FG02 - PROC26 - Informar no campo CD_PRODUTO valor diferente do parametrizado na tabela TAB_PRM_PRODUTO_7003");
            arquivo = new Arquivo_Layout_9_3_EmsComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.EMSCMS-EV-1865-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "CD_PRODUTO", dados.ObterProduto(false));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Comissao.ObterTexto());

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
        public void SAP_4060_PARC_EMISSAO_AUTO_semcritica()
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

        /// <summary>
        /// Informar no campo CD_PRODUTO valor diferente do parametrizado na tabela TAB_PRM_PRODUTO_7003
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4061_COMISSAO_Sem_Critica()
        {
            IniciarTeste(TipoArquivo.Comissao, "4061", "FG02 - PROC26 - Informar no campo CD_PRODUTO valor diferente do parametrizado na tabela TAB_PRM_PRODUTO_7003");
            arquivo = new Arquivo_Layout_9_3_EmsComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.EMSCMS-EV-1865-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "CD_PRODUTO", dados.ObterProduto(true));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Comissao.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno();
            ValidarTeste();

        }


    }
}
