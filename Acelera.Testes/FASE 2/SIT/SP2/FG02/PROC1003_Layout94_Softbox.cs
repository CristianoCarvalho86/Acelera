using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Acelera.Domain.Layouts._9_4_2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC1003_Layout94_Softbox : TestesFG02
    {

        /// <summary>
        /// Informar no campo Cd_cobertura um cobertura não parametrizado para o CD_TPA (CD_OPERAÇÃO)
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3805_VL_PREMIO_TOTAL_inv()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3805", "FG02 - PROC218 - Informar no campo Cd_cobertura um cobertura não parametrizado para o CD_TPA (CD_OPERAÇÃO)");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.PARCEMS-EV-2751-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_COBERTURA", "01794");
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
            ValidarTabelaDeRetorno(1,"1003");
            ValidarTeste();
        }

        /// <summary>
        /// Informar no campo Cd_cobertura um cobertura parametrizado para o CD_TPA (CD_OPERAÇÃO)
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3806_SEM_CRITICA()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3806", "FG02 - PROC218 - Informar no campo Cd_cobertura um cobertura parametrizado para o CD_TPA (CD_OPERAÇÃO)");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.PARCEMS-EV-3162-20200316.txt"));

            //ALTERAR O VALOR SELECIONADO
            var cobertura = dados.ObterCobertura(dados.ObterIdCoberturaParaTPA(ObterValorHeader("CD_TPA"), true));
            AlterarLinha(0, "CD_COBERTURA", cobertura.CdCobertura);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStagesSemGerarErro(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(true, "1003");
            ValidarTeste();

        }
    }
}
