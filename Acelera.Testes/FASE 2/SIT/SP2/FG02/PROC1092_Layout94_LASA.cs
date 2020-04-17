using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC1092_Layout94_LASA : TestesFG02
    {

        /// <summary>
        /// Informar CD_FRANQUIA não parametrizado na TAB_PRM_FRANQUIA_7010
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3919_CD_FRANQUIA_inv()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3919", "FG02 - PROC1092 - Informar CD_FRANQUIA não parametrizado na TAB_PRM_FRANQUIA_7010");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.PARCEMS-EV-3158-20200316.txt"));

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
        public void SAP_3911_ParcEmissao_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3911", "FG02 - PROC1092 - Informar CD_FRANQUIA parametrizado na TAB_PRM_FRANQUIA_7010");

            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.PARCEMS-EV-3240-20200321.txt"));

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
            ValidarTabelaDeRetorno(false);
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTeste();

        }
    }
}
