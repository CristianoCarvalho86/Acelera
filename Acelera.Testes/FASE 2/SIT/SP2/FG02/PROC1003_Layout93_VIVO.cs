using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_3;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC1003_Layout93_VIVO : TestesFG02
    {
        /// <summary>
        /// Informar no campo Cd_cobertura um cobertura não parametrizado para o CD_TPA (CD_OPERAÇÃO)
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3807_SEM_CRITICA()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "3807", "FG02 - PROC218 - Informar no campo Cd_cobertura um cobertura não parametrizado para o CD_TPA (CD_OPERAÇÃO)");
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1816-20200131.txt"));

            //ALTERAR O VALOR SELECIONADO
            var cobertura = dados.ObterCobertura(dados.ObterIdCoberturaParaTPA(ObterValorHeader("CD_TPA"), true));
            AlterarLinha(0, "CD_COBERTURA", cobertura.CdCobertura);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissaoAuto.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStagesSemGerarErro(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(true,"1003");
            ValidarTeste();

        }
    }
}
