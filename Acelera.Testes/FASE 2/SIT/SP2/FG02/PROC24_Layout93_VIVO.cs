using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_3;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC24_Layout93_VIVO : TestesFG02
    {

        /// <summary>
        /// Informar no campo CD_COBERTURA valor diferente do parametrizado na tabela TAB_PRM_COBERTURA_7007
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4006_PARC_EMISSAO_CD_COBERTURA_Inv()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "4006", "FG02 - PROC24 - Informar no campo CD_COBERTURA valor diferente do parametrizado na tabela TAB_PRM_COBERTURA_7007");
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1864-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(8, "CD_COBERTURA", dados.ObterCDCobertura(false));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.VIVO.PARCEMSAUTO-EV-/*R*/-20200211.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissaoAuto.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "24");
            ValidarTeste();

        }

        /// <summary>
        /// Informar no campo CD_COBERTURA valor diferente do parametrizado na tabela TAB_PRM_COBERTURA_7007
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4007_COMISSAO_CD_COBERTURA_Inv()
        {
            IniciarTeste(TipoArquivo.Comissao, "4007", "FG02 - PROC24 - Informar no campo CD_COBERTURA valor diferente do parametrizado na tabela TAB_PRM_COBERTURA_7007");
            arquivo = new Arquivo_Layout_9_3_EmsComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.EMSCMS-EV-1865-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(8, "CD_COBERTURA", dados.ObterCDCobertura(false));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Comissao.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "24");
            ValidarTeste();

        }


        /// <summary>
        /// Informar no campo CD_COBERTURA valor parametrizado na tabela TAB_PRM_COBERTURA_7007
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4008_PARC_EMISSAO_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "4008", "FG02 - PROC24 - Informar no campo CD_COBERTURA valor parametrizado na tabela TAB_PRM_COBERTURA_7007");
            
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1864-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(8, "CD_COBERTURA", dados.ObterCDCobertura(true));

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
        /// Informar no campo CD_COBERTURA valor diferente do parametrizado na tabela TAB_PRM_COBERTURA_7007
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4009_COMISSAO_CD_COBERTURA_SemCritica()
        {
            IniciarTeste(TipoArquivo.Comissao, "4009", "FG02 - PROC24 - Informar no campo CD_COBERTURA valor diferente do parametrizado na tabela TAB_PRM_COBERTURA_7007");
            arquivo = new Arquivo_Layout_9_3_EmsComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.EMSCMS-EV-1865-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(8, "CD_COBERTURA", dados.ObterCDCobertura(false));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Comissao.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia,true);
            ValidarTabelaDeRetorno(true, "24");
            ValidarTeste();

        }

    }
}
