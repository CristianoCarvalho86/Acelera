using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Acelera.Domain.Layouts._9_4_2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC26_Layout942_SGS : TestesFG02
    {

        /// <summary>
        /// Informar no campo CD_PRODUTO valor diferente do parametrizado na tabela TAB_PRM_PRODUTO_7003
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4086_SINISTRO_CD_PRODUTO_Inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "4086", "FG02 - PROC26 - Informar no campo CD_PRODUTO valor diferente do parametrizado na tabela TAB_PRM_PRODUTO_7003");
            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200213.txt"));

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
        /// Informar no campo CD_PRODUTO valor diferente do parametrizado na tabela TAB_PRM_PRODUTO_7003
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4087_SINISTRO_CD_PRODUTO_Inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "4087", "FG02 - PROC26 - Informar no campo CD_PRODUTO valor diferente do parametrizado na tabela TAB_PRM_PRODUTO_7003");
            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200213.txt"));

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
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno();
            ValidarTeste();

        }


    }
}
