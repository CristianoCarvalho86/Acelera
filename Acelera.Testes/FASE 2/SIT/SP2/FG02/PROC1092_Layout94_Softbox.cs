using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC1092_Layout94_Softbox : TestesFG02
    {

        /// <summary>
        /// Informar CD_FRANQUIA não parametrizado na TAB_PRM_FRANQUIA_7010
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3921_CD_FRANQUIA_inv()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3921", "FG02 - PROC1092 - Informar CD_FRANQUIA não parametrizado na TAB_PRM_FRANQUIA_7010");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.PARCEMS-EV-3276-20200323.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_FRANQUIA", dados.ObterCDFranquia(false));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "1092");
            ValidarTeste();
        }

        /// <summary>
        /// Informar CD_FRANQUIA parametrizado na TAB_PRM_FRANQUIA_7010
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3922_ParcEmissao_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3922", "FG02 - PROC1092 - Informar CD_FRANQUIA parametrizado na TAB_PRM_FRANQUIA_7010");

            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.PARCEMS-EV-3260-20200322.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_FRANQUIA", dados.ObterCDFranquia(true));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(true, "1092");
            ValidarStagesSemGerarErro(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTeste();

        }
    }
}
