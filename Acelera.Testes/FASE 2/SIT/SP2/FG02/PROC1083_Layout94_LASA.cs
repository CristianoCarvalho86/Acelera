using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC1083_Layout94_LASA : TestesFG02
    {

        /// <summary>
        /// DT_VENCIMENTO = D-1 DT_EMISSAO
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3881_DT_VENCIMENTO_inv()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3881", "FG02 - PROC1083 - DT_VENCIMENTO = D-1 DT_EMISSAO");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.PARCEMS-EV-3158-20200316.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "DT_VENCIMENTO", SomarData(ObterValor(0,"DT_EMISSAO"), -1));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.PARCEMS-EV-/*R*/-20200316.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "1083");
            ValidarTeste();
        }

        /// <summary>
        /// DT_VENCIMENTO = DT_EMISSAO
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3882_ParcEmissao_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3882", "FG02 - PROC1083 - DT_VENCIMENTO = DT_EMISSAO");

            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.PARCEMS-EV-3240-20200321.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "DT_VENCIMENTO", ObterValor(0, "DT_EMISSAO"));

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

        /// <summary>
        /// DT_VENCIMENTO = D+1 DT_EMISSAO
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3883_ParcEmissao_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3883", "FG02 - PROC1083 - DT_VENCIMENTO = D+1 DT_EMISSAO");

            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.PARCEMS-EV-3240-20200321.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "DT_VENCIMENTO", SomarData(ObterValor(0,"DT_EMISSAO"), 1));

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
