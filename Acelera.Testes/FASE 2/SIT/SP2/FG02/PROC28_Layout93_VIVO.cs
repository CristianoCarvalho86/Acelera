using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_3;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC28_Layout93_VIVO : TestesFG02
    {

        /// <summary>
        /// Informar no campo CD_MOVTO_COBRANCA valor diferente do parametrizado na tabela TAB_PRM_MOVTO_COBRANCA_7025
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2770_PARC_EMISSAO_CD_MOVTO_COBRANCA_Inv()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "2770", "FG02 - PROC28 - Informar no campo CD_MOVTO_COBRANCA valor diferente do parametrizado na tabela TAB_PRM_MOVTO_COBRANCA_7025");
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1864-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(7, "CD_MOVTO_COBRANCA", dados.ObterMovimentoCobranca(false));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("PROC28");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissaoAuto.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "28");
            ValidarTeste();

        }

        /// <summary>
        /// Informar no campo CD_MOVTO_COBRANCA valor parametrizado na tabela TAB_PRM_MOVTO_COBRANCA_7025
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2771_PARC_EMISSAO_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "2771", "FG02 - PROC28 - Informar no campo CD_MOVTO_COBRANCA valor parametrizado na tabela TAB_PRM_MOVTO_COBRANCA_7025");
            
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1864-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(7, "CD_MOVTO_COBRANCA", dados.ObterMovimentoCobranca(true));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.VIVO.PARCEMSAUTO-EV-/*R*/-20200211.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissaoAuto.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(true, "28");
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia,true);
            ValidarTeste();

        }
        
    }
}
