using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Acelera.Domain.Layouts._9_4_2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP5.FG02
{
    [TestClass]
    public class PROC1003_Layout94_COOP : TestesFG02
    {
        /// <summary>
        /// Informar no campo Cd_cobertura um cobertura não parametrizado para o CD_TPA (CD_OPERAÇÃO)
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3808_SEM_CRITICA()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3808", "FG02 - PROC218 - Informar no campo Cd_cobertura um cobertura não parametrizado para o CD_TPA (CD_OPERAÇÃO)");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.COOP.PARCEMS-EV-1928-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_COBERTURA", "01589");
            RemoverLinhasExcetoAsPrimeiras(1);

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
