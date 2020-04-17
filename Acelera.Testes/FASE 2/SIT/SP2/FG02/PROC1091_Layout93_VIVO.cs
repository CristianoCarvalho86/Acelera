using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_3;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC1091_Layout93_VIVO : TestesFG02
    {
        /// <summary>
        /// Informar VL_LMI maior que VL_IS (0.01)
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3915_ParcEmissaoAuto_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "3915", "FG02 - PROC1091 - Informar VL_LMI maior que VL_IS (0.01)");

            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1868-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "VL_LMI", SomarValor(0, "VL_IS", 0.01M));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

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
        /// Informar VL_LMI menor que VL_IS (0.01)
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3916_ParcEmissaoAuto_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "3916", "FG02 - PROC1091 - Informar VL_LMI menor que VL_IS (0.01)");

            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1864-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "VL_LMI", SomarValor(0, "VL_IS", -0.01M));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

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
    }
}
