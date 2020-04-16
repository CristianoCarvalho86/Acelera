using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_3;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC1024_Layout93_VIVO : TestesFG02
    {
        /// <summary>
        /// Informar DT_FIM_VIGENCIA=D+200 do inicio de vigência
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3842_ParcEmissao_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "3842", "FG02 - PROC1024 - Informar DT_FIM_VIGENCIA=D+200 do inicio de vigência");

            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1864-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "DT_FIM_VIGENCIA", SomarData("DT_INICIO_VIGENCIA", 200));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.VIVO.PARCEMSAUTO-EV-/*R*/-20200211.txt");

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
