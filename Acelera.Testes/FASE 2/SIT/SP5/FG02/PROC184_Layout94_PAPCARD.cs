using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP5.FG02
{
    [TestClass]
    public class PROC184_Layout94_PAPCARD : TestesFG02
    {

        /// <summary>
        /// Informar CD_TIPO_MOVIMENTO não parametrizado na tabela TAB_PRM_TIPO_MOVIMENTO_7024 com o CD_ATUACAO = "SN"
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3691_CD_BANCO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3691", "FG02 - PROC184 - Informar CD_TIPO_MOVIMENTO não parametrizado na tabela TAB_PRM_TIPO_MOVIMENTO_7024 com o CD_ATUACAO = SN");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.PAPCARD.SINISTRO-EV-0001-20191223.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", dados.ObterCDTipoMovimentoParaAtuacao("SN",false));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.PAPCARD.SINISTRO-EV-/*R*/-20191223.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "184");
            ValidarTeste();
        }

        /// <summary>
        ///Informar CD_TIPO_MOVIMENTO parametrizado na tabela TAB_PRM_TIPO_MOVIMENTO_7024 com o CD_ATUACAO = "SN"
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3692_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3692", "FG02 - PROC184 - Informar CD_TIPO_MOVIMENTO parametrizado na tabela TAB_PRM_TIPO_MOVIMENTO_7024 com o CD_ATUACAO = SN");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.PAPCARD.SINISTRO-EV-0001-20200117.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", dados.ObterCDTipoMovimentoParaAtuacao("SN",true));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.PAPCARD.SINISTRO-EV-/*R*/-20200117.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(true, "184");
            ValidarStagesSemGerarErro(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTeste();
        } 
    }
}
