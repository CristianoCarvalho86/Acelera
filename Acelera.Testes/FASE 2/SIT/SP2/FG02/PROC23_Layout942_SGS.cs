using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Acelera.Domain.Layouts._9_4_2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC23_Layout942_SGS : TestesFG02
    {

        /// <summary>
        /// Informar no campo CD_MOEDA valor diferente do parametrizado na tabela TAB_PRM_MOEDA_7030
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4004_SINISTRO_CD_MOEDA_Inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "4004", "FG02 - PROC23 - Informar no campo CD_MOEDA valor diferente do parametrizado na tabela TAB_PRM_MOEDA_7030");
            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "CD_MOEDA", dados.ObterCDMoeda(false));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("PROC23");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "23");
            ValidarTeste();

        }

        /// <summary>
        /// Informar no campo CD_MOEDA valor diferente do parametrizado na tabela TAB_PRM_MOEDA_7030
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4005_SINISTRO_CD_MOEDA_Inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "4005", "FG02 - PROC23 - Informar no campo CD_MOEDA valor diferente do parametrizado na tabela TAB_PRM_MOEDA_7030");
            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200209.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "CD_MOEDA", dados.ObterCDMoeda(true));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno();
            ValidarTeste();

        }

    }
}
