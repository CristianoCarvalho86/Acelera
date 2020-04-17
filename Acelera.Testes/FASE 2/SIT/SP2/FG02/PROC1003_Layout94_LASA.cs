using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Acelera.Domain.Layouts._9_4_2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC1003_Layout94_LASA : TestesFG02
    {

        /// <summary>
        /// Informar no campo Cd_cobertura um cobertura não parametrizado para o CD_TPA (CD_OPERAÇÃO)
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3803_VL_PREMIO_TOTAL_inv()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3803", "FG02 - PROC218 - Informar no campo Cd_cobertura um cobertura não parametrizado para o CD_TPA (CD_OPERAÇÃO)");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.PARCEMS-EV-3158-20200316.txt"));

            //ALTERAR O VALOR SELECIONADO
            var cobertura = dados.ObterCobertura(dados.ObterIdCoberturaParaTPA(ObterValorHeader("CD_TPA"), false));
            AlterarLinha(0, "CD_COBERTURA", cobertura.CdCobertura);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1,"218");
            ValidarTeste();
        }

        /// <summary>
        /// Informar no campo Cd_cobertura um cobertura parametrizado para o CD_TPA (CD_OPERAÇÃO)
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3804_SEM_CRITICA()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3804", "FG02 - PROC218 - Informar no campo Cd_cobertura um cobertura parametrizado para o CD_TPA (CD_OPERAÇÃO)");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.PARCEMS-EV-3224-20200320.txt"));

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
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno();
            ValidarTeste();

        }
    }
}
