using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC1091_Layout94_Softbox : TestesFG02
    {

        /// <summary>
        /// Informar VL_LMI maior que VL_IS (0.01)
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3912_VL_LMI_inv()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3912", "FG02 - PROC1091 - Informar VL_LMI maior que VL_IS (0.01)");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.PARCEMS-EV-3228-20200320.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "VL_LMI", SomarValor(0, "VL_IS", 0.01M));
            RemoverLinhasExcetoAsPrimeiras(1);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "1091");
            ValidarTeste();
        }

        /// <summary>
        /// Informar VL_LMI menor que VL_IS (0.01)
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3913_VL_LMI_inv()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3913", "FG02 - PROC1091 - Informar VL_LMI menor que VL_IS (0.01)");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.PARCEMS-EV-3325-20200326.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "VL_LMI", SomarValor(0, "VL_IS", -0.01M));
            RemoverLinhasExcetoAsPrimeiras(1);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "1091");
            ValidarTeste();
        }

        /// <summary>
        /// Informar VL_LMI igual ao VL_IS
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3914_ParcEmissao_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3914", "FG02 - PROC1091 - Informar VL_LMI igual ao VL_IS");

            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.PARCEMS-EV-3276-20200323.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "VL_LMI", ObterValor(0, "VL_IS"));
            RemoverLinhasExcetoAsPrimeiras(1);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(true, "1091");
            ValidarStagesSemGerarErro(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTeste();

        }
    }
}
