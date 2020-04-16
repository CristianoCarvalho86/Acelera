using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC184_Layout94_Softbox : TestesFG02
    {

        /// <summary>
        /// Informar CD_TIPO_MOVIMENTO não parametrizado na tabela TAB_PRM_TIPO_MOVIMENTO_7024 com o CD_ATUACAO = "SN"
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3689_CD_BANCO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3689", "FG02 - PROC184 - Informar CD_TIPO_MOVIMENTO não parametrizado na tabela TAB_PRM_TIPO_MOVIMENTO_7024 com o CD_ATUACAO = SN");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.SINISTRO-EV-3254-20200321.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", dados.ObterCDTipoMovimentoNaoRelacionadoAAtuacao("SN"));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SOFTBOX.SINISTRO-EV-/*R*/-20200321.txt");

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
        public void SAP_3690_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3690", "FG02 - PROC184 - Informar CD_TIPO_MOVIMENTO parametrizado na tabela TAB_PRM_TIPO_MOVIMENTO_7024 com o CD_ATUACAO = SN");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.SINISTRO-EV-3280-20200323.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", dados.ObterCDTipoMovimentoNaoRelacionadoAAtuacao("SN"));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SOFTBOX.SINISTRO-EV-/*R*/-20200323.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(false);
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTeste();
        } 
    }
}
