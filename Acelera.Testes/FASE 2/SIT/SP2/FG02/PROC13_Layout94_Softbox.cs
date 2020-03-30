using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC13_Layout94_Softbox : TestesFG02
    {

        /// <summary>
        /// Informar no arquivo PARC_EMISSAO o campo VL_IS = -200
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2671_PARC_EMISSAO_VL_IS_negativo()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "2671", "FG02 - PROC13 - Informar no arquivo PARC_EMISSAO o campo VL_IS = -200");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.PARCEMS-EV-3292-20200324.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(3, "VL_IS", "-200");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SOFTBOX.PARCEMS-EV-/*R*/-20200324.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno("13");
            ValidarTeste();

        }

        /// <summary>
        /// Informar no arquivo PARC_EMISSAO_AUTO o campo VL_IS=1
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2672_PARC_EMISSAO_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "2672", "FG00 - PROC13 - Informar no arquivo PARC_EMISSAO_AUTO o campo VL_IS=1");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.PARCEMS-EV-3292-20200324.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(3, "VL_IS", "1");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SOFTBOX.PARCEMS-EV-/*R*/-20200324.txt");

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
